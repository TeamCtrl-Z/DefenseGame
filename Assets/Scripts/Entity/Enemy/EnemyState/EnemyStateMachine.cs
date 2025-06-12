using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 적 StateMachine 클래스
/// </summary>
public class EnemyStateMachine : StateMachine<EnemyController>
{
    #region States Caching

    /// <summary>
    /// Enemy의 Idle 상태 클래스
    /// </summary>
    public EnemyIdleState Idle { get; private set; }

    /// <summary>
    /// Enemy의 Move 상태 클래스
    /// </summary>
    public EnemyMoveState Move { get; private set; }

    /// <summary>
    /// Enemy의 Attack 상태 클래스
    /// </summary>
    public EnemyAttackState Attack { get; private set; }
    #endregion

    /// <summary>
    /// Enemy의 Rigidbody
    /// </summary>
    public Rigidbody2D Rigidbody { get; private set; }

    /// <summary>
    /// Enemy의 BlockComponent
    /// </summary>
    public EnemyAttackHandler AttackHandler { get; private set; }

    /// <summary>
    /// Enemy의 Animator
    /// </summary>
    public Animator Animator { get; private set; }

    /// <summary>
    /// IBattleStatus 인터페이스를 구현한 BattleStatus를 불러오는 프로퍼티(읽기 전용)
    /// </summary>
    public IBattleStatus BattleStatus { get; private set; }

    /// <summary>
    /// EnemyStateMachine의 생성자
    /// </summary>
    /// <param name="sender">Enemy의 Controller</param>
    public EnemyStateMachine(EnemyController sender) : base(sender)
    {
        Idle = new EnemyIdleState(this);
        Move = new EnemyMoveState(this);
        Attack = new EnemyAttackState(this);

        Rigidbody = sender.GetComponent<Rigidbody2D>();
        AttackHandler = sender.GetComponentInChildren<EnemyAttackHandler>();
        Animator = sender.GetComponentInChildren<Animator>();
        BattleStatus = sender.GetComponent<IBattleStatus>();

        var behaviour = Animator.GetBehaviour<ExitStateBehaviour>();
        behaviour.OnStateExitEvent += OnStateExit;

        TransitionTo(Move);
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