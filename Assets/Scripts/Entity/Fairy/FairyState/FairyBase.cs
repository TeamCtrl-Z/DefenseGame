using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Fairy의 기본 상태 클래스
/// </summary>
public class FairyBase : IState<FairyController>
{
    /// <summary>
    /// Fairy의 상태 머신
    /// </summary>
    protected FairyStateMachine stateMachine;

    /// <summary>
    /// FairyBase 생성자
    /// </summary>
    /// <param name="stateMachine">FairyStateMachine</param>
    public FairyBase(FairyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    /// <summary>
    /// Fairy의 상태에 들어갔을 때 실행되는 함수
    /// </summary>
    /// <param name="sender">FairyController</param>
    public virtual void Enter(FairyController sender)
    {
    }

    /// <summary>
    /// Fairy의 상태일 때 매 프레임마다 실행되는 함수
    /// </summary>
    /// <param name="sender">FairyController</param>
    public virtual void UpdateState(FairyController sender)
    {
    }

    /// <summary>
    /// Fairy의 상태에서 다른 상태로 넘어갈 때 실행되는 함수
    /// </summary>
    /// <param name="sender">FairyController</param>
    public virtual void Exit(FairyController sender)
    {
    }
}
