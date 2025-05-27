using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Singleton<EnemySpawner>
{
    /// <summary>
    /// Spawn Delay 시간
    /// </summary>
    [SerializeField] private float spawnDelay;

    /// <summary>
    /// Spawn할 적의 수
    /// </summary>
    [SerializeField] private float spawnCount;
    
    /// <summary>
    /// Spawner Transform의 X좌표 최대 최소
    /// </summary>
    [SerializeField] private Vector2 minMaxX;

    /// <summary>
    /// Spawner Transform의 Y좌표 최대 최소
    /// </summary>
    [SerializeField] private Vector2 minMaxY;

    /// <summary>
    /// 현재 딜레이 시간
    /// </summary>
    private float delayTime = 0.0f;
    public event Action<EnemyController> OnEnemySpawned;


    protected override void OnPreInitialize()
    {
        base.OnPreInitialize();
    }

    private void Update()
    {
        delayTime += Time.deltaTime;

        if (delayTime > spawnDelay)
        {
            delayTime = 0.0f;
            Spawn();
            return;
        }
    }

    /// <summary>
    /// Spawner의 랜덤한 위치에 적을 생성하는 함수
    /// </summary>
    private void Spawn()
    {
        for (int i = 0; i < spawnCount; ++i)
        {
            float randomX = UnityEngine.Random.Range(minMaxX.x, minMaxX.y);
            float randomY = UnityEngine.Random.Range(minMaxY.x, minMaxY.y);
            EnemyController enemy = Factory.Instance.GetEnemy_000(new Vector2(randomX, randomY));
            SpriteRenderer sprite = enemy.GetComponent<SpriteRenderer>();
            sprite.sortingOrder = Mathf.RoundToInt(-randomY * 100);
            enemy.transform.SetParent(transform, true);

            OnEnemySpawned?.Invoke(enemy);
        }
    }
}
