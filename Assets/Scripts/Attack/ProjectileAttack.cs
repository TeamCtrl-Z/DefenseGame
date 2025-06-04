using UnityEngine;

/// <summary>
/// 투사체로 공격하는 클래스
/// </summary>
public class ProjectileAttack : AttackBase
{
    /// <summary>
    /// 공격에 사용될 투사체
    /// </summary>
    [SerializeField] private GameObject projectilePrefab;

    public ProjectileAttack(ProjectileAttackData soData, FairyController attacker) : base(soData, attacker)
    {
        if (soData.ProjectilePrefab != null)
            projectilePrefab = soData.ProjectilePrefab;
    }

    /// <summary>
    /// 투사체를 소환하여 적을 공격하는 함수
    /// </summary>
    /// <param name="target"></param>
    public override void DoAttack(Transform target)
    {
        Debug.Log(attacker);
        Projectile projectile = Factory.Instance.GetProjectile(attacker.transform.position);
        projectile.OnHit += NotifyOnHit;
        projectile.onDisable += () => projectile.OnHit -= NotifyOnHit;
        projectile.Shoot(target);
    }
}