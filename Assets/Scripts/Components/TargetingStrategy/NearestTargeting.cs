using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 가장 가까운 타겟 선택
/// </summary>
[CreateAssetMenu(fileName = "NearestTargeting", menuName = "Targeting/NearestTargeting")]
public class NearestTargeting : TargetingStrategyData
{
    /// <summary>
    /// 가장 가까운 적을 고르는 함수
    /// </summary>
    /// <param name="origin"> 페어리 위치 </param>
    /// <param name="enemies"> 적 후보군들 </param>
    /// <returns> 적 Transform </returns>
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
    
    /// <summary>
    /// 가까운 순으로 적들을 고르는 함수
    /// </summary>
    /// <param name="origin"> 페어리 위치 </param>
    /// <param name="enemies"> 적 후보군 </param>
    /// <param name="count"> 몇 명 </param>
    /// <returns> 적 Transform Lsit </returns>
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