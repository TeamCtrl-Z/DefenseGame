using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PoisonAttack", menuName = "Attack/PoisonAttack")]
public class PoisonAttack : AttackBase
{
    /// <summary>
    /// 데미지 몇초에 한번씩 줄지
    /// </summary>
    public float Term;
    
    protected override void OnHit(IDamagable dmg, Vector3 origin)
    {
        dmg.OnDotDamage(attacker.gameObject, data, Term);
    }
}
