using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatusComponent : MonoBehaviour, IMoveStatus, IHealthStatus, ICharacterIdentity
{
    /// <summary>
    /// HPBar UI Prefab
    /// </summary>
    [field: SerializeField] private GameObject enemyHPPrefab;
    private Image hpBar;
    [field: SerializeField] public int ID { get; private set; }
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
        GameObject obj = Instantiate(enemyHPPrefab, transform);
        obj.transform.localPosition = new Vector2(0.0f, 1f);

        if (obj.transform.TryFindByName("Fill", out Transform hpTf))
        {
            hpBar = hpTf.GetComponent<Image>();
        }
    }

    private void Start()
    {
        if (!EnemyDataManager.Instance.TryGetStatData(ID, out statData))
        {
            Debug.LogError("Not Found");
            return;
        }
        ApplyStatusData();
        hpBar.fillAmount = CurrentHP / MaxHP;
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
        hpBar.fillAmount = CurrentHP / MaxHP;

        OnHPChanged?.Invoke(CurrentHP);
    }
}
