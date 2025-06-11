using UnityEngine;

/// <summary>
/// 근접 공격 클래스
/// </summary>
public class MeleeAttack : AttackBase
{
    /// <summary>
    /// 공격에 사용될 Melee 고유 아이디
    /// </summary>
    private uint meleeId;

    /// <summary>
    /// MeleeAttack 클래스 생성자
    /// </summary>
    /// <param name="data">공격 HittingData</param>
    /// <param name="attacker">공격하는 오브젝트</param>
    /// <param name="meleeId">공격에 사용될 Melee 아이디</param>
    public MeleeAttack(HittingData data, EntityController attacker, uint meleeId) : base(data, attacker)
    {
        this.meleeId = meleeId;
    }

    /// <summary>
    /// 근접 공격을 소환하여 적을 공격하는 함수
    /// </summary>
    /// <param name="target">공격당하는 오브젝트</param>
    public override void DoAttack(Transform target)
    {
        Melee melee = Factory.Instance.GetMelee(target.position);
        melee.OnHit += NotifyOnHit;
        melee.onDisable += () => melee.OnHit -= NotifyOnHit;
    }
}
