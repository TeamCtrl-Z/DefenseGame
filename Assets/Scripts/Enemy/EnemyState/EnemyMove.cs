using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : EnemyBase
{
    public EnemyMove(EnemyStateMachine stateMachine) : base(stateMachine)
    {}

    public override void Enter(EnemyController sender)
    {
        base.Enter(sender);
        
        float speed = sender.MoveStatus.MoveSpeed;
        stateMachine.Rigidbody.velocity = new Vector3(-speed, 0.0f);
    }

    public override void UpdateState(EnemyController sender)
    {
        base.UpdateState(sender);

        Collider2D collider = Physics2D.OverlapCircle(sender.transform.position, 1.0f, 1 << 6);
        if (collider != null)
        {
            stateMachine.TransitionTo(stateMachine.Attack);
        }

        if (stateMachine.BlockComponent.IsBlocked)
        {
            stateMachine.TransitionTo(stateMachine.Idle);
        }
    }

    public override void Exit(EnemyController sender)
    {
        base.Exit(sender);
    }
}
