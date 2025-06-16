using System;
using System.Linq;
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
    [field: SerializeField] public uint ID { get; private set; }

    /// <summary>
    /// 페어리 공격속도(버프 적용 전)
    /// </summary>
    private float attackSpeed;

    /// <summary>
    /// 페어리 공격력(버프 전용 전)
    /// </summary>
    private float attackPower;

    /// <summary>
    /// 실제 공격 속도를 반환하는 프로퍼티
    /// </summary>
    public float RealAttackSpeed => Mathf.Max(attackSpeed * AttackSpeedBuffMultiflier, 0.0f);

    /// <summary>
    /// 실제 공격력을 반환하는 프로퍼티
    /// </summary>
    public float RealAttackPower => Mathf.Max(attackPower * AttackPowerBuffMultiflier, 0.0f);

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
    /// 페어리 소환시 주입된 데이터를 가지고 초기화 작업
    /// </summary>
    /// <param name="data"></param>
    public void Initialize(FairyInstanceData data)
    {
        attackPower = data.AttackPower;
        attackSpeed = data.AttackSpeed;
        AttackType = data.AttackType;
        AttackId = data.AttackId;
    }

    /// <summary>
    /// Fairy의 공격력 적용 함수
    /// </summary>
    /// <param name="delta"> 조정할 양 </param>
    public void AdjustAttackPower(float delta)
    {
        
    }

    /// <summary>
    /// Fairy의 공격 속도 적용 함수
    /// </summary>
    /// <param name="amount"> 조정할 양 </param>
    public void AdjustAttackSpeed(float amount)
    {
        
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