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

/// <summary>
/// 버프 타겟 전략 SO
/// </summary>
public abstract class BuffTargetStrategyData : ScriptableObject, IBuffTargetStrategy
{
    /// <summary>
    /// 주변 이웃 노드 인덱스를 반환하는 함수
    /// </summary>
    /// <param name="idx">노드의 인덱스</param>
    /// <returns>이웃 노드들의 인덱스를 모아놓은 List</returns>
    public abstract List<uint> GetNeighborsNodeIdx(uint idx);
}