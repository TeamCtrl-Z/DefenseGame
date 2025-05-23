using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class CsvLoader
{
    /// <summary>
    /// Resources/Data/CSVs/{resourceName}.csv 를 읽어서
    /// 첫 번째 헤더 컬럼을 int 키로 사용하고,
    /// 나머지 컬럼은 T의 프로퍼티/필드에 자동 매핑하여
    /// Dictionary<int,T>를 반환합니다.
    /// </summary>
    public static Dictionary<int, T> LoadTable<T>(string resourceName) where T : new()
    {
        // 1) CSV 텍스트 로드
        var ta = Resources.Load<TextAsset>($"Data/{resourceName}");
        if (ta == null)
            throw new Exception($"CSV '{resourceName}.csv' 을 Resources/Data/CSVs 에서 찾을 수 없습니다.");

        // 2) 전체 라인 분리 (윈도우/유닉스 개행 모두 대응)
        var lines = ta.text
            .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        if (lines.Length < 2)
            throw new Exception("CSV에는 헤더 + 최소 1개 이상의 데이터 행이 필요합니다.");

        // 3) 헤더와 컬럼명 배열 추출
        var headers = lines[0].Split(',').Select(h => h.Trim()).ToArray();
        var keyColumnName = headers[0];      // 첫 번째 컬럼 이름을 키로 사용

        // 4) T 타입의 public 프로퍼티·필드 메타정보 캐싱
        var type = typeof(T);
        var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

        // 5) 데이터 행마다 T 인스턴스 생성 & 값 채우기
        var list = new List<T>();
        for (int i = 1; i < lines.Length; i++)
        {
            var cols = lines[i].Split(',');
            var obj = new T();

            for (int c = 0; c < headers.Length && c < cols.Length; c++)
            {
                var header = headers[c];
                var raw = cols[c].Trim();

                // 프로퍼티 우선
                var prop = props.FirstOrDefault(p => p.Name.Equals(header, StringComparison.OrdinalIgnoreCase));
                if (prop != null && prop.CanWrite)
                {
                    var val = Convert.ChangeType(raw, prop.PropertyType);
                    prop.SetValue(obj, val);
                    continue;
                }

                // 필드 체크
                var field = fields.FirstOrDefault(f => f.Name.Equals(header, StringComparison.OrdinalIgnoreCase));
                if (field != null)
                {
                    var val = Convert.ChangeType(raw, field.FieldType);
                    field.SetValue(obj, val);
                }
            }

            list.Add(obj);
        }

        // 6) 키 값을 꺼내는 델리게이트 생성
        Func<T, int> getKey = CreateKeyGetter<T>(keyColumnName);

        // 7) Dictionary 생성 후 반환
        return list.ToDictionary(getKey);
    }

    // 첫 번째 헤더(키 컬럼) 이름을 받아 T에서 해당 int 값을 꺼내는 Func<T,int> 생성
    private static Func<T, int> CreateKeyGetter<T>(string keyColumnName) where T : new()
    {
        var type = typeof(T);

        // 프로퍼티 검색
        var prop = type.GetProperty(
            keyColumnName,
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase
        );
        if (prop != null && prop.PropertyType == typeof(int))
            return obj => (int)prop.GetValue(obj);

        // 필드 검색
        var field = type.GetField(
            keyColumnName,
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase
        );
        if (field != null && field.FieldType == typeof(int))
            return obj => (int)field.GetValue(obj);

        throw new Exception($"타입 '{type.Name}'에 '{keyColumnName}' (int) 프로퍼티/필드가 없습니다.");
    }
}