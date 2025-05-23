using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeObject : NodeObjectBase, IDragHandler, IBeginDragHandler, IEndDragHandler
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
    /// 드래그가 시작되면 실행되는 함수
    /// </summary>
    public void OnBeginDrag(PointerEventData eventData)
    {
        onDragBegin?.Invoke(Index);
    }

    /// <summary>
    /// 드래그 중일 때 실행되는 함수(빈함수)
    /// </summary>
    public void OnDrag(PointerEventData eventData)
    {
    }

    /// <summary>
    /// 드래그가 끝나면 실행되는 함수
    /// </summary>
    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject obj = eventData.pointerCurrentRaycast.gameObject;
        uint? endIndex = null;
        if (obj != null)
        {
            NodeObject endNode = obj.GetComponent<NodeObject>();
            if (endNode != null)
            {
                endIndex = endNode.Index;
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
