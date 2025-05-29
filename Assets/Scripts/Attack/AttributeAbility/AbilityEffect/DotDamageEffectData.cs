using UnityEngine;

[CreateAssetMenu(fileName = "DotDamageEffectData", menuName = "Abilities/Effects/DotDamageEffectData")]
public class DotDamageEffectData : AbilityEffectData
{
    /// <summary>
    /// Damage를 몇초마다 줄 지
    /// </summary>
    public float Term;
    private HittingData data;

    public override void Initialize(HittingData data)
    {
        this.data = data;
    }

    public override void Apply(GameObject executer, GameObject target)
    {
        if (target.TryGetComponent<IDamagable>(out IDamagable dmg))
        {
            dmg.OnDotDamage(executer, data, Term);
        }
    }

}