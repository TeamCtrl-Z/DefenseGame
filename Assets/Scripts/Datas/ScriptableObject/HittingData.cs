using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 피격 데이터 구조체
/// </summary>
[Serializable]
public struct HittingData
{
    public float Damage;
    // TODO : 필요한 것 있으면 그때 그때 추가

    public HittingData(float damage)
    {
        Damage = damage;
    }
}