using System;
using UnityEngine;

/// <summary>
/// 얼음 속성
/// </summary>
public class FreezeAttribute : AttributeBase, IOnHitEffect
{
    /// <summary>
    /// 얼음 속성 피격 데이터 배열 
    /// </summary>
    public HittingData[] data;
    public readonly float[] SlowRatio = { 0.1f, 0.3f };
    public const int MaxDebuffCount = 3;
    private const float MaxSlowRatio = 0.5f;

    public override void Initialize(GameObject user)
    {
        base.Initialize(user);

        data = new HittingData[3]
        {
            new HittingData{Damage = value1, Debuff = DebuffType.Freeze},
            new HittingData{Damage = value1 + SlowRatio[0], Debuff = DebuffType.Freeze},
            new HittingData{Damage = value1 + SlowRatio[1], Debuff = DebuffType.Freeze},
        };
    }

    /// <summary>
    /// 몬스터가 피격당했을 때 슬로우 디버프를 걸어주는 함수
    /// </summary>
    /// <param name="dmg"> 피격당한 적 </param>
    /// <param name="origin"> 피격당한 위치 </param>
    public void OnHit(IDamagable dmg, Vector3 origin)
    {
        IStatusEffectProvider statusEf = dmg.GetStatusEffectProvider();
        if (statusEf == null)
        {
            Debug.LogError($"FreezeAttack: 대상이 IStatusEffectProvider를 구현하지 않았습니다. 대상 타입: {dmg.GetType()}");
            return;
        }

        int freezeStatck = statusEf.GetStackCount(DebuffType.Freeze);
        int cnt = Mathf.Clamp(freezeStatck, 0, MaxDebuffCount - 1);
        data[cnt].Damage = Mathf.Min(data[cnt].Damage, MaxSlowRatio);
        dmg.OnDamage(user, data[cnt]);
    }
}