using System;
using UnityEngine;

[CreateAssetMenu(fileName = "FireAttribute", menuName = "Attribute/FireAttribute")]
public class FireAttribute : AttributeBase, IOnHitEffect
{
    /// <summary>
    /// 스플래시 데미지 범위
    /// </summary>
    public float Radius;

    /// <summary>
    /// 불속성 공격 데이터
    /// </summary>
    public HittingData data;

    private Collider2D[] cols = new Collider2D[16];
    
    public void OnHit(IDamagable damagable, Vector3 origin)
    {
        Debug.Log($"FireAttribute : OnHit {origin}");
        FireExplosion fire = Factory.Instance.GetFireExplosion(origin);

        int cnt = Physics2D.OverlapCircleNonAlloc(origin, Radius, cols, LayerMask.GetMask("Enemy"));

        for (int i = 0; i < cnt; i++)
        {
            if (cols[i].TryGetComponent<IDamagable>(out IDamagable target))
            {
                if (damagable == target) continue;

                target.OnDamage(user.gameObject, data);
            }
        }
    }
}