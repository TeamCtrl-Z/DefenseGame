using UnityEngine;

/// <summary>
/// 이펙트를 재사용하기 위한 클래스
/// </summary>
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
        if (disableTime != 0.0f)
            DisableTimer(disableTime);
    }
}
