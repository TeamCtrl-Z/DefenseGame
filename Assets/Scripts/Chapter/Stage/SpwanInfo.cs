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
    Enemy003,
    Enemy004,
    Enemy005,
    Enemy006,
    Enemy007,
    Enemy008,
    Enemy009,
    Enemy010,
    Enemy011,
    Enemy012,
    Enemy013,
    Enemy014,
    Enemy015,
    Enemy016,
    Enemy017,
    Enemy018,
    Enemy019,
    Enemy020,
    Enemy021,
    Enemy100,
    Enemy101,
    Enemy102,
    Enemy200,
    Enemy201,
    Enemy202,
    Enemy203,
    Enemy204,
    Enemy205,
    Enemy206,
    Enemy207,
}
