using UnityEngine;

/// <summary>
/// 스테이지 데이터를 담은 ScriptableObject 클래스
/// </summary>
[CreateAssetMenu(fileName = "NewSpawnData", menuName = "Game/StageData")]
public class StageData : ScriptableObject
{
    /// <summary>
    /// 스테이지 고유 아이디
    /// </summary>
    public uint StageID;
    
    /// <summary>
    /// 스테이지 이름
    /// </summary>
    public string stageName;

    /// <summary>
    /// 스테이지 클리어 여부
    /// </summary>
    public bool isClear = false;

    /// <summary>
    /// 스테이지 클리어 보상(Gold)
    /// </summary>
    public ulong reward_Gold;

    /// <summary>
    /// 스테이지 클리어 보상(Gem)
    /// </summary>
    public ulong reward_Gem;

    /// <summary>
    /// 전체 몬스터 수
    /// </summary>
    public int stageSpawnCount;

    /// <summary>
    /// 스테이지에서 스폰되는 몬스터들의 정보를 담은 배열
    /// </summary>
    public SpawnInfo[] spawnInfos;
}
