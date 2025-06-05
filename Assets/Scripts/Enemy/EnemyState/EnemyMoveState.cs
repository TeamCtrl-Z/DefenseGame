using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy의 Move 상태 클래스
/// </summary>
public class EnemyMoveState : EnemyBaseState
{
    /// <summary>
    /// EnemyMoveState 생성자
    /// </summary>
    /// <param name="stateMachine">EnemyStateMachine</param>
    public EnemyMoveState(EnemyStateMachine stateMachine) : base(stateMachine)
    {}

    /// <summary>
    /// Enemy 상태에 들어갈 때 호출되는 함수
    /// </summary>
    /// <param name="sender">EnemyController</param>
    public override void Enter(EnemyController sender)
    {
        base.Enter(sender);
    }

    /// <summary>
    /// Enemy 상태 중일 때 매 프레임마다 호출되는 함수
    /// </summary>
    /// <param name="sender">EnemyController</param>
    public override void UpdateState(EnemyController sender)
    {
        base.UpdateState(sender);

        float speed = sender.StatusComponent.MoveSpeed;
        stateMachine.Rigidbody.velocity = new Vector3(-speed, 0.0f);
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

    /// <summary>
    /// Enemy 상태에서 벗어날 때 호출되는 함수
    /// </summary>
    /// <param name="sender">EnemyController</param>
    public override void Exit(EnemyController sender)
    {
        base.Exit(sender);
    }
}
