using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 피격 데이터 구조체
/// </summary>
[Serializable]
public class HittingData
{
    /// <summary>
    /// 이 데이터가 가지는 피해량
    /// </summary>
    public float Damage;

    /// <summary>
    /// 이 데이터가 가지는 디버프 종류
    /// </summary>
    public DebuffType Debuff;
    // TODO : 필요한 것 있으면 그때 그때 추가
}