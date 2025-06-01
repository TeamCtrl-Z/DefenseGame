using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine<EnemyController>
{
    #region Caching States
    public EnemyIdleState Idle { get; private set; }
    public EnemyMoveState Move { get; private set; }
    public EnemyAttackState Attack { get; private set; }
    public EnemyDieState Die { get; private set; }
    #endregion

    public Rigidbody2D Rigidbody { get; private set; }
    public EnemyBlockComponent BlockComponent { get; private set; }
    public Animator Animator { get; private set; }

    public EnemyStateMachine(EnemyController sender) : base(sender)
    {
        Idle = new(this);
        Move = new(this);
        Attack = new(this);
        Die = new(this);

        Rigidbody = sender.GetComponent<Rigidbody2D>();
        BlockComponent = sender.GetComponent<EnemyBlockComponent>();
        Animator = sender.GetComponent<Animator>();

        TransitionTo(Move);
    }


}