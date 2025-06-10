using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 공격 추상 클래스
/// </summary>
public abstract class AttackBase : IAttack
{
    /// <summary>
    /// 공격하는 엔티티
    /// </summary>
    protected EntityController attacker;

    /// <summary>
    /// 피격 데이터
    /// </summary>
    protected HittingData data;

    /// <summary>
    /// 외부에게 몬스터를 피격시켰다고 알려주는 이벤트
    /// </summary>
    public event Action<IDamageable, Vector3> OnHit;

    /// <summary>
    /// 공격에 필요한 초기화
    /// </summary>
    /// <param name="data">피격 데이터</param>
    /// <param name="attacker">공격자</param>
    protected AttackBase(HittingData data, EntityController attacker)
    {
        this.data = data;
        this.attacker = attacker;
    }

    /// <summary>
    /// 공격하는 함수(추상 메소드)
    /// </summary>
    /// <param name="target">공격하는 대상</param>
    public abstract void DoAttack(Transform target);

    /// <summary>
    /// 공격을 하는 주체가 공격했을 때 발동되는 이벤트 함수
    /// </summary>
    /// <param name="dmg"></param>
    /// <param name="origin"></param>
    protected virtual void NotifyOnHit(IDamageable dmg, Vector3 origin)
    {
        Debug.Log(this.GetType() + " : OnHit");
        dmg.OnDamage(attacker.gameObject, data);
        OnHit?.Invoke(dmg, origin);
    }
}
