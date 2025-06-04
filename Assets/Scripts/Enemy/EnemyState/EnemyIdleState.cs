using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy의 Idle 상태클래스
/// </summary>
public class EnemyIdleState : EnemyBaseState
{
    /// <summary>
    /// EnemyIdleState 생성자
    /// </summary>
    /// <param name="stateMachine">EnemyStateMachine</param>
    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine)
    {}

    /// <summary>
    /// Enemy가 Idle 상태에 들어갈 때 호출되는 함수
    /// </summary>
    /// <param name="sender">EnemyController</param>
    public override void Enter(EnemyController sender)
    {
        base.Enter(sender);

        stateMachine.Rigidbody.velocity = Vector2.zero;
    }

    /// <summary>
    /// Enemy가 Idle 상태 중일 때 매 프레임마다 호출되는 함수
    /// </summary>
    /// <param name="sender">EnemyController</param>
    public override void UpdateState(EnemyController sender)
    {
        base.UpdateState(sender);
        if (stateMachine.BlockComponent.IsBlocked == false)
        {
            stateMachine.TransitionTo(stateMachine.Move);
        }
    }

    /// <summary>
    /// Enemy가 Idle 상태에서 벗어날 때 호출되는 함수
    /// </summary>
    /// <param name="sender">EnemyController</param>
    public override void Exit(EnemyController sender)
    {
        base.Exit(sender);
    }
}
