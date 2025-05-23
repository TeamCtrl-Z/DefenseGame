using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 타겟팅 타입
/// </summary>
public enum TargetingType
{
    /// <summary>
    /// 가장 가까운 적
    /// </summary>
    Nearest,
    /// <summary>
    /// 랜덤
    /// </summary>
    Random,
    /// <summary>
    /// 가장 체력이 많은 적
    /// </summary>
    Healthiest,
}

#region TargetingStrategy
public interface ITargetingStrategy
{
    /// <summary>
    /// 타겟을 선택하는 함수
    /// </summary>
    /// <param name="enemies"> 타겟을 선정할 후보들 </param>
    /// <returns> 선정된 적 Transform </returns>
    public Transform SelectTarget(IEnumerable<EnemyController> enemies);
}

public class NearestTargeting : ITargetingStrategy
{
    /// <summary>
    /// Fariy 위치
    /// </summary>
    private Transform origin;
    public NearestTargeting(Transform origin) => this.origin = origin;
    public Transform SelectTarget(IEnumerable<EnemyController> enemies)
    {
        Transform nearest = null;
        float minDistance = float.MaxValue;

        foreach (var enemy in enemies)
        {
            float distance = Vector2.Distance(origin.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = enemy.transform;
            }
        }
        return nearest;
    }
}

public class RandomTargeting : ITargetingStrategy
{
    public Transform SelectTarget(IEnumerable<EnemyController> enemies)
    {
        List<EnemyController> enemyList = new List<EnemyController>(enemies);
        if (enemyList.Count == 0) return null;

        int randomIndex = Random.Range(0, enemyList.Count);
        return enemyList[randomIndex].transform;
    }
}

public class HealthiestTargeting : ITargetingStrategy
{
    public Transform SelectTarget(IEnumerable<EnemyController> enemies)
    {
        Transform healthiest = null;
        float maxHealth = float.MinValue;

        foreach (var enemy in enemies)
        {
            float health = enemy.GetComponent<IHealthStatus>().CurrentHP;
            if (health > maxHealth)
            {
                maxHealth = health;
                healthiest = enemy.transform;
            }
        }
        return healthiest;
    }
}
#endregion

public class TargetingComponent : MonoBehaviour
{
    // TODO: Status에 따로 추가할지 추후에 결정
    /// <summary>
    /// 공격 범위
    /// </summary>
    [field: Header("Battle Status")]
    [field: SerializeField] public float AttackRange { get; private set; }

    /// <summary>
    /// 캐릭터 ID를 가져오는 인터페이스
    /// </summary>
    private ICharacterIdentity characterIdentity;

    /// <summary>
    /// 사용할 타겟팅 전략
    /// </summary>
    private ITargetingStrategy targetingStrategy;

    private void Start()
    {
        characterIdentity = GetComponent<ICharacterIdentity>();
        FairyDataManager.Instance.TryGetTargetingType(characterIdentity.ID, out TargetingType type);
        targetingStrategy = type switch
        {
            TargetingType.Nearest => new NearestTargeting(transform),
            TargetingType.Random => new RandomTargeting(),
            TargetingType.Healthiest => new HealthiestTargeting(),
            _ => throw new System.NotImplementedException()
        };
    }

    /// <summary>
    /// 타겟을 가져오는 메서드
    /// </summary>
    /// <returns></returns>
    public Transform GetTarget()
    {
        var enemiesInRange = Physics2D.OverlapCircleAll(transform.position, AttackRange, LayerMask.GetMask("Enemy"))
            .Select(collider => collider.GetComponent<EnemyController>())
            .Where(enemy => enemy != null);

        return targetingStrategy.SelectTarget(enemiesInRange);
    }
}
