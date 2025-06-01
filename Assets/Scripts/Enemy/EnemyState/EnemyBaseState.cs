using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : IState<EnemyController>
{
    protected EnemyStateMachine stateMachine;
    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public virtual void Enter(EnemyController sender)
    {
    }

    public virtual void UpdateState(EnemyController sender)
    {
    }

    public virtual void Exit(EnemyController sender)
    {
    }
}
