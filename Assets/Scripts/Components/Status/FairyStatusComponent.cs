using System;
using UnityEngine;
using UnityEngine.Rendering;

/// <summary>
/// 페어리 Status 컴포넌트
/// </summary>
public class FairyStatusComponent : MonoBehaviour, IBattleStatus, ICharacterIdentity, IBuffStatus
{
    /// <summary>
    /// Fairy ID
    /// </summary>
    [field: SerializeField] public int ID { get; private set; }

    /// <summary>
    /// 공격 속도(쿨타임)
    /// </summary>
    [SerializeField] private float attackSpeed;
    public float AttackSpeed => attackSpeed * AttackSpeedFactor;

    /// <summary>
    /// 공격력(기본 공격)
    /// </summary>
    [SerializeField] private float attackPower;
    public float AttackPower => attackPower * AttackPowerFactor;

    /// <summary>
    /// 공격속도 배수(버프 용도)
    /// </summary>
    [field: SerializeField] public float AttackSpeedFactor { get; private set; } = 1f;

    /// <summary>
    /// 공격력 배수(버프 용도)
    /// </summary>
    [field: SerializeField] public float AttackPowerFactor { get; private set; } = 1f;

    private TargetingType type;

    /// <summary>
    /// 페어리 Status 데이터(CSV파일 불러온 데이터)
    /// </summary>
    private FairyStatusData statData;

    /// <summary>
    /// 공격력이 변경되었을 때 호출되는 이벤트
    /// </summary>
    public event Action<float> OnAttackPowerChanged;

    /// <summary>
    /// 공격속도가 변경되었을 때 호출되는 이벤트
    /// </summary>
    public event Action<float> OnAttackSpeedChanged;

    private void Start()
    {
        if (!FairyDataManager.Instance.TryGetStatData(ID, out statData))
        {
            Debug.LogError("Not Found");
            return;
        }

        ApplyStatusData();
    }

    /// <summary>
    /// EnemyStatusData 적용
    /// </summary>
    private void ApplyStatusData()
    {
        attackPower = statData.AttackPower;
        attackSpeed = statData.AttackSpeed;

        Debug.Log(statData.Target);
    }

    /// <summary>
    /// 공격력 적용 함수
    /// </summary>
    /// <param name="delta"> 조정할 양 </param>
    public void AdjustAttackPower(float delta)
    {
        attackPower += delta;

        if (AttackPower < 0)
            attackPower = 0;

        OnAttackPowerChanged?.Invoke(attackPower);
    }

    /// <summary>
    /// 공격 속도 적용 함수
    /// </summary>
    /// <param name="amount"> 조정할 양 </param>
    public void AdjustAttackSpeed(float amount)
    {
        attackSpeed = amount;

        if (attackSpeed < 0)
            attackSpeed = 0;

        OnAttackSpeedChanged?.Invoke(attackSpeed);
    }

    /// <summary>
    /// Status 버프하는 함수
    /// </summary>
    /// <param name="type"> 버프할 종류 </param>
    /// <param name="amount"> 버프할 양 </param>
    public void BuffStatus(BuffType type, float amount)
    {
        if (type == BuffType.AttackSpeed)
            AttackSpeedFactor = amount;
        else if (type == BuffType.AttackPower)
            AttackPowerFactor = amount;
    }

    /// <summary>
    /// 버프를 중단하기 위한 함수
    /// </summary>
    /// <param name="type"> 버프를 중단할 종류 </param>
    public void BuffStop(BuffType type)
    {
        if (type == BuffType.AttackSpeed)
            AttackSpeedFactor = 1f;
        else if (type == BuffType.AttackPower)
            AttackPowerFactor = 1f;
    }
}