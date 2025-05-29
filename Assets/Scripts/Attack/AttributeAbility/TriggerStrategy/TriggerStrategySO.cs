using System;
using UnityEngine;

public abstract class TriggerStrategySO : ScriptableObject, ITriggerStrategy
{
    public event Action<GameObject> OnTrigger;
    public abstract void Initialize(BasicAttack basicAttack, AttackHandler handler, IAbilityEffect effect);
    public abstract void CleanUp(BasicAttack basicAttack, AttackHandler handler);

    protected void Trigger(GameObject obj)
    {
        OnTrigger?.Invoke(obj);
    }
}