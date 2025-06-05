using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class AttributeFactory
{
    /// <summary>
    /// 불러온 FairyAttributeData를 가지고 Attribute 클래스 생성
    /// </summary>
    /// <param name="data"> FairyAttributeData </param>
    /// <param name="user"> 속성 소유자(페어리) </param>
    /// <returns>Attribute 클래스</returns>
    public static AttributeBase CreateAttribute(FairyAttributeData data, GameObject user)
    {
        if ((FairyType)data.FID == FairyType.Basic || (FairyType)data.FID == FairyType.Light)
            return null;

        var type = FairyTypeToType((FairyType)data.FID);
        var attr = Activator.CreateInstance(type) as AttributeBase;

        // 리플렉션으로 value1~3 필드를 자동 할당
        var binding = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        var val1Field = type.GetField("value1", binding);
        var val2Field = type.GetField("value2", binding);
        var val3Field = type.GetField("value3", binding);

        val1Field?.SetValue(attr, data.value1);
        val2Field?.SetValue(attr, data.value2);
        val3Field?.SetValue(attr, data.value3);

        // user 정보 넘기기
        attr.Initialize(user);

        return attr;
    }

    private static readonly Dictionary<FairyType, Type> _map = new Dictionary<FairyType, Type>
    {
        { FairyType.Fire,       typeof(FireAttribute) },
        { FairyType.Poison,     typeof(PoisonAttribute) },
        { FairyType.Freeze,     typeof(FreezeAttribute) },
        { FairyType.Electronic, typeof(ElectronicAttribute) },
        { FairyType.Frozen, typeof(FrozenAttribute)},
    };

    private static Type FairyTypeToType(FairyType t)
    {
        return _map.TryGetValue(t, out var result) ? result : typeof(AttributeBase);
    }
}