using UnityEngine;

/// <summary>
/// 적의 근접 공격 클래스
/// </summary>
public class EnemyMeleeAttack : EnemyAttack
{
    /// <summary>
    /// 공격에 사용될 투사체
    /// </summary>
    [SerializeField] private GameObject meleePrefab;

    /// <summary>
    /// EnemyMeleeAttack 클래스 생성자
    /// </summary>
    /// <param name="soData">공격 SO Data</param>
    /// <param name="attacker">공격하는 오브젝트</param>
    public EnemyMeleeAttack(MeleeAttackData soData, EnemyController attacker) : base(soData, attacker)
    {
        if (soData.MeleePrefab != null)
            meleePrefab = soData.MeleePrefab;
    }

    /// <summary>
    /// 근접 공격을 소환하여 적을 공격하는 함수
    /// </summary>
    /// <param name="target">공격당하는 오브젝트</param>
    public override void DoAttack(Transform target)
    {
        Melee melee = Factory.Instance.GetMelee(attacker.transform.position);
        melee.OnHit += NotifyOnHit;
        melee.onDisable += () => melee.OnHit -= NotifyOnHit;
    }
}
