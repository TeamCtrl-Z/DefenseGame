using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 드래그 처리 및 노드 관리 클래스 (UI 전용)
/// </summary>
public class NodeContainerUI : MonoBehaviour
{
    /// <summary>
    /// 드래그가 시작되면 실행되는 이벤트
    /// </summary>
    public event Action onDragBegin;

    /// <summary>
    /// 드래그가 끝나면 실행되는 이벤트
    /// </summary>
    public event Action onDragEnd;

    /// <summary>
    /// 노드 UI의 배열
    /// </summary>
    [SerializeField] private NodeObjectUI[] nodes;

    /// <summary>
    /// 임시 노드
    /// </summary>
    [SerializeField] private TempNodeObjectUI tempNode;

    /// <summary>
    /// 노드들의 길이
    /// </summary>
    public int NodeCount => nodes.Length;

    /// <summary>
    /// 노드를 Index로 찾는 인덱서
    /// </summary>
    /// <param name="index">노드의 인덱스</param>
    /// <returns>해당 인덱스의 노드</returns>
    public NodeObjectUI this[uint index] => nodes[index];

    /// <summary>
    /// 임시 노드를 반환하는 프로퍼티
    /// </summary>
    public TempNodeObjectUI TempNode => tempNode;

    /// <summary>
    /// 페어리 데이터
    /// </summary>
    private FairyInstanceData fairyData;

    /// <summary>
    /// NodeContainerUI를 초기화 하는 함수
    /// </summary>
    public void InitializeNodeContainer()
    {
        for (uint i = 0; i < nodes.Length; i++)
        {
            nodes[i].InitializeNode(i);
            nodes[i].onDragBegin += OnFairyMoveBegin;
            nodes[i].onDragEnd += OnFairyMoveEnd;
            nodes[i].onClick += ((index) => {
                if (fairyData != null)
                {
                    FairyUI fairyUI = DataService.Instance.FairyDataManager.SpawnFairyUIByFid(fairyData.FID, Vector2.zero);
                    IPlaceable fairy = fairyUI as IPlaceable;
                    PlaceFairy(index, fairy);
                }
            });

        }

        tempNode.InitializeTempNode();
        GameManager.Instance.InputManager.onTouch += CancelPlacement;
        fairyData = null;
    }

    private void OnDisable()
    {
        ClearAllDelegates();
    }

    /// <summary>
    /// 페어리 이동을 시작하면 실행하는 함수
    /// </summary>
    /// <param name="index">시작한 노드의 인덱스</param>
    private void OnFairyMoveBegin(uint index)
    {
        MoveFairy(index, tempNode.Index);
        onDragBegin?.Invoke();
    }

    /// <summary>
    /// 페어리 이동이 끝나면 실행하는 함수
    /// </summary>
    /// <param name="index">끝나는 노드의 인덱스</param>
    private void OnFairyMoveEnd(uint? index)
    {
        if (index.HasValue)
        {
            MoveFairy(tempNode.Index, index.Value);
        }
        else
        {
            CancelMove();
        }
        onDragEnd?.Invoke();
    }

    /// <summary>
    /// 페어리를 from에서 to로 이동하는 함수
    /// </summary>
    /// <param name="from">from노드의 인덱스</param>
    /// <param name="to">to노드의 인덱스</param>
    public void MoveFairy(uint from, uint to)
    {
        if (from != to
            && IsValidIndex(from, out NodeBase fromNode)
            && IsValidIndex(to, out NodeBase toNode))
        {
            if (!fromNode.IsEmpty)
            {
                if (toNode is TempNodeObjectUI)
                {
                    tempNode.FromIndex = from;
                    PlaceFairy(to, fromNode.Fairy);
                    fromNode.ClearNode();
                }
                else
                {
                    uint fromIndex = (uint)TempNode.FromIndex;
                    PlaceFairy(fromIndex, toNode.Fairy);
                    PlaceFairy(to, fromNode.Fairy);
                    fromNode.ClearNode();
                }
            }
        }
    }

    /// <summary>
    /// 페어리를 배치하는 함수
    /// </summary>
    /// <param name="nodeIndex">배치할 노드의 인덱스</param>
    /// <param name="fairy">배치할 페어리</param>
    public void PlaceFairy(uint nodeIndex, IPlaceable fairy)
    {
        if (IsValidIndex(nodeIndex, out NodeBase node))
        {
            node.PlaceNode(fairy);
        }
    }

    /// <summary>
    /// 이동을 취소하는 함수
    /// </summary>
    public void CancelMove()
    {
        uint fromIndex = (uint)TempNode.FromIndex;
        PlaceFairy(fromIndex, TempNode.Fairy);
        tempNode.ClearNode();
    }

    /// <summary>
    /// 인덱스가 범위 내의 인덱스가 맞는지 알려주는 함수
    /// </summary>
    /// <param name="index">인덱스</param>
    /// <param name="node">인덱스에 해당하는 노드</param>
    /// <returns>성공하면 true 실패하면 false</returns>
    private bool IsValidIndex(uint index, out NodeBase node)
    {
        node = null;
        if (index < nodes.Length)
            node = nodes[index];
        else if (index == tempNode.TempNodeIndex)
            node = tempNode;

        return node != null;
    }

    /// <summary>
    /// 슬롯을 터치하면 실행되는 함수
    /// </summary>
    /// <param name="fairyData">슬롯의 페어리 데이터</param>
    public void SelectSlotForPlacement(FairyInstanceData fairyData)
    {
        if (fairyData == null)
        {
            this.fairyData = fairyData;
            for (uint i = 0; i < NodeCount; i++)
            {
                HighlightOverlayUI overlay = nodes[i].GetComponent<HighlightOverlayUI>();
                if (nodes[i].IsEmpty) overlay.StartGlow();
            }
        }
    }

    /// <summary>
    /// 배치하는 것을 취소하는 함수
    /// </summary>
    /// <param name="screen">터치 위치</param>
    private void CancelPlacement(Vector2 screen)
    {
        if (fairyData != null)
        {
            Vector2 diff = screen - (Vector2)transform.position;

            RectTransform rectTransform = (RectTransform)transform;
            if (!rectTransform.rect.Contains(diff))
            {
                fairyData = null;
                for (uint i = 0; i < NodeCount; i++)
                {
                    HighlightOverlayUI overlay = nodes[i].GetComponent<HighlightOverlayUI>();
                    if (nodes[i].IsEmpty) overlay.EndGlow();
                }
            }
        }
    }

    /// <summary>
    /// 노드들의 이벤트에 구독된 메서드를 전부 해제하는 함수
    /// </summary>
    public void ClearAllDelegates()
    {
        foreach (var node in nodes)
            node.ClearDelegates();
    }
}

