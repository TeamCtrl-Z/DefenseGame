using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveStatus
{
    public float MoveSpeed { get; }
    public void ChangeSpeed(float speed);
}
