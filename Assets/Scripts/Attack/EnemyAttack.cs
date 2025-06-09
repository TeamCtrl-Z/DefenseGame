using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 적의 공격
/// </summary>
public abstract class EnemyAttack : IAttack
{
    /// <summary>
    /// 공격하는 적
    /// </summary>
    protected EnemyController attacker;

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
    /// <param name="attacker"></param>
    protected EnemyAttack(EnemyAttackData soData, EnemyController attacker)
    {
        data = soData.data;
        this.attacker = attacker;
    }

    /// <summary>
    /// 공격하는 함수
    /// </summary>
    /// <param name="target">공격하는 대상</param>
    public abstract void DoAttack(Transform target);

    /// <summary>
    /// 공격을 하는 주체가 공격했을 때 발동되는 이벤트 함수
    /// </summary>
    /// <param name="dmg">공격 받는 오브젝트</param>
    /// <param name="origin">공격 받는 위치</param>
    protected virtual void NotifyOnHit(IDamageable dmg, Vector3 origin)
    {
        Debug.Log(this.GetType() + $" : OnHit");
        dmg.OnDamage(attacker.gameObject, data);
        OnHit?.Invoke(dmg, origin);
    }
}
