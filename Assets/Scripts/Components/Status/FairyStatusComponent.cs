using System;
using UnityEngine;
using UnityEngine.Rendering;

public class FairyStatusComponent : MonoBehaviour, IBattleStatus, ICharacterIdentity
{
    /// <summary>
    /// Fairy ID
    /// </summary>
    [field: SerializeField] public int ID { get; private set; }

    [field: SerializeField] public float AttackSpeed { get; private set; }

    [field: SerializeField] public float AttackPower { get; private set; }

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
        AttackPower = statData.AttackPower;
        AttackSpeed = statData.AttackSpeed;
    }

    public void AdjustAttackPower(float delta)
    {
        AttackPower += delta;

        if (AttackPower < 0)
            AttackPower = 0;

        OnAttackPowerChanged?.Invoke(AttackPower);
    }

    public void AdjustAttackSpeed(float delta)
    {
        AttackSpeed += delta;

        if (AttackSpeed < 0)
            AttackSpeed = 0;

        OnAttackSpeedChanged?.Invoke(AttackSpeed);
    }
}