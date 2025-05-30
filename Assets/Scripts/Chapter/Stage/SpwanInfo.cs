using System;
using UnityEngine;

/// <summary>
/// 스폰 정보를 담은 구조체
/// </summary>
[Serializable]
public struct SpawnInfo
{
    public SpawnType spawnType;
    public float spawnTime;
    public Vector2 spawnPosition;
}

/// <summary>
/// 몬스터 스폰 타입을 정의하는 열거형
/// </summary>
public enum SpawnType
{
    Enemy000,
    Enemy001,
    Enemy002,
    Enemy100,
    Enemy101,
    Enemy102,
    Enemy200,
    Enemy201,
    Enemy202,
}
