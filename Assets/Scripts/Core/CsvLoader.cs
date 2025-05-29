using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class CsvLoader
{
    /// <summary>
    /// Resources/Data/CSVs/{resourceName}.csv �� �о
    /// ù ��° ��� �÷��� int Ű�� ����ϰ�,
    /// ������ �÷��� T�� ������Ƽ/�ʵ忡 �ڵ� �����Ͽ�
    /// Dictionary<int,T>�� ��ȯ�մϴ�.
    /// </summary>
    public static Dictionary<int, T> LoadTable<T>(string resourceName) where T : new()
    {
        // 1) CSV �ؽ�Ʈ �ε�
        var ta = Resources.Load<TextAsset>($"Data/{resourceName}");
        if (ta == null)
            throw new Exception($"CSV '{resourceName}.csv' �� Resources/Data/CSVs ���� ã�� �� �����ϴ�.");

        // 2) ��ü ���� �и� (������/���н� ���� ��� ����)
        var lines = ta.text
            .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        if (lines.Length < 2)
            throw new Exception("CSV���� ��� + �ּ� 1�� �̻��� ������ ���� �ʿ��մϴ�.");

        // 3) ����� �÷��� �迭 ����
        var headers = lines[0].Split(',').Select(h => h.Trim()).ToArray();
        var keyColumnName = headers[0];      // ù ��° �÷� �̸��� Ű�� ���

        // 4) T Ÿ���� public ������Ƽ���ʵ� ��Ÿ���� ĳ��
        var type = typeof(T);
        var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);

        // 5) ������ �ึ�� T �ν��Ͻ� ���� & �� ä���
        var list = new List<T>();
        for (int i = 1; i < lines.Length; i++)
        {
            var cols = lines[i].Split(',');
            var obj = new T();

            for (int c = 0; c < headers.Length && c < cols.Length; c++)
            {
                var header = headers[c];
                var raw = cols[c].Trim();

                // ������Ƽ �켱
                var prop = props.FirstOrDefault(p => p.Name.Equals(header, StringComparison.OrdinalIgnoreCase));
                if (prop != null && prop.CanWrite)
                {
                    var val = Convert.ChangeType(raw, prop.PropertyType);
                    prop.SetValue(obj, val);
                    continue;
                }

                // �ʵ� üũ
                var field = fields.FirstOrDefault(f => f.Name.Equals(header, StringComparison.OrdinalIgnoreCase));
                if (field != null)
                {
                    var val = Convert.ChangeType(raw, field.FieldType);
                    field.SetValue(obj, val);
                }
            }

            list.Add(obj);
        }

        // 6) Ű ���� ������ ��������Ʈ ����
        Func<T, int> getKey = CreateKeyGetter<T>(keyColumnName);

        // 7) Dictionary ���� �� ��ȯ
        return list.ToDictionary(getKey);
    }

    // ù ��° ���(Ű �÷�) �̸��� �޾� T���� �ش� int ���� ������ Func<T,int> ����
    private static Func<T, int> CreateKeyGetter<T>(string keyColumnName) where T : new()
    {
        var type = typeof(T);

        // ������Ƽ �˻�
        var prop = type.GetProperty(
            keyColumnName,
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase
        );
        if (prop != null && prop.PropertyType == typeof(int))
            return obj => (int)prop.GetValue(obj);

        // �ʵ� �˻�
        var field = type.GetField(
            keyColumnName,
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase
        );
        if (field != null && field.FieldType == typeof(int))
            return obj => (int)field.GetValue(obj);

        throw new Exception($"Ÿ�� '{type.Name}'�� '{keyColumnName}' (int) ������Ƽ/�ʵ尡 �����ϴ�.");
    }
}