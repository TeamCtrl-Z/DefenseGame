using UnityEngine;

[CreateAssetMenu(fileName = "DamageEffect", menuName = "Abilities/Effects/DamageEffect")]
public class DamageEffectData : AbilityEffectData
{
    private HittingData data;

    public override void Initialize(HittingData data)
    {
        this.data = data;
    }

    public override void Apply(GameObject executer, GameObject target)
    {
        if (target.TryGetComponent<IDamagable>(out IDamagable damagable))
        {
            damagable.OnDamage(executer, data);
        }
    }
}