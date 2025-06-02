using UnityEngine;

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

    public override void DoAttack(Transform target)
    {
        Debug.Log(attacker);
        Projectile projectile = Factory.Instance.GetProjectile(attacker.transform.position);
        projectile.OnHit += NotifyOnHit;
        projectile.onDisable += () => projectile.OnHit -= NotifyOnHit;
        projectile.Shoot(target);
    }
}