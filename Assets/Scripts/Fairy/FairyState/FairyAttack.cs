using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyAttack : FairyBase
{
    public FairyAttack(FairyStateMachine stateMachine) : base(stateMachine)
    {}

    public override void Enter(FairyController sender)
    {
        base.Enter(sender);
        stateMachine.Animator.SetTrigger(AnimatorHash.Fairy.AttackTrigger);
        //stateMachine.AttackHandler.DoAttack(sender.TargetTransform);
    }

    public override void UpdateState(FairyController sender)
    {
        base.UpdateState(sender);
    }

    public override void Exit(FairyController sender)
    {
        base.Exit(sender);
    }
}
