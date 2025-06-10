using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Fairy의 Skill 상태 클래스
/// </summary>
public class FairySkill : FairyBase
{
    /// <summary>
    /// FairySkill 생성자
    /// </summary>
    /// <param name="stateMachine">FairyStateMachine</param>
    public FairySkill(FairyStateMachine stateMachine) : base(stateMachine)
    {
    }

    /// <summary>
    /// Fairy의 Skill 상태에 들어갔을 때 실행되는 함수
    /// </summary>
    /// <param name="sender">FairyController</param>
    public override void Enter(FairyController sender)
    {
        base.Enter(sender);
    }

    /// <summary>
    /// Fairy의 Skill 상태일 때 매 프레임마다 실행되는 함수
    /// </summary>
    /// <param name="sender">FairyController</param>
    public override void UpdateState(FairyController sender)
    {
        base.UpdateState(sender);
    }

    /// <summary>
    /// Fairy의 Skill 상태에서 다른 상태로 넘어갈 때 실행되는 함수
    /// </summary>
    /// <param name="sender">FairyController</param>
    public override void Exit(FairyController sender)
    {
        base.Exit(sender);
    }
}
