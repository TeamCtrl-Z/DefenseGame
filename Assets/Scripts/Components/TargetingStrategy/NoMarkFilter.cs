using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 상태 이상 종류(이름 바꾸기)
/// </summary>
[Serializable]
public enum DebuffType { None = 0, Poison, Freeze, Max}

[CreateAssetMenu(fileName = "NoMarkFilter", menuName = "Targeting/Filter/NoMarkFilter")]
public class NoMarkFilter : TargetFilterData
{
    public DebuffType DebuffType;
    public override IEnumerable<ITargetable> Filter(IEnumerable<ITargetable> enemies) => enemies.Where(e =>
    {
        IStatusEffectProvider statusEf = e.GetStatusEffectProvider();
        if (statusEf == null)
        {
            Debug.LogError($"NoMarkFilter: 대상이 IStatusEffectProvider를 구현하지 않았습니다. 대상 타입: {e.GetType()}");
            return false;
        }
        return statusEf.GetStackCount(DebuffType) == 0;
    });
}