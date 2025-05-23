using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyBase
{
    public EnemyAttack(EnemyStateMachine stateMachine) : base(stateMachine)
    {}

    public override void Enter(EnemyController sender)
    {
        base.Enter(sender);
    }

    public override void UpdateState(EnemyController sender)
    {
        base.UpdateState(sender);
    }

    public override void Exit(EnemyController sender)
    {
        base.Exit(sender);
    }
}
