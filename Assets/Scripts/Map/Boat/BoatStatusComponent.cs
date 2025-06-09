using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Boat의 StatusComponent
/// </summary>
public class BoatStatusComponent : MonoBehaviour, IHealthStatus
{
    /// <summary>
    /// Boat 현재 HP가 바뀌면 실행되는 델리게이트
    /// </summary>
    public event Action<float> OnHPChanged;

    /// <summary>
    /// Boat의 HP가 0이 되면 실행되는 델리게이트
    /// </summary>
    public event Action OnDie;

    /// <summary>
    /// 현재 HP
    /// </summary>
    public float CurrentHP { get; private set; }

    /// <summary>
    /// 전체 HP
    /// </summary>
    public float MaxHP { get; private set; }

    /// <summary>
    /// Boat의 Level
    /// </summary>
    [field: SerializeField]
    public int Level { get; private set; }

    /// <summary>
    /// Boat의 StatusData
    /// </summary>
    private BoatStatusData statData;

    private void Start()
    {
        Debug.Log($"[BoatStatus] DataService.Instance = {DataService.Instance}");
        if (DataService.Instance != null)
            Debug.Log($"[BoatStatus] BoatDataManager = {DataService.Instance.BoatDataManager}");

        if (DataService.Instance == null || DataService.Instance.BoatDataManager == null)
        {
            Debug.LogError("DataService 혹은 BoatDataManager가 null입니다!");
            return;
        }

        if (!DataService.Instance.BoatDataManager
                .TryGetStatData(Level, out statData))
        {
            Debug.LogError("Not Found");
            return;
        }

        ApplyStatusData();
    }

    /// <summary>
    /// 현재 HP를 바꾸는 함수
    /// </summary>
    /// <param name="amount">바꾸는 양</param>
    public void ChangeHP(float amount)
    {
        CurrentHP -= amount;

        if (CurrentHP <= 0)
        {
            CurrentHP = Mathf.Clamp(CurrentHP, 0, MaxHP);
            OnDie?.Invoke();
            return;
        }

        OnHPChanged?.Invoke(CurrentHP / MaxHP);
    }

    /// <summary>
    /// BoatStatusData를 적용하는 함수
    /// </summary>
    private void ApplyStatusData()
    {
        MaxHP = statData.HP;
        CurrentHP = MaxHP;
    }
}
