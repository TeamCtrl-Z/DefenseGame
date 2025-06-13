using System;
using UnityEngine;

/// <summary>
/// 페어리 Status 컴포넌트
/// </summary>
[DefaultExecutionOrder(ExcutionOrder.Init)]
public class FairyStatusComponent : MonoBehaviour, IBattleStatus, ICharacterIdentity, IBuffStatus
{
    /// <summary>
    /// Fairy ID
    /// </summary>
    [field: SerializeField] public int ID { get; private set; }

    /// <summary>
    /// 페어리 강화정도, 아이템에 따른 공격속도 보정치
    /// </summary>
    public float AttackSpeedModifier { get; private set; }

    /// <summary>
    /// 실제 공격 속도를 반환하는 프로퍼티(계산 법 : 기본 페어리 고유 (stat + 추가 stat) * 버프 계수)
    /// </summary>
    public float RealAttackSpeed => Mathf.Max((statData.AttackSpeed + AttackSpeedModifier) * AttackSpeedBuffMultiflier, 0.0f);

    /// <summary>
    /// 페어리 강화정도, 아이템에 따른 공격력 보정치
    /// </summary>
    public float AttackPowerModifier { get; private set; }

    /// <summary>
    /// 공격력을 반환하는 프로퍼티
    /// </summary>
    public float RealAttackPower => Mathf.Max((statData.AttackPower + AttackPowerModifier) * AttackPowerBuffMultiflier, 0.0f);

    /// <summary>
    /// 공격속도 배수(버프 용도)
    /// </summary>
    [field: SerializeField] public float AttackSpeedBuffMultiflier { get; private set; } = 1f;

    /// <summary>
    /// 공격력 배수(버프 용도)
    /// </summary>
    [field: SerializeField] public float AttackPowerBuffMultiflier { get; private set; } = 1f;

    /// <summary>
    /// 페어리의 공격 유형
    /// </summary>
    public AttackType AttackType { get; private set; }

    /// <summary>
    /// 페어리의 공격 ID
    /// </summary>
    public uint AttackId { get; private set; }

    /// <summary>
    /// 페어리 Status 데이터(CSV파일 불러온 데이터)
    /// </summary>
    private FairyBaseStatusData statData;

    /// <summary>
    /// 공격력이 변경되었을 때 호출되는 이벤트
    /// </summary>
    public event Action<float> OnAttackPowerChanged;

    /// <summary>
    /// 공격속도가 변경되었을 때 호출되는 이벤트
    /// </summary>
    public event Action<float> OnAttackSpeedChanged;

    void Awake()
    {
        if (!DataService.Instance.FairyDataManager.TryGetStatData(ID, out statData))
        {
            Debug.LogError("Not Found");
            return;
        }

        ApplyStatusData();
    }

    /// <summary>
    /// FairyStatusData 적용
    /// </summary>
    private void ApplyStatusData()
    {
        AttackType = statData.AttackType;
        AttackId = statData.AttackId;

        //AttackPowerModifier += DataService.Instance.FairyDataManager.DetailStatusData.

        Debug.Log(statData.AttackType);
    }

    /// <summary>
    /// Fairy의 공격력 적용 함수
    /// </summary>
    /// <param name="delta"> 조정할 양 </param>
    public void AdjustAttackPower(float delta)
    {
        AttackPowerModifier += delta;
    }

    /// <summary>
    /// Fairy의 공격 속도 적용 함수
    /// </summary>
    /// <param name="amount"> 조정할 양 </param>
    public void AdjustAttackSpeed(float amount)
    {
        AttackSpeedModifier += amount;
    }

    /// <summary>
    /// Status 버프하는 함수
    /// </summary>
    /// <param name="type"> 버프할 종류 </param>
    /// <param name="amount"> 버프할 양 </param>
    public void BuffStatus(BuffType type, float amount)
    {
        if (type == BuffType.AttackSpeed)
            AttackSpeedBuffMultiflier = amount;
        else if (type == BuffType.AttackPower)
            AttackPowerBuffMultiflier = amount;
    }

    /// <summary>
    /// 버프를 중단하기 위한 함수
    /// </summary>
    /// <param name="type"> 버프를 중단할 종류 </param>
    public void BuffStop(BuffType type)
    {
        if (type == BuffType.AttackSpeed)
            AttackSpeedBuffMultiflier = 1f;
        else if (type == BuffType.AttackPower)
            AttackPowerBuffMultiflier = 1f;
    }
}