using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/AttributeAbility")]
public class AttributeAbility : ScriptableObject
{
    [Header("발동 전략")]
    public TriggerStrategySO triggerStrategy;
    [Header("타겟 선정")]
    public TargetScopeDefinition targetScopeDefinition;
    [Header("발동 시 실행될 효과")]
    public AbilityEffectData effect;
    private GameObject executer;

    public void Initialize(BasicAttack basicAttack, AttackHandler handler, HittingData data)
    {
        triggerStrategy.OnTrigger += OnTrigger;
        executer = handler.gameObject;

        effect.Initialize(data);
        triggerStrategy.Initialize(basicAttack, handler, effect);
    }

    private void OnTrigger(GameObject origin)
    {
        var targets = targetScopeDefinition.SelectTargets(origin);
        var obj = Factory.Instance.GetWireCircleMarker(origin.transform.position);
        foreach (var target in targets)
        {
            effect.Apply(executer, target);
        }
    }

    public void Cleanup(BasicAttack basicAttack, AttackHandler handler)
    {
        triggerStrategy.CleanUp(basicAttack, handler);
    }
}