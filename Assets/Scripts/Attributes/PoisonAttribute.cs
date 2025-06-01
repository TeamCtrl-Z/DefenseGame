using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PoisonAttribute", menuName = "Attribute/PoisonAttribute")]
public class PoisonAttribute : AttributeBase, IOnHitEffect
{
    public HittingData data;

    public void OnHit(IDamagable dmg, Vector3 origin)
    {
        dmg.OnDamage(user, data);
    }
}