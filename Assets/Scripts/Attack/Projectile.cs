using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private new Rigidbody2D rigidbody;
    private Transform target;
    public event Action<IDamagable, Vector3> OnHit;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Transform target)
    {
        Vector2 direction = target.position - transform.position;
        this.target = target;
        rigidbody.velocity = direction.normalized * speed;
        DisableTimer(lifetime);
    }

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