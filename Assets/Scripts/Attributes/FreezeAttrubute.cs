using System;
using UnityEngine;

[CreateAssetMenu(fileName = "FreezeAttribute", menuName = "Attribute/FreezeAttribute")]
public class FreezeAttribute : AttributeBase, IOnHitEffect
{
    [SerializeField] private HittingData[] attributeDatas;
    
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