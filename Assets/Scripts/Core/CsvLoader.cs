using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

/// <summary>
/// CSV파일을 로드하기 위한 클래스
/// </summary>
public static class CsvLoader
{
    /// <summary>
    /// Resources/Data/{resourceName}.csv 파일을 로드하여 T 타입 객체 리스트를 만들고,
    /// 첫 번째 컬럼(0번째 헤더)을 int 키로 해서 Dictionary<int, T> 로 변환하여 반환한다.
    /// T는 매개변수가 없는 생성자(new())를 가져야 한다.
    /// </summary>
    /// <typeparam name="T">CSV 각 행을 매핑할 클래스 타입 (public 프로퍼티/필드로 값이 주입될 것)</typeparam>
    /// <param name="resourceName">Resources/Data 폴더 아래에 있는 CSV 파일명 (확장자 제외)</param>
    /// <returns>첫 번째 컬럼(int) 값을 키로 하고, 해당 행을 T 타입으로 매핑한 값을 값으로 가지는 Dictionary</returns>
    public static Dictionary<uint, T> LoadTable<T>(string resourceName) where T : new()
    {
        // 1) Resources/Data/{resourceName}.csv 파일 로드
        var ta = Resources.Load<TextAsset>($"Data/{resourceName}");
        if (ta == null)
            throw new Exception($"CSV '{resourceName}.csv' 파일이 Resources/Data/ 폴더 에 없습니다..");

        // 2) 텍스트를 줄 단위로 분할하고, 빈 줄을 제거
        var lines = ta.text
            .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        if (lines.Length < 2)
            throw new Exception("CSV 파일은 최소 두 줄(헤더 + 데이터) 이상이어야 합니다.");

        // 3) 첫 줄(헤더)에서 컬럼 이름들을 추출하고, 첫 번째 컬럼을 키 컬럼으로 지정
        var headers = lines[0].Split(',').Select(h => h.Trim()).ToArray();
        var keyColumnName = headers[0];      // 0번째 컬럼을 키로 사용

        // 4) T 타입의 public 프로퍼티와 public 필드를 가져온다
        var type = typeof(T);
        var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

        // 5) 데이터 행들을 순회하면서 T 인스턴스 생성 후 값을 채워 리스트에 추가
        var list = new List<T>();
        for (int i = 1; i < lines.Length; i++)
        {
            var cols = lines[i].Split(',');
            var obj = new T();

            for (int c = 0; c < headers.Length && c < cols.Length; c++)
            {
                var header = headers[c];
                var raw = cols[c].Trim().Trim('"');

                // 5-1) 프로퍼티에 맞춰서 값 설정 (대소문자 무시)
                var prop = props.FirstOrDefault(p => p.Name.Equals(header, StringComparison.OrdinalIgnoreCase));
                if (prop != null && prop.CanWrite)
                {
                    var val = Convert.ChangeType(raw, prop.PropertyType);
                    prop.SetValue(obj, val);
                    continue;
                }

                // 5-2) 필드에 맞춰서 값 설정 (대소문자 무시)
                var field = fields.FirstOrDefault(f => f.Name.Equals(header, StringComparison.OrdinalIgnoreCase));
                if (field != null)
                {
                    var fieldType = field.FieldType;

                    object convertedValue = ConvertField(raw, fieldType);

                    field.SetValue(obj, convertedValue);
                }
            }

            list.Add(obj);
        }

        // 6) 첫 번째 컬럼(keyColumnName)을 읽어올 수 있는 Func<T, int> 델리게이트 생성
        Func<T, uint> getKey = CreateKeyGetter<T>(keyColumnName);

        // 7) List<T>를 Dictionary<int, T>로 변환하여 반환
        try
        {
            return list.ToDictionary(getKey);
        }
        catch (ArgumentException ex)
        {
            var duplicates = list
                .GroupBy(getKey)
                .Where(g => g.Count() > 1)
                .Select(g => new { Key = g.Key, Count = g.Count() })
                .ToList();

            foreach (var dup in duplicates)
            {
                Debug.LogError($"[중복 키 발견] Key: {dup.Key}, Count: {dup.Count}");
            }

            Debug.LogError($"[Dictionary 변환 실패] 중복 키로 인해 ToDictionary 실패: {ex.Message}");
            throw; // 또는 null 반환하거나 fallback 처리
        }
    }

    /// <summary>
    /// keyColumnName에 해당하는 프로퍼티 또는 필드를 찾아,
    /// 해당 멤버가 uint 형인 경우에만 객체에서 키 값을 꺼내는 델리게이트를 생성한다.
    /// </summary>
    /// <typeparam name="T">객체 타입</typeparam>
    /// <param name="keyColumnName">키로 사용할 컬럼(프로퍼티/필드) 이름</param>
    /// <returns>obj => obj.[keyColumnName] 형태의 Func<T, int></returns>
    /// <exception cref="Exception">해당 타입에 int 형 키 컬럼이 없으면 던짐</exception>
    private static Func<T, uint> CreateKeyGetter<T>(string keyColumnName) where T : new()
    {
        var type = typeof(T);

        // 1) 프로퍼티에서 찾기 (대소문자 무시)
        var prop = type.GetProperty(
            keyColumnName,
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase
        );
        if (prop != null && prop.PropertyType == typeof(uint))
            return obj => (uint)prop.GetValue(obj);

        // 2) 필드에서 찾기 (대소문자 무시)
        var field = type.GetField(
            keyColumnName,
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase
        );
        if (field != null && field.FieldType == typeof(uint))
            return obj => (uint)field.GetValue(obj);

        throw new Exception(
            $"'{type.Name}' 타입에 '{keyColumnName}'(uint) 프로퍼티/필드가 없습니다.");
    }

    private static object ConvertField(string raw, Type fieldType)
    {
        // 1. "-"나 공백 문자열 → null 또는 기본값 처리
        if (string.IsNullOrWhiteSpace(raw) || raw == "-")
        {
            if (fieldType == typeof(string))
                return string.Empty;

            if (Nullable.GetUnderlyingType(fieldType) != null)
                return null;

            return Activator.CreateInstance(fieldType);
        }

        // 2. Enum 처리
        if (fieldType.IsEnum)
            return ParseEnum(fieldType, raw);

        // 3. 일반 기본 타입 처리
        try
        {
            Type targetType = Nullable.GetUnderlyingType(fieldType) ?? fieldType;
            return Convert.ChangeType(raw, targetType);
        }
        catch (Exception ex)
        {
            Debug.LogError($"[변환 실패] raw: '{raw}', type: {fieldType.Name} → {ex.Message}");
            throw;
        }
    }

    private static object ParseEnum(Type enumType, string raw)
    {
        try
        {
            // 이름 기반 파싱
            return Enum.Parse(enumType, raw, ignoreCase: true);
        }
        catch
        {
            // 숫자 문자열 기반 파싱
            var underlyingType = Enum.GetUnderlyingType(enumType);
            var numericValue = Convert.ChangeType(raw, underlyingType);
            return Enum.ToObject(enumType, numericValue);
        }
    }
}