using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VerticalNeighbors", menuName = "BuffTarget/VerticalNeighbors")]
public class VerticalNeighbors : BuffTargetStrategyData
{
    public override List<uint> GetNeighborsNodeIdx(uint idx)
    {
        return GameManager.Instance.ContainerManager.BoatNodeContainer.GetVerticalNeighbors(idx);
    }
}