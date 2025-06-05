using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 적 StateMachine 클래스
/// </summary>
public class EnemyStateMachine : StateMachine<EnemyController>
{
    #region Caching States

    /// <summary>
    /// 적 Idle 상태를 가져오는 프로퍼티(읽기 전용)
    /// </summary>
    public EnemyIdleState Idle { get; private set; }

    /// <summary>
    /// 적 Move 상태를 가져오는 프로퍼티(읽기 전용)
    /// </summary>
    public EnemyMoveState Move { get; private set; }

    /// <summary>
    /// 적 Attack 상태를 가져오는 프로퍼티(읽기 전용)
    /// </summary>
    public EnemyAttackState Attack { get; private set; }
    #endregion

    /// <summary>
    /// 적 Rigidbody2D 컴포넌트를 가져오는 프로퍼티(읽기 전용)
    /// </summary>
    public Rigidbody2D Rigidbody { get; private set; }

    /// <summary>
    /// 적 BlockComponent를 가져오는 프로퍼티(읽기 전용)
    /// </summary>
    public EnemyBlockComponent BlockComponent { get; private set; }

    /// <summary>
    /// 적 Animator 컴포넌트를 가져오는 프로퍼티(읽기 전용)
    /// </summary>
    public Animator Animator { get; private set; }

    /// <summary>
    /// EnemyStateMachine 생성자
    /// </summary>
    /// <param name="sender">EnemyController</param>
    public EnemyStateMachine(EnemyController sender) : base(sender)
    {
        Idle = new(this);
        Move = new(this);
        Attack = new(this);

        Rigidbody = sender.GetComponent<Rigidbody2D>();
        BlockComponent = sender.GetComponent<EnemyBlockComponent>();
        Animator = sender.GetComponent<Animator>();

        TransitionTo(Move);
    }
}