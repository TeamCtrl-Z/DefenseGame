using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 가장 체력 많은 적 타겟팅
/// </summary>
[CreateAssetMenu(fileName = "HealthiestTargeting", menuName = "Targeting/HealthiestTargeting")]
public class HealthiestTargeting : TargetingStrategyData
{
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
}