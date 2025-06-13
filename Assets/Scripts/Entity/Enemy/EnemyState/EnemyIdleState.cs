using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy의 Idle 상태클래스
/// </summary>
public class EnemyIdleState : EnemyBaseState
{
    /// <summary>
    /// Idle 상태에서 기다리는 시간
    /// </summary>
    private float m_waitTime = 0.0f;

    /// <summary>
    /// EnemyIdleState 생성자
    /// </summary>
    /// <param name="stateMachine">Enemy의 StateMachine</param>
    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    /// <summary>
    /// Enemy의 Idle 상태에 들어오면 실행되는 함수
    /// </summary>
    /// <param name="sender">Enemy의 Controller</param>
    public override void Enter(EnemyController sender)
    {
        base.Enter(sender);

        m_waitTime = stateMachine.BattleStatus.RealAttackSpeed;

    }

    /// <summary>
    /// Enemy의 Idle 상태 중에 매 프레임 실행되는 함수
    /// </summary>
    /// <param name="sender">Enemy의 Controller</param>
    public override void UpdateState(EnemyController sender)
    {
        base.UpdateState(sender);

        m_waitTime -= Time.deltaTime;

        if (m_waitTime < 0.0f)
        {
            stateMachine.TransitionTo(stateMachine.Attack);
        }
    }

    /// <summary>
    /// Enemy의 Idle 상태가 끝나면 실행되는 함수
    /// </summary>
    /// <param name="sender">Enemy의 Controller</param>
    public override void Exit(EnemyController sender)
    {
        base.Exit(sender);
    }
}
