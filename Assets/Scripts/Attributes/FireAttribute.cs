using System;
using UnityEngine;

/// <summary>
/// 불 속성
/// </summary>
public class FireAttribute : AttributeBase, IOnHitEffect
{
    /// <summary>
    /// 스플래시 데미지 범위
    /// </summary>
    public const float Radius = 2.0f;

    /// <summary>
    /// 불속성 공격 데이터
    /// </summary>
    public HittingData data;

    /// <summary>
    /// 스플래시 데미지를 받을 적 후보군들 캐싱을 위한 Collider 배열
    /// </summary>
    private Collider2D[] cols = new Collider2D[16];

    /// <summary>
    /// 초기화
    /// </summary>
    /// <param name="user"></param>
    public override void Initialize(GameObject user)
    {
        base.Initialize(user);

        data = new HittingData { Damage = value1 };
    }
    
    /// <summary>
    /// 몬스터가 피격 당했을 때 스플래시 데미지 적용하는 함수
    /// </summary>
    /// <param name="damagable"> 피격 당한 적 </param>
    /// <param name="origin"> 피격 당한 위치 </param>
    public void OnHit(IDamageableWithDebuff damagable, Vector3 origin)
    {
        Debug.Log($"FireAttribute : OnHit {origin}");
        Factory.Instance.GetFireExplosion(origin);

        int cnt = Physics2D.OverlapCircleNonAlloc(origin, Radius, cols, LayerMask.GetMask("Enemy"));

        for (int i = 0; i < cnt; i++)
        {
            if (cols[i].TryGetComponent<IDamageable>(out IDamageable target))
            {
                if (damagable == target) continue;

                target.OnDamage(user.gameObject, data);
            }
        }
    }
}