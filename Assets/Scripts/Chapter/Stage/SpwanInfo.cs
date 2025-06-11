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
    Enemy000 = 0,
    Enemy001 = 1,
    Enemy002 = 2,
    Enemy003 = 3,
    Enemy004 = 4,
    Enemy005 = 5,
    Enemy006 = 6,
    Enemy007 = 7,
    Enemy008 = 8,
    Enemy009 = 9,
    Enemy010 = 10,
    Enemy011 = 11,
    Enemy012 = 12,
    Enemy013 = 13,
    Enemy014 = 14,
    Enemy015 = 15,
    Enemy016 = 16,
    Enemy017 = 17,
    Enemy018 = 18,
    Enemy019 = 19,
    Enemy020 = 20,
    Enemy021 = 21,
    Enemy022 = 22,
    Enemy023 = 23,
    Enemy024 = 24,
    Enemy025 = 25,
    Enemy026 = 26,
    Enemy027 = 27,
    Enemy028 = 28,
    Enemy029 = 29,
    Enemy030 = 30,
    Enemy031 = 31,
    Enemy100 = 100,
    Enemy101 = 101,
    Enemy102 = 102,
    Enemy103 = 103,
    Enemy104 = 104,
    Enemy105 = 105,
    Enemy200 = 200,
    Enemy201 = 201,
    Enemy202 = 202,
    Enemy203 = 203,
    Enemy204 = 204,
    Enemy205 = 205,
    Enemy206 = 206,
    Enemy207 = 207,
    Enemy208 = 208,
    Enemy209 = 209,
    Enemy210 = 210,
    Enemy211 = 211,
}
