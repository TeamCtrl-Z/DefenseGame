using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 타겟팅을 사용 X (Null 패턴)
/// </summary>
[CreateAssetMenu(fileName = "NoneTargeting", menuName = "Targeting/NoneTargeting")]
public class NoneTargeting : TargetingStrategyData
{
    public override Transform SelectTarget(Transform origin, IEnumerable<ITargetable> enemies)
    {
        return null;
    }
}