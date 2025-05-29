using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 기본 공격
/// </summary>
public class BasicAttack
{
    /// <summary>
    /// 기본 공격에 해당되는 피격 데이터
    /// </summary>
    private readonly HittingData data;

    /// <summary>
    /// 기본 공격에 사용될 투사체
    /// </summary>
    private Projectile projectile;

    /// <summary>
    /// 기본 공격자
    /// </summary>
    private Transform attacker;

    public event Action<GameObject, Vector3> OnHitEnemy;

    public BasicAttack(Transform attacker, HittingData data)
    {
        this.attacker = attacker;
        this.data = data;
    }

    /// <summary>
    /// 공격 실행
    /// </summary>
    /// <param name="target"> 공격할 대상 </param>
    public void DoAttack(Transform target)
    {
        projectile = Factory.Instance.GetProjectile(attacker.position);
        projectile.OnHit += OnHit;
        projectile.onDisable += () => projectile.OnHit -= OnHit;
        projectile.Shoot(target);
    }

    /// <summary>
    /// 피격자에게 피격 처리하는 메서드
    /// </summary>
    /// <param name="damagable"></param>
    private void OnHit(GameObject target, Vector3 hitPoint)
    {
        if (target.TryGetComponent<IDamagable>(out IDamagable damagable))
        {
            OnHitEnemy?.Invoke(target, hitPoint);
            damagable.OnDamage(attacker.gameObject, data);
        }
    }
}
