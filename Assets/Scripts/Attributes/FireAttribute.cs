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

    public override void Initialize(GameObject user)
    {
        base.Initialize(user);
    }

    
    public void OnHit(IDamagable damagable, Vector3 origin)
    {
        Debug.Log("FireAttribute : OnHit");
        WireCircleMarker marker = Factory.Instance.GetWireCircleMarker(origin);
        marker.transform.localScale *= Radius;

        Collider2D[] cols = Physics2D.OverlapCircleAll(origin, Radius, LayerMask.GetMask("Enemy"));

        foreach (Collider2D col in cols)
        {
            if (col.TryGetComponent<IDamagable>(out IDamagable target))
            {
                if (damagable == target) continue;

                target.OnDamage(user.gameObject, data);
            }
        }
    }
}