using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileAttack", menuName = "Attack/ProjectileAttack")]
public class ProjectileAttack : AttackBase
{
    /// <summary>
    /// 공격에 사용될 투사체
    /// </summary>
    [SerializeField] private Projectile projectile;

    public override void DoAttack(Transform target)
    {
        projectile = Factory.Instance.GetProjectile(attacker.transform.position);
        projectile.OnHit += NotifyOnHit;
        projectile.onDisable += () => projectile.OnHit -= NotifyOnHit;
        projectile.Shoot(target);
    }
}