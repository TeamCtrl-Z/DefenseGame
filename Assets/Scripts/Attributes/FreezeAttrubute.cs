using System;
using UnityEngine;

/// <summary>
/// 얼음 속성
/// </summary>
[CreateAssetMenu(fileName = "FreezeAttribute", menuName = "Attribute/FreezeAttribute")]
public class FreezeAttribute : AttributeBase, IOnHitEffect
{
    /// <summary>
    /// 얼음 속성 피격 데이터 배열 
    /// </summary>
    [SerializeField] private HittingData[] attributeDatas;
    
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
        int maxIdx = attributeDatas.Length - 1;
        int idx = Mathf.Clamp(freezeStatck, 0, maxIdx);

        HittingData data = attributeDatas[idx];
        dmg.OnDamage(user, data);
    }
}