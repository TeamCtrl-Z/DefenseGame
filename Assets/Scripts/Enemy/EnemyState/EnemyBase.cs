using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : IState<EnemyController>
{
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
