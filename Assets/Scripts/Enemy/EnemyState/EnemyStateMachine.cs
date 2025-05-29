using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine<EnemyController>
{
    #region Caching States
    public EnemyIdle Idle { get; private set; }
    public EnemyMove Move { get; private set; }
    public EnemyAttack Attack { get; private set; }
    #endregion

    public Rigidbody2D Rigidbody{ get; private set; }
    public EnemyBlockComponent BlockComponent { get; private set; }

    public EnemyStateMachine(EnemyController sender) : base(sender)
    {
        Idle = new(this);
        Move = new(this);
        Attack = new(this);

        Rigidbody = sender.GetComponent<Rigidbody2D>();
        BlockComponent = sender.GetComponent<EnemyBlockComponent>();

        TransitionTo(Move);
    }


}