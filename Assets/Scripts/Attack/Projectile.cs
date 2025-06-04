using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 투사체 클래스
/// </summary>
public class Projectile : RecycleObject
{
    /// <summary>
    /// Projectile의 속도
    /// </summary>
    [SerializeField] private float speed = 30f;

    /// <summary>
    /// Projectile의 생명주기
    /// </summary>
    [SerializeField] private float lifetime = 5f;

    /// <summary>
    /// 물리를 사용하기 위한 Rigidbody
    /// </summary>
    private new Rigidbody2D rigidbody;

    /// <summary>
    /// 공격할 타겟
    /// </summary>
    private Transform target;

    /// <summary>
    /// 적을 공격했을 때 호출하는 이벤트
    /// </summary>
    public event Action<IDamagable, Vector3> OnHit;

    protected override void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// 투사체 발사 함수
    /// </summary>
    /// <param name="target">공격할 대상</param>
    public void Shoot(Transform target)
    {
        Vector2 direction = target.position - transform.position;
        this.target = target;
        rigidbody.velocity = direction.normalized * speed;
        DisableTimer(lifetime);
    }

    /// <summary>
    /// 투사체가 타겟에 닿았을 때 호출되는 함수
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform != target)
            return;

        if (collision.TryGetComponent<IDamagable>(out IDamagable dmg))
        {
            OnHit?.Invoke(dmg, transform.position);
            gameObject.SetActive(false);
        }
    }
}