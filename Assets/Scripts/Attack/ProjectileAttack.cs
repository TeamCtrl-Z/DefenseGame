using UnityEngine;

/// <summary>
/// 투사체로 공격하는 클래스
/// </summary>
public class ProjectileAttack : AttackBase
{
    /// <summary>
    /// 공격에 사용될 Projectile 고유 아이디
    /// </summary>
    private uint projectileId;

    /// <summary>
    /// ProjectileAttack 클래스 생성자
    /// </summary>
    /// <param name="data">공격 Hitting Data</param>
    /// <param name="attacker">공격하는 오브젝트</param>
    /// <param name="projectileId">공격에 사용될 프로젝타일 아이디</param>
    public ProjectileAttack(HittingData data, EntityController attacker, uint projectileId) : base(data, attacker)
    {
        this.projectileId = projectileId;
    }

    /// <summary>
    /// 투사체를 소환하여 적을 공격하는 함수
    /// </summary>
    /// <param name="target">공격당하는 오브젝트</param>
    public override void DoAttack(Transform target)
    {
        Debug.Log(attacker);

        // TODO : 추후에 projectile ID로 꺼내오는것으로 바꿔야함.
        Projectile projectile = Factory.Instance.GetProjectile(attacker.transform.position);
        projectile.OnHit += NotifyOnHit;
        projectile.onDisable += () => projectile.OnHit -= NotifyOnHit;
        projectile.Shoot(target);
    }
}