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
    public DebuffType Debuff;
    // TODO : 필요한 것 있으면 그때 그때 추가

    // TODO : 나중에 CSV파일과 연동하기
    public HittingData(float damage, DebuffType condition)
    {
        Damage = damage;
        this.Debuff = condition;
    }
}