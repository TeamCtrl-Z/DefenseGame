using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// HP관련 인터페이스
/// </summary>
public interface IHealthStatus
{
    /// <summary>
    /// 체력
    /// </summary>
    public float CurrentHP { get; }

    /// <summary>
    /// 최대 체력
    /// </summary>
    public float MaxHP { get; }

    /// <summary>
    /// 체력 변경
    /// </summary>
    /// <param name="amount"> 음수 : 데미지, 양수 : 회복 </param>
    public void ChangeHP(float amount);

    /// <summary>
    /// 체력 변경 이벤트
    /// </summary>
    public event Action<float> OnHPChanged;
}
