using UnityEngine;

public abstract class AbilityEffectData : ScriptableObject, IAbilityEffect
{
    public abstract void Initialize(HittingData data);
    public abstract void Apply(GameObject executer, GameObject target);
}