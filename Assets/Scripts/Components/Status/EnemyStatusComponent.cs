using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatusComponent : MonoBehaviour, IMoveStatus, IHealthStatus, ICharacterIdentity
{
    public int ID { get; private set; }
    public float MoveSpeed { get; private set; }
    public float CurrentHP { get; private set; }
    public float MaxHP { get; private set; }
    public event Action<float> OnHPChanged;

    /// <summary>
    /// Enemy Status 정보 모듈
    /// </summary>
    private EnemyStatusData statData;

    private void Awake()
    {
        if (!EnemyDataManager.Instance.TryGetStatData(ID, out statData))
        {
            Debug.LogError("Not Found");
            return;
        }
        ApplyStatusData();
    }

    /// <summary>
    /// EnemyStatusData적용
    /// </summary>
    private void ApplyStatusData()
    {
        MoveSpeed = statData.MoveSpeed;
        MaxHP = statData.HP;
        CurrentHP = MaxHP;
    }

    public void ChangeSpeed(float speed)
    {
        MoveSpeed = speed;
    }

    public void ChangeHP(float amount)
    {
        CurrentHP += amount;
        CurrentHP = Mathf.Clamp(CurrentHP, 0, MaxHP);

        OnHPChanged?.Invoke(CurrentHP);
    }
}
