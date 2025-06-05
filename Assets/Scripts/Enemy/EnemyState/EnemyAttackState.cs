using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy의 공격 상태클래스
/// </summary>
public class EnemyAttackState : EnemyBaseState
{
    /// <summary>
    /// EnemyAttackState 생성자
    /// </summary>
    /// <param name="stateMachine">EnemyStateMachine</param>
    public EnemyAttackState(EnemyStateMachine stateMachine) : base(stateMachine)
    {}

    /// <summary>
    /// 공격 상태로 진입할 때 호출되는 함수
    /// </summary>
    /// <param name="sender">EnemyController</param>
    public override void Enter(EnemyController sender)
    {
        base.Enter(sender);
    }

    /// <summary>
    /// 공격 상태에서 매 프레임마다 호출되는 함수
    /// </summary>
    /// <param name="sender">EnemyController</param>
    public override void UpdateState(EnemyController sender)
    {
        base.UpdateState(sender);
    }

    /// <summary>
    /// 공격 상태에서 벗어날 때 호출되는 함수
    /// </summary>
    /// <param name="sender">EnemyController</param>
    public override void Exit(EnemyController sender)
    {
        base.Exit(sender);
    }
}
