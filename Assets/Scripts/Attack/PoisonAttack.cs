using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PoisonAttack", menuName = "Attack/PoisonAttack")]
public class PoisonAttack : AttackBase
{
    /// <summary>
    /// 속성 공격 데이터
    /// </summary>
    [SerializeField] private HittingData attributeData;

    /// <summary>
    /// 데미지 몇초에 한번씩 줄지
    /// </summary>
    public float Term;

    protected override void OnHit(IDamagable dmg, Vector3 origin)
    {
        base.OnHit(dmg, origin);

        dmg.OnDamage(attacker.gameObject, attributeData);
    }
}
