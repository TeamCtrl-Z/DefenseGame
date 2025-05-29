using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveStatus
{
    /// <summary>
    /// 이동 속도
    /// </summary>
    public float MoveSpeed { get; }

    /// <summary>
    /// 이동 속도 변경
    /// </summary>
    /// <param name="speed"></param>
    public void ChangeSpeed(float speed);
}
