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
    /// <param name="stateMachine">Enemy의 StateMachine</param>
    public EnemyAttackState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    /// <summary>
    /// Enemy의 Attack 상태에 들어가면 실행되는 함수
    /// </summary>
    /// <param name="sender">Enemy의 Controller</param>
    public override void Enter(EnemyController sender)
    {
        base.Enter(sender);

        stateMachine.Rigidbody.velocity = Vector2.zero;

        stateMachine.Animator.SetTrigger(AnimatorHash.Enemy.AttackTrigger);
    }

    /// <summary>
    /// Enemy의 Attack 상태 중에 매 프레임 실행되는 함수
    /// </summary>
    /// <param name="sender">Enemy의 Controller</param>
    public override void UpdateState(EnemyController sender)
    {
        base.UpdateState(sender);
    }

    /// <summary>
    /// Enemy의 Attack 상태가 끝날 때 실행되는 함수
    /// </summary>
    /// <param name="sender">Enemy의 Controller</param>
    public override void Exit(EnemyController sender)
    {
        base.Exit(sender);
    }
}
