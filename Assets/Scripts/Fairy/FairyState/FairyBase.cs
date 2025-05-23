using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyBase : IState<FairyController>
{
    protected FairyStateMachine stateMachine;
    public FairyBase(FairyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public virtual void Enter(FairyController sender)
    {
    }

    public virtual void Exit(FairyController sender)
    {
    }

    public virtual void UpdateState(FairyController sender)
    {
    }
}
