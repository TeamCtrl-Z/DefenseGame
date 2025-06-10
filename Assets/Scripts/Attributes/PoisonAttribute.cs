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

    /// <summary>
    /// 초기화 함수
    /// </summary>
    /// <param name="user"> 속성 사용자 </param>
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
    public void OnHit(IDamageableWithDebuff dmg, Vector3 origin)
    {
        dmg.OnDamage(user, data);
    }
}