using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 원거리 공격 클래스
/// </summary>
public class RangedAttack : AttackBase
{
    /// <summary>
    /// 공격에 사용될 Ranged 고유 아이디
    /// </summary>
    private uint rangedId;

    /// <summary>
    /// RangedAttack 클래스 생성자
    /// </summary>
    /// <param name="data">공격 Hitting Data</param>
    /// <param name="attacker">공격하는 오브젝트</param>
    /// <param name="rangedId">공격에 사용될 랭지드 아이디</param>
    public RangedAttack(HittingData data, EntityController attacker, uint rangedId) : base(data, attacker)
    {
        this.rangedId = rangedId;
    }

    /// <summary>
    /// 투사체를 소환하여 적을 공격하는 함수
    /// </summary>
    /// <param name="target">오브젝트 생성 위치</param>
    public override void DoAttack(Transform target)
    {
        Debug.Log(attacker);

        // TODO : 추후에 projectile ID로 꺼내오는것으로 바꿔야함.
        Ranged ranged = Factory.Instance.GetArrow(attacker.transform.position);
        ranged.OnHit += NotifyOnHit;
        ranged.onDisable += () => ranged.OnHit -= NotifyOnHit;
    }
}
