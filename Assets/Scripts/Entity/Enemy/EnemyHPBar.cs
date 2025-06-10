using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy의 HP바를 관리하는 클래스
/// </summary>
public class EnemyHPBar : MonoBehaviour
{
    /// <summary>
    /// HP바 Fill
    /// </summary>
    [SerializeField]
    private Transform hpFill;

    /// <summary>
    /// 적 상태 컴포넌트
    /// </summary>
    private EnemyStatusComponent enemyStatus;

    private void Awake()
    {
        enemyStatus = GetComponentInParent<EnemyStatusComponent>();
    }

    private void Start()
    {
        enemyStatus.OnHPChanged += RefreshHPFill;
    }

    private void OnEnable()
    {
        hpFill.localScale = Vector3.one;
    }

    /// <summary>
    /// HP바를 갱신하는 함수
    /// </summary>
    /// <param name="hpRatio">체력 비율</param>
    private void RefreshHPFill(float hpRatio)
    {
        float fillAmount = Mathf.Clamp(hpRatio, 0, 1f);
        hpFill.localScale = new Vector3(fillAmount, 1f, 1f);
    }


}
