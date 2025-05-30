using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyStateMachine : StateMachine<FairyController>
{
    #region Caching States
    public FairyIdle Idle { get; private set; }
    public FairyAttack Attack { get; private set; }
    #endregion

    public Animator Animator { get; private set; }
    public IBattleStatus BattleStatus {get; private set; }
    public AttackHandler AttackHandler { get; private set; }

    public FairyStateMachine(FairyController sender, Animator animator, IBattleStatus battleStatus, AttackHandler attackHandler) : base(sender)
    {
        Animator = animator;
        BattleStatus = battleStatus;
        AttackHandler = attackHandler;

        Idle = new(this);
        Attack = new(this);

        var exitStateBehaviours = animator.GetBehaviours<ExitStateBehaviour>();
        foreach (var beh in exitStateBehaviours)
        {
            beh.OnStateExitEvent += OnStateExit;
        }

        TransitionTo(Idle);
    }

    private void OnStateExit(Animator animator, int layerIndex)
    {
        TransitionTo(Idle);
    }
}
