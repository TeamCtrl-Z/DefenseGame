using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Fairy의 Idle 상태 클래스
/// </summary>
public class FairyIdle : FairyBase
{
    /// <summary>
    /// Idle 상태에서 기다리는 시간
    /// </summary>
    private float m_waitTime = 0.0f;

    /// <summary>
    /// FairyIdle 상태 생성자
    /// </summary>
    /// <param name="stateMachine">FairyStateMachine</param>
    public FairyIdle(FairyStateMachine stateMachine) : base(stateMachine)
    {
    }

    /// <summary>
    /// Fairy의 Idle 상태에 들어갔을 때 실행되는 함수
    /// </summary>
    /// <param name="sender">FairyController</param>
    public override void Enter(FairyController sender)
    {
        base.Enter(sender);

        m_waitTime = stateMachine.BattleStatus.RealAttackSpeed;
    }

    /// <summary>
    /// Fairy의 Idle 상태일 때 매 프레임마다 실행되는 함수
    /// </summary>
    /// <param name="sender">FairyController</param>
    public override void UpdateState(FairyController sender)
    {
        base.UpdateState(sender);

        m_waitTime -= Time.deltaTime;

        if (m_waitTime > 0.0f)
            return;
        
        // if (sender.TargetTransform)
        // {
        //     stateMachine.TransitionTo(stateMachine.Attack);
        // }
    }

    /// <summary>
    /// Fairy의 Idle 상태에서 다른 상태로 넘어갈 때 실행되는 함수
    /// </summary>
    /// <param name="sender">FairyController</param>
    public override void Exit(FairyController sender)
    {
        base.Exit(sender);
    }
}
