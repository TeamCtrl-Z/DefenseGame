using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : RecycleObject
{
    /// <summary>
    /// 이펙트 유지 시간
    /// </summary>
    [Header("이펙트 유지 시간")]
    [SerializeField]
    private float disableTime;

    /// <summary>
    /// 이펙트가 활성화 될 때 실행되는 함수
    /// </summary>
    protected override void OnReset()
    {
        DisableTimer(disableTime);
    }
}
