using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBase : ScriptableObject, IAttack
{
    /// <summary>
    /// 공격하는 페어리
    /// </summary>
    protected FairyController attacker;

    /// <summary>
    /// 피격 데이터
    /// </summary>
    [SerializeField] protected HittingData data;

    /// <summary>
    /// 공격에 필요한 초기화
    /// </summary>
    /// <param name="attacker"></param>
    public virtual void Initialize(FairyController attacker)
    {
        this.attacker = attacker;
    }

    public abstract void DoAttack(Transform target);

    /// <summary>
    /// 외부에게 몬스터를 피격시켰다고 알려주는 이벤트
    /// </summary>
    public event Action<IDamagable, Vector3> OnHit;

    /// <summary>
    /// 공격을 하는 주체가 몬스터를 공격했을 때 발동되는 이벤트 함수
    /// </summary>
    /// <param name="dmg"></param>
    /// <param name="origin"></param>
    protected virtual void NotifyOnHit(IDamagable dmg, Vector3 origin)
    {
        Debug.Log(this.GetType() + " : OnHit");
        dmg.OnDamage(attacker.gameObject, data);
        OnHit?.Invoke(dmg, origin);
    }
}
