using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 가장 가까운 타겟 선택
/// </summary>
[CreateAssetMenu(fileName = "NearestTargeting", menuName = "Targeting/NearestTargeting")]
public class NearestTargeting : TargetingStrategyData
{
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
    
    public override List<Transform> SelectTargets(Transform origin, IEnumerable<ITargetable> enemies, int count)
    {
        //가까운순으로 정렬한 뒤, count만큼 꺼내서 Transform배열로 반환
        return enemies
            .OrderBy(e => Vector2.Distance(origin.position, e.Transform.position))
            .Take(count)
            .Select(e => e.Transform)
            .ToList();
    }
}