using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy의 공격 상태를 나타내는 클래스
/// </summary>
public abstract class EnemyBaseState : IState<EnemyController>
{
    /// <summary>
    /// Enemy의 상태 머신
    /// </summary>
    protected EnemyStateMachine stateMachine;

    /// <summary>
    /// EnemyBaseState 생성자
    /// </summary>
    /// <param name="stateMachine"></param>
    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    /// <summary>
    /// Enemy 상태에 들어갈 때 호출되는 함수
    /// </summary>
    /// <param name="sender">EnemyController</param>
    public virtual void Enter(EnemyController sender)
    {
    }

    /// <summary>
    /// Enemy 상태 중일 때 매 프레임마다 호출되는 함수
    /// </summary>
    /// <param name="sender">EnemyController</param>
    public virtual void UpdateState(EnemyController sender)
    {
    }

    /// <summary>
    /// Enemy 상태에서 벗어날 때 호출되는 함수
    /// </summary>
    /// <param name="sender">EnemyController</param>
    public virtual void Exit(EnemyController sender)
    {
    }
}
