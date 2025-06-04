using System;
using UnityEngine;

/// <summary>
/// 독 속성
/// </summary>
public class PoisonAttribute : AttributeBase, IOnHitEffect
{
    /// <summary>
    /// 독 속성 피격 데이터
    /// </summary>
    public HittingData data;

    public override void Initialize(GameObject user)
    {
        base.Initialize(user);

        data = new HittingData { Damage = value1, Debuff = DebuffType.Poison };
    }

    /// <summary>
    /// 몬스터가 피격당했을 때 독 속성 데미지 적용
    /// </summary>
    /// <param name="dmg"></param>
    /// <param name="origin"></param>
    public void OnHit(IDamagable dmg, Vector3 origin)
    {
        dmg.OnDamage(user, data);
    }
}