using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveStatus
{
    /// <summary>
    /// 실제 이동 속도
    /// </summary>
    public float MoveSpeed { get; }

    /// <summary>
    /// 이동 속도 배수
    /// </summary>
    public float MoveSpeedMultiplier { get; set;}

    /// <summary>
    /// 이동 속도 변경
    /// </summary>
    /// <param name="speed"></param>
    public void ChangeSpeed(float speed);
}
