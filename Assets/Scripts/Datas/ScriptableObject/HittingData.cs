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
    public float Damage;
    public DebuffType Debuff;
    // TODO : 필요한 것 있으면 그때 그때 추가
}