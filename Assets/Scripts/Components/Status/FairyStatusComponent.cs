using System;
using UnityEngine;
using UnityEngine.Rendering;

public class FairyStatusComponent : MonoBehaviour, IBattleStatus, ICharacterIdentity, IBuffStatus
{
    /// <summary>
    /// Fairy ID
    /// </summary>
    [field: SerializeField] public int ID { get; private set; }
    private float attackSpeed;
    public float AttackSpeed => attackSpeed * AttackSpeedFactor;
    private float attackPower;
    public float AttackPower => attackPower* AttackPowerFactor;

    [field: SerializeField] public float AttackSpeedFactor { get; private set; } = 1f;

    [field: SerializeField] public float AttackPowerFactor { get; private set; } = 1f;

    private FairyStatusData statData;

    public event Action<float> OnAttackPowerChanged;
    public event Action<float> OnAttackSpeedChanged;

    private void Awake()
    {
    }

    private void Start()
    {
        if (!FairyDataManager.Instance.TryGetValue(ID, out statData))
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
    }

    public void AdjustAttackPower(float delta)
    {
        attackPower += delta;

        if (AttackPower < 0)
            attackPower = 0;

        OnAttackPowerChanged?.Invoke(attackPower);
    }

    public void AdjustAttackSpeed(float amount)
    {
        attackSpeed = amount;

        if (attackSpeed < 0)
            attackSpeed = 0;

        OnAttackSpeedChanged?.Invoke(attackSpeed);
    }

    public void BuffStatus(BuffType type, float amount)
    {
        if (type == BuffType.AttackSpeed)
            AttackSpeedFactor = amount;
        else if (type == BuffType.AttackPower)
            AttackPowerFactor = amount;
    }

    public void BuffStop(BuffType type)
    {
        if (type == BuffType.AttackSpeed)
            AttackSpeedFactor = 1f;
        else if (type == BuffType.AttackPower)
            AttackPowerFactor = 1f;
    }
}