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

    public EnemyStateMachine(EnemyController sender) : base(sender)
    {
        Idle = new(this);
        Move = new(this);
        Attack = new(this);

        TransitionTo(Move);
    }


}