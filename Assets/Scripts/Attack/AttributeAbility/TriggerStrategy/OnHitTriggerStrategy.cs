using System;
using UnityEngine;

[CreateAssetMenu(fileName = "OnHitTrigger", menuName ="Abilities/Triggers/OnHitTriggerStrategy")]
public class OnHitTriggerStrategy : TriggerStrategySO
{
    public override void Initialize(BasicAttack basicAttack, AttackHandler handler, IAbilityEffect effect)
    {
        basicAttack.OnHitEnemy += handlingHit;
    }

    public override void CleanUp(BasicAttack basicAttack, AttackHandler handler)
    {
        basicAttack.OnHitEnemy -= handlingHit;
    }

    private void handlingHit(GameObject hit, Vector3 origin)
    {
        Trigger(hit);
    }
}