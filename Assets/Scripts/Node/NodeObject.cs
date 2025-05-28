using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeObject : NodeObjectBase
{
    /// <summary>
    /// 드래그의 시작을 알리는 델리게이트(unit:드래그를 시작한 슬롯의 인덱스)
    /// </summary>
    public event Action<uint> onDragBegin;

    /// <summary>
    /// 드래그의 종료를 알리는 델리게이트(unit?:드래그가 끝난 슬롯의 인덱스(null이면 슬롯이 아닌 곳에서 종료))
    /// </summary>
    public event Action<uint?> onDragEnd;

    /// <summary>
    /// 노드 오브젝트의 레이어
    /// </summary>
    private LayerMask layerMask;

    private void Awake()
    {
        layerMask = LayerMask.GetMask("NodeObject");
    }

    /// <summary>
    /// 드래그가 시작되면 실행되는 함수
    /// </summary>
    public void OnBeginDrag()
    {
        onDragBegin?.Invoke(Index);
    }

    /// <summary>
    /// 드래그가 끝나면 실행되는 함수
    /// </summary>
    public void OnEndDrag(PointerEventData eventData)
    {
        uint? endIndex = null;

        Vector2 wp = Camera.main.ScreenToWorldPoint(eventData.position);

        Collider2D[] hits = Physics2D.OverlapPointAll(wp, layerMask);
        foreach (var hit in hits)
        {
            var node = hit.GetComponent<NodeObject>();
            if (node != null)
            {
                endIndex = node.Index;
                break;
            }
        }

        onDragEnd?.Invoke(endIndex);
    }

    /// <summary>
    /// 노드를 초기화 하는 함수
    /// </summary>
    /// <param name="index">노드의 인덱스</param>
    public void InitializeNode(uint index)
    {

        nodeIndex = index;
    }

    /// <summary>
    /// 모든 참조를 없애는 함수
    /// </summary>
    public void ClearDelegates()
    {
        onDragBegin = null;
        onDragEnd = null;
    }
}
