using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Fairy의 Attack 상태 클래스
/// </summary>
public class FairyAttack : FairyBase
{
    /// <summary>
    /// FairyAttack 생성자
    /// </summary>
    /// <param name="stateMachine">FairyStateMachine</param>
    public FairyAttack(FairyStateMachine stateMachine) : base(stateMachine)
    {}

    /// <summary>
    /// Fairy가 Attack 상태에 진입할 때 호출되는 메서드
    /// </summary>
    /// <param name="sender">FairyController</param>
    public override void Enter(FairyController sender)
    {
        base.Enter(sender);
        stateMachine.Animator.SetTrigger(AnimatorHash.Fairy.AttackTrigger);
        //stateMachine.FairyAttackHandler.DoAttack(sender.TargetTransform);
    }

    /// <summary>
    /// Fairy가 Attack 상태를 업데이트할 때 호출되는 메서드
    /// </summary>
    /// <param name="sender">FairyController</param>
    public override void UpdateState(FairyController sender)
    {
        base.UpdateState(sender);
    }

    /// <summary>
    /// Fairy가 Attack 상태를 종료할 때 호출되는 메서드
    /// </summary>
    /// <param name="sender">FairyController</param>
    public override void Exit(FairyController sender)
    {
        base.Exit(sender);
    }
}
