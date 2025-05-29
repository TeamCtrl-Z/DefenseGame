using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FireAttack", menuName = "Attack/FireAttack")]
public class FireAttack : AttackBase
{
    /// <summary>
    /// 스플래시 범위
    /// </summary>
    public float Radius;


    public override void Initialize(FairyController attacker)
    {
        this.attacker = attacker;
    }

    protected override void OnHit(IDamagable dmg, Vector3 origin)
    {
        base.OnHit(dmg, origin);
        WireCircleMarker marker = Factory.Instance.GetWireCircleMarker(origin);
        marker.transform.localScale *= Radius;

        Collider2D[] cols = Physics2D.OverlapCircleAll(origin, Radius, LayerMask.GetMask("Enemy"));

        foreach (Collider2D col in cols)
        {
            if (col.TryGetComponent<IDamagable>(out IDamagable target))
            {
                if (dmg == target) continue;

                target.OnDamage(attacker.gameObject, data);
            }
        }
    }
}