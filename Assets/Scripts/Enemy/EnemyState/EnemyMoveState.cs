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
    /// <param name="stateMachine">Enemy의 StateMachine</param>
    public EnemyMoveState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    /// <summary>
    /// Enemy의 Move 상태에 들어가면 실행되는 함수
    /// </summary>
    /// <param name="sender">Enemy의 Controller</param>
    public override void Enter(EnemyController sender)
    {
        base.Enter(sender);
    }

    /// <summary>
    /// Enemy의 Move 상태 중에 매 프레임 실행되는 함수
    /// </summary>
    /// <param name="sender">Enemy의 Controller</param>
    public override void UpdateState(EnemyController sender)
    {
        base.UpdateState(sender);

        float speed = sender.StatusComponent.MoveSpeed;
        stateMachine.Rigidbody.velocity = new Vector2(-speed, 0f);

        if (stateMachine.BlockComponent.IsBlocked)
        {
            stateMachine.TransitionTo(stateMachine.Attack);
        }
    }

    /// <summary>
    /// Enemy의 Move 상태가 끝나면 실행되는 함수
    /// </summary>
    /// <param name="sender">Enemy의 Controller</param>
    public override void Exit(EnemyController sender)
    {
        base.Exit(sender);
    }
}