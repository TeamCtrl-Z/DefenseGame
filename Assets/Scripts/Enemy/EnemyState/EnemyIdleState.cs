using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine)
    {}

    public override void Enter(EnemyController sender)
    {
        base.Enter(sender);

        stateMachine.Rigidbody.velocity = Vector2.zero;
    }

    public override void UpdateState(EnemyController sender)
    {
        base.UpdateState(sender);
        if (stateMachine.BlockComponent.IsBlocked == false)
        {
            stateMachine.TransitionTo(stateMachine.Move);
        }
    }

    public override void Exit(EnemyController sender)
    {
        base.Exit(sender);
    }
}
