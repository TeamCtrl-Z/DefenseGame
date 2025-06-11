using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

/// <summary>
/// 원거리 공격체 클래스
/// </summary>
public class Ranged : RecycleObject
{
    /// <summary>
    /// Projectile의 속도
    /// </summary>
    [SerializeField] private float speed = 20f;

    /// <summary>
    /// Projectile의 생명주기
    /// </summary>
    [SerializeField] private float lifetime = 5f;

    /// <summary>
    /// 물리를 사용하기 위한 Rigidbody
    /// </summary>
    private new Rigidbody2D rigidbody;

    /// <summary>
    /// 적을 공격했을 때 호출하는 이벤트
    /// </summary>
    public event Action<IDamageable, Vector3> OnHit;

    protected override void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// RecycleObject이 활성화 될때마다 실행되는 초기화 함수
    /// </summary>
    protected override void OnReset()
    {
        base.OnReset();
        rigidbody.velocity = Vector2.left * speed;
        DisableTimer(lifetime);
    }

    /// <summary>
    /// 투사체가 타겟에 닿았을 때 호출되는 함수
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out IDamageable dmg))
        {
            Vector2 pos = collision.ClosestPoint(transform.position);
            Factory.Instance.GetBoatHit(pos);
            OnHit?.Invoke(dmg, transform.position);
            gameObject.SetActive(false);
        }
    }
}
