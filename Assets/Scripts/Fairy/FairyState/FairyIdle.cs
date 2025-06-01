using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyIdle : FairyBase
{
    private float m_waitTime = 0.0f;
    public FairyIdle(FairyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter(FairyController sender)
    {
        base.Enter(sender);

        m_waitTime = stateMachine.BattleStatus.AttackSpeed;
    }

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

    public override void Exit(FairyController sender)
    {
        base.Exit(sender);
    }
}
