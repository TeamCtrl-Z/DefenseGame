using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 세로줄 버프 대상 전략
/// </summary>
[CreateAssetMenu(fileName = "VerticalNeighbors", menuName = "BuffTarget/VerticalNeighbors")]
public class VerticalNeighbors : BuffTargetStrategyData
{
    /// <summary>
    /// 세로줄에 해당하는 노드 인덱스를 얻어오는 함수
    /// </summary>
    /// <param name="idx"></param>
    /// <returns></returns>
    public override List<uint> GetNeighborsNodeIdx(uint idx)
    {
        return GameManager.Instance.ContainerManager.BoatNodeContainer.GetVerticalNeighbors(idx);
    }
}