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
    /// 공격에 사용될 투사체
    /// </summary>
    private Projectile projectile;

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

    public virtual void DoAttack(Transform target)
    {
        projectile = Factory.Instance.GetProjectile(attacker.transform.position);
        projectile.OnHit += OnHit;
        projectile.onDisable += () => projectile.OnHit -= OnHit;
        projectile.Shoot(target);
    }

    /// <summary>
    /// 투사체로 적을 공격했을 때 호출되는 이벤트 함수
    /// </summary>
    /// <param name="dmg"></param>
    /// <param name="origin"></param>
    protected virtual void OnHit(IDamagable dmg, Vector3 origin)
    {
        dmg.OnDamage(attacker.gameObject, data);
    }
}
