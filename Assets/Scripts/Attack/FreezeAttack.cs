
using UnityEngine;

[CreateAssetMenu(fileName = "FreezeAttack", menuName = "Attack/FreezeAttack")]
public class FreezeAttack : AttackBase
{
    [SerializeField] private HittingData[] attributeDatas;
    protected override void OnHit(IDamagable dmg, Vector3 origin)
    {
        base.OnHit(dmg, origin);
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
        dmg.OnDamage(attacker.gameObject, data);
    }
}