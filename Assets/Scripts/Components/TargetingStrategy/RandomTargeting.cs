using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 무작위 타겟팅
/// </summary>
[CreateAssetMenu(fileName = "RandomTargeting", menuName = "Targeting/RandomTargeting")]
public class RandomTargeting : TargetingStrategyData
{
    public override Transform SelectTarget(Transform origin, IEnumerable<ITargetable> enemies)
    {
        List<ITargetable> enemyList = new List<ITargetable>(enemies);
        if (enemyList.Count == 0) return null;

        int randomIndex = UnityEngine.Random.Range(0, enemyList.Count);
        return enemyList[randomIndex].Transform;
    }
}