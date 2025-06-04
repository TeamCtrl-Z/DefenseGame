using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatusComponent : MonoBehaviour, IMoveStatus, IHealthStatus, ICharacterIdentity
{
    /// <summary>
    /// HP가 변경될 때 호출되는 이벤트 델리게이트
    /// </summary>
    public event Action<float> OnHPChanged;

    /// <summary>
    /// Enemy 고유 ID
    /// </summary>
    [field: SerializeField] public int ID { get; private set; }

    /// <summary>
    /// Enemy 고유 이동 속도
    /// </summary>
    private float moveSpeed = 2f;

    /// <summary>
    /// Enemy 속도 배수
    /// </summary>
    [field: SerializeField] public float MoveSpeedMultiplier { get; set; } = 1f;

    /// <summary>
    /// Enemy 실제 이동 속도 
    /// </summary>
    public float MoveSpeed => moveSpeed * MoveSpeedMultiplier;

    public float CurrentHP { get; private set; }
    public float MaxHP { get; private set; }

    /// <summary>
    /// Enemy Status 정보 모듈
    /// </summary>
    private EnemyStatusData statData;

    private void Start()
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
        moveSpeed = statData.MoveSpeed;
        MaxHP = statData.HP;
        CurrentHP = MaxHP;
    }

    public void ChangeSpeed(float speed)
    {
        moveSpeed = speed;
    }

    public void ChangeHP(float amount)
    {
        CurrentHP += amount;
        CurrentHP = Mathf.Clamp(CurrentHP, 0, MaxHP);
        OnHPChanged?.Invoke(CurrentHP / MaxHP);
    }
}
