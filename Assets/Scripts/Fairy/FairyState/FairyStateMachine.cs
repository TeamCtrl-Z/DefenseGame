using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Fairy의 StateMachine 클래스
/// </summary>
public class FairyStateMachine : StateMachine<FairyController>
{
    #region Caching States

    /// <summary>
    /// Fairy의 Idle 상태를 불러오는 프로퍼티(읽기 전용)
    /// </summary>
    public FairyIdle Idle { get; private set; }

    /// <summary>
    /// Fairy의 Attack 상태를 불러오는 프로퍼티(읽기 전용)
    /// </summary>
    public FairyAttack Attack { get; private set; }
    #endregion

    /// <summary>
    /// Fairy의 Animator 컴포넌트를 불러오는 프로퍼티(읽기 전용)
    /// </summary>
    public Animator Animator { get; private set; }

    /// <summary>
    /// IBattleStatus 인터페이스를 구현한 BattleStatus를 불러오는 프로퍼티(읽기 전용)
    /// </summary>
    public IBattleStatus BattleStatus {get; private set; }

    /// <summary>
    /// AttackHandler를 불러오는 프로퍼티(읽기 전용)
    /// </summary>
    public AttackHandler AttackHandler { get; private set; }

    /// <summary>
    /// FairyStateMachine 생성자
    /// </summary>
    /// <param name="sender">FairyController</param>
    /// <param name="animator">Fairy의 Animator</param>
    /// <param name="battleStatus">Fairy의 IBattleStatus</param>
    /// <param name="attackHandler">Fairy의 AttackHandler</param>
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

    /// <summary>
    /// State가 종료될 때 호출되는 메서드
    /// </summary>
    /// <param name="animator">Fairy의 Animator</param>
    /// <param name="layerIndex">Animator의 레이어 번호</param>
    private void OnStateExit(Animator animator, int layerIndex)
    {
        TransitionTo(Idle);
    }
}
