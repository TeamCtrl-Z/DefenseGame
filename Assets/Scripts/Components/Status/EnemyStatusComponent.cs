
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 적 Status 컴포넌트
/// </summary>
public class EnemyStatusComponent : MonoBehaviour, IMoveStatus, IHealthStatus, ICharacterIdentity
{
    /// <summary>
    /// HP가 변경될 때 호출되는 이벤트 델리게이트
    /// </summary>
    public event Action<float> OnHPChanged;

    /// <summary>
    /// Enemy가 죽을 때 호출되는 이벤트 델리게이트
    /// </summary>
    public event Action OnDie;

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

    /// <summary>
    /// 현재 HP
    /// </summary>
    public float CurrentHP { get; private set; }

    /// <summary>
    /// 최대 HP
    /// </summary>
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

    /// <summary>
    /// 이동 속도를 변경해주는 함수
    /// </summary>
    /// <param name="speed"> 원하는 속도 </param>
    public void ChangeSpeed(float speed)
    {
        moveSpeed = speed;
    }

    /// <summary>
    /// HP를 변경경해주는 함수
    /// </summary>
    /// <param name="amount"> 변경할 양 </param>
    public void ChangeHP(float amount)
    {
        CurrentHP += amount;
        CurrentHP = Mathf.Clamp(CurrentHP, 0, MaxHP);
        OnHPChanged?.Invoke(CurrentHP / MaxHP);

        if (CurrentHP <= 0)
        {
            OnDie?.Invoke();
        }
    }
}
