using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 버프 타입
/// </summary>
public enum BuffType
{
    AttackSpeed = 0, AttackPower,
}

/// <summary>
/// 주변의 아군을 버프 시켜주는 기능
/// </summary>
public class BuffProvider : MonoBehaviour
{
    /// <summary>
    /// 무엇을 버프 시켜줄 것인지
    /// </summary>
    [SerializeField] private BuffType buffType;

    /// <summary>
    /// 얼만큼 버프 시켜줄 것인지(배수)
    /// </summary>
    [SerializeField] private float amount;

    /// <summary>
    /// 버프를 줄 주변의 이웃 노드들에 대한 Data
    /// </summary>
    [SerializeField] private BuffTargetStrategyData buffNeighbors;

    /// <summary>
    /// 노드 컨테이너를 반환하는 프로퍼티
    /// </summary>
    private NodeContainerObject NodeContainer => GameManager.Instance.ContainerManager.BoatNodeContainer;

    /// <summary>
    /// 버프를 주고 있는 페어리 테이블 - K : 노드 Idx, V : IPlaceable
    /// </summary>
    private Dictionary<uint, IPlaceable> buffTable = new();

    /// <summary>
    /// 리스트 형태로 버프를 줄 노드들의 인덱스
    /// </summary>
    private List<uint> neighborsIdx = new();

    private void OnEnable()
    {
        IPlaceable placeable = GetComponent<IPlaceable>();
        placeable.OnPlaced -= HandlePlaced;
        placeable.OnPlaced += HandlePlaced;
    }

    /// <summary>
    /// 내가 노드를 이동했을 때 불리는 함수
    /// </summary>
    /// <param name="idx">이동한 노드 idx</param>
    private void HandlePlaced(uint idx)
    {
        Debug.Log("HandlePlaced");
        // 기존의 버프 주는 노드의 이벤트들 구독 해제, 버프 주는 페어리들 버프 해제
        foreach (uint i in neighborsIdx)
        {
            StopBuff(i);
            NodeContainer[i].OnPlacedFairy -= HandlePlacedFairy;
        }

        // 새롭게 버프 줄 노드의 이벤트들 구독, 해당 노드에 있는 페어리들 버프 시작
        neighborsIdx = buffNeighbors.GetNeighborsNodeIdx(idx);
        foreach (uint i in neighborsIdx)
        {
            buffTable[i] = null;
            if (NodeContainer.TryGetFairyAt(i, out IPlaceable fairy))
            {
                StartBuff(i, fairy);
            }
            NodeContainer[i].OnPlacedFairy += HandlePlacedFairy;
        }
    }

    /// <summary>
    /// 버프를 주고 있는 노드에 페어리가 배치가 됐거나, 배치가 해제되면 불리는 함수
    /// </summary>
    /// <param name="idx"> 노드 인덱스 </param>
    /// <param name="fairy"> 배치된 페어리 </param>
    private void HandlePlacedFairy(uint idx, IPlaceable fairy)
    {
        // 배치가 해제된 경우
        if (fairy == null)
        {
            StopBuff(idx);
            return;
        }

        // 배치된 아군이 바뀐 경우
        if (buffTable[idx] != fairy)
        {
            StopBuff(idx);
            StartBuff(idx, fairy);
            return;
        }

        // 새롭게 아군이 추가된 경우
        StartBuff(idx, fairy);
    }

    /// <summary>
    /// 해당 idx 노드에 배치된 페어리 버프 해제
    /// </summary>
    /// <param name="fairy"></param>
    private void StopBuff(uint idx)
    {
        if (buffTable[idx] == null) return;

        MonoBehaviour mono = buffTable[idx] as MonoBehaviour;
        if (mono.TryGetComponent<IBuffStatus>(out IBuffStatus buff))
        {
            buff.BuffStop(buffType);
            buffTable[idx] = null;
        }
    }

    /// <summary>
    /// 해당 idx 노드에 배치된 페어리 버프 시작
    /// </summary>
    /// <param name="idx"></param>
    private void StartBuff(uint idx, IPlaceable fairy)
    {
        MonoBehaviour mono = fairy as MonoBehaviour;
        if (mono.TryGetComponent<IBuffStatus>(out IBuffStatus buff))
        {
            buff.BuffStatus(buffType, amount);
            buffTable[idx] = fairy;
        }
    }

    /// <summary>
    /// 버프 주는 Fairy들 모두 중단
    /// </summary>
    private void StopBuffAll()
    {
        foreach (var buff in buffTable)
        {
            StopBuff(buff.Key);
        }
    }
}