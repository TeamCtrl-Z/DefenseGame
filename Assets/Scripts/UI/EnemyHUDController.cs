using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHUDController : MonoBehaviour
{
    [SerializeField] private Image hpBar;
    [SerializeField] private TextMeshProUGUI enemyName;
    [SerializeField] private TextMeshProUGUI hpText;

    private void OnEnable()
    {
        EnemySpawner.Instance.OnEnemySpawned += OnEnemySpawned;
    }

    private void OnDisable()
    {
        //EnemySpawner.Instance.OnEnemySpawned -= OnEnemySpawned;
    }

    /// <summary>
    /// 적이 Spawn 되었을 때 실행되는 함수
    /// </summary>
    /// <param name="enemy"> 생성된 적 </param>
    private void OnEnemySpawned(EnemyController enemy)
    {
        IHealthStatus healthStatus = enemy.GetComponent<IHealthStatus>();
        healthStatus.OnHPChanged += ShowEnemyInfo;
        enemy.onDisable += () => healthStatus.OnHPChanged -= ShowEnemyInfo;

        void ShowEnemyInfo(float hp)
        {
            enemyName.text = enemy.transform.name;
            hpBar.fillAmount = hp / healthStatus.MaxHP;
            hpText.text = $"{hp} / {healthStatus.MaxHP}";
        }
    }
}
