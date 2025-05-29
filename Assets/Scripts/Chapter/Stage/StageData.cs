using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpawnData", menuName = "Game/StageData")]
public class StageData : ScriptableObject
{
    /// <summary>
    /// 스테이지에서 스폰되는 몬스터들의 정보를 담은 배열
    /// </summary>
    public SpawnInfo[] spawnInfos;
}
