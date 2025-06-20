using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 드래그 가능한 UI 노드
/// </summary>
public class NodeObjectUI : NodeBase, IPointerClickHandler
{
    /// <summary>
    /// 드래그가 시작되면 실행하는 이벤트
    /// </summary>
    public event Action<uint> onDragBegin;

    /// <summary>
    /// 드래그가 끝나면 실행되는 이벤트
    /// </summary>
    public event Action<uint?> onDragEnd;

    /// <summary>
    /// 마우스 클릭하면 실행되는 이벤트
    /// </summary>
    public event Action<uint> onClick;

    /// <summary>
    /// 드래그가 시작되면 실행하는 메서드
    /// </summary>
    public void OnBeginDrag()
    {
        Debug.Log($"NodeObjectUI OnBeginDrag {Index}");
        onDragBegin?.Invoke(Index);
    }

    /// <summary>
    /// 드래그가 끝나면 실행하는 메서드
    /// </summary>
    public void OnDrop(PointerEventData eventData) => onDragEnd?.Invoke(Index);

    /// <summary>
    /// 포인터가 들어오면 실행하는 메서드
    /// </summary>
    /// <param name="eventData">포인터 데이터</param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.dragging)
        {
            onDragEnd?.Invoke(Index);
        }
    }

    /// <summary>
    /// 노드를 초기화하는 함수
    /// </summary>
    /// <param name="index">노드의 인덱스</param>
    public void InitializeNode(uint index)
    {
        nodeIndex = index;
    }

    /// <summary>
    /// 모든 이벤트의 메서드를 없애는 함수
    /// </summary>
    public void ClearDelegates()
    {
        onDragBegin = null;
        onDragEnd = null;
    }

    /// <summary>
    /// 이 오브젝트가 클릭되면 실행되는 메서드
    /// </summary>
    /// <param name="eventData">포인터 데이터</param>
    public void OnPointerClick(PointerEventData eventData)
    {
        onClick?.Invoke(Index);
    }
}
