using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 전투를 위한 Status
/// </summary>
public interface IBattleStatus
{
    /// <summary>
    /// 페어리의 공격 유형
    /// </summary>
    public AttackType AttackType { get; }
    
    /// <summary>
    /// 기본 공격력
    /// </summary>
    public float AttackPower { get; }

    /// <summary>
    /// 기본 공격 속도
    /// </summary>
    public float AttackSpeed { get; }

    /// <summary>
    /// 공격력을 delta만큼 가감
    /// </summary>
    /// <param name="delta">양수: 증가, 음수: 감소</param>
    public void AdjustAttackPower(float delta);

    /// <summary>
    /// 공격력 속도을 delta만큼 가감
    /// </summary>
    /// <param name="delta">양수: 증가, 음수: 감소</param>
    public void AdjustAttackSpeed(float delta);

    /// <summary>
    /// 공격력이 변경되면 알리는 이벤트
    /// </summary>
    public event Action<float> OnAttackPowerChanged;

    /// <summary>
    /// 공격 속도가 변경되면 알리는 이벤트
    /// </summary>
    public event Action<float> OnAttackSpeedChanged;
}
