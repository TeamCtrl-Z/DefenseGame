using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 가장 체력 많은 적 타겟팅
/// </summary>
public class HealthiestTargeting : TargetingStrategyBase
{  
    /// <summary>
    /// 가장 체력이 많은 적 고르는 함수
    /// </summary>
    /// <param name="origin"> 페어리 위치 </param>
    /// <param name="enemies"> 적 후보군들 </param>
    /// <returns></returns>
    public override Transform SelectTarget(Transform origin, IEnumerable<ITargetable> enemies)
    {
        Transform healthiest = null;
        float maxHealth = float.MinValue;

        foreach (var enemy in enemies)
        {
            float health = enemy.Transform.GetComponent<IHealthStatus>().CurrentHP;
            if (health > maxHealth)
            {
                maxHealth = health;
                healthiest = enemy.Transform;
            }
        }
        return healthiest;
    }

    /// <summary>
    /// 체력이 많은 순으로 적들 고르는 함수
    /// </summary>
    /// <param name="origin"> 페어리 위치 </param>
    /// <param name="enemies"> 적 후보군들 </param>
    /// <param name="count"> 몇 명 </param>
    /// <returns></returns>
    public override List<Transform> SelectTargets(Transform origin, IEnumerable<ITargetable> enemies, int count)
    {
        return enemies
            .OrderBy(e => e.Transform.GetComponent<IHealthStatus>().CurrentHP)
            .Take(count)
            .Select(e => e.Transform)
            .ToList();
    }
}