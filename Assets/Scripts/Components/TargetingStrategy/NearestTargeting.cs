using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 가장 가까운 타겟 선택
/// </summary>
[CreateAssetMenu(fileName = "NearestTargeting", menuName = "Targeting/NearestTargeting")]
public class NearestTargeting : TargetingStrategyData
{
    /// <summary>
    /// Fariy 위치
    /// </summary>
    //private Transform origin;
    //public NearestTargeting(Transform origin) => this.origin = origin;
    public override Transform SelectTarget(Transform origin, IEnumerable<ITargetable> enemies)
    {
        Transform nearest = null;
        float minDistance = float.MaxValue;

        foreach (var enemy in enemies)
        {
            float distance = Vector2.Distance(origin.position, enemy.Transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = enemy.Transform;
            }
        }
        return nearest;
    }
}