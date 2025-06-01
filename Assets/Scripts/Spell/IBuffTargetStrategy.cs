using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 버프 타겟 전략
/// </summary>
public interface IBuffTargetStrategy
{
    /// <summary>
    /// 버프를 줄 노드 인덱스 얻는 함수
    /// </summary>
    /// <param name="idx"> 현재 노드 인덱스 </param>
    /// <returns></returns>
    public List<uint> GetNeighborsNodeIdx(uint idx);
}

public abstract class BuffTargetStrategyData : ScriptableObject, IBuffTargetStrategy
{
    public abstract List<uint> GetNeighborsNodeIdx(uint idx);
}