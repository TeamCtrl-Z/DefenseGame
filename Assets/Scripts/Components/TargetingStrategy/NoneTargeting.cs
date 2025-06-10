using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 타겟팅을 사용 X (Null 패턴)
/// </summary>
[CreateAssetMenu(fileName = "NoneTargeting", menuName = "Targeting/NoneTargeting")]
public class NoneTargeting : TargetingStrategyBase
{
    /// <summary>
    /// 타겟을 고르는 함수(사용 X이므로 빈함수)
    /// </summary>
    public override Transform SelectTarget(Transform origin, IEnumerable<ITargetable> enemies)
    {
        return null;
    }

    /// <summary>
    /// 타겟들을 고르는 함수(사용 X이므로 빈함수)
    /// </summary>
    public override List<Transform> SelectTargets(Transform origin, IEnumerable<ITargetable> enemies, int count)
    {
        return null;
    }
}