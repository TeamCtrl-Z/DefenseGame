using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : IState<CharacterController>
{
    public virtual void Enter(CharacterController sender)
    {
    }

    public virtual void Exit(CharacterController sender)
    {
    }

    public virtual void UpdateState(CharacterController sender)
    {
    }
}
