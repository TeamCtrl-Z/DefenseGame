using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;

/// <summary>
/// 페어리 UI (드래그 가능한 유닛)
/// </summary>
public class FairyUI : RecycleObject, IPlaceable, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    /// <summary>
    /// 페어리를 집으면 실행되는 함수
    /// </summary>
    public event Action onDragBegin;

    /// <summary>
    /// 페어리를 내려놓을 때 실행되는 함수
    /// </summary>
    public event Action<PointerEventData> onDragEnd;

    /// <summary>
    /// 페어리를 배치하면 실행되는 이벤트
    /// </summary>
    public event Action<uint> OnPlaced;

    /// <summary>
    /// NodeContainerUI
    /// </summary>
    private NodeContainerUI container => GameManager.Instance.ContainerManager.BoatNodeContainerUI;

    /// <summary>
    /// 현재 배치된 노드의 인덱스
    /// </summary>
    public uint CurrentNodeIndex { get; private set; }

    /// <summary>
    /// 페어리 FOID
    /// </summary>
    public uint FID { get; private set; }

    private Canvas canvas;
    private GraphicRaycaster raycaster;

    /// <summary>
    /// 초기화
    /// </summary>
    /// <param name="data">해당 페어리 data</param>
    public void Initialize(FairyInstanceData data)
    {
        FID = data.FID;
    }

    /// <summary>
    /// 드래그가 시작되면 실행하는 함수
    /// </summary>
    /// <param name="eventData">포인터 데이터</param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("FairyUI OnBeginDrag");
        onDragBegin?.Invoke();
    }

    /// <summary>
    /// 드래그 중에 실행하는 함수(빈함수)
    /// </summary>
    /// <param name="eventData">포인터 데이터</param>
    public void OnDrag(PointerEventData eventData) { }

    /// <summary>
    /// 드래그가 끝나면 실행하는 함수
    /// </summary>
    /// <param name="eventData">포인터 데이터</param>
    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject target = eventData.pointerEnter;
        if (target == null)
        {
            onDragEnd?.Invoke(eventData);
            return;
        }

        var node = target.GetComponent<NodeObjectUI>();
        if (node != null)
        {
            onDragEnd?.Invoke(eventData);
        }
        else
        {
            onDragEnd?.Invoke(null);
        }
    }

    /// <summary>
    /// 페어리를 배치하는 함수
    /// </summary>
    /// <param name="index">배치할 노드의 인덱스</param>
    public void Place(uint index)
    {
        if (index > container.NodeCount)
        {
            transform.position = container.TempNode.transform.position;
        }
        else
        {
            CurrentNodeIndex = index;
            onDragBegin = null;
            onDragEnd = null;
            Debug.Log($"FairyUI Place called with index: {index}");
            onDragBegin += container[index].OnBeginDrag;
            onDragEnd += container[index].OnDrop;

            transform.SetParent(container[index].transform, false);
            transform.localPosition = Vector3.zero;
            SortOrderFairy();
            OnPlaced?.Invoke(index);
        }
    }

    /// <summary>
    /// FairyUI를 풀로 되돌리는 함수
    /// </summary>
    public override void ReturnToPool()
    {
        base.ReturnToPool();
        gameObject.SetActive(false);
    }

    /// <summary>
    /// SortingOrder를 페어리의 위치에 맞게 설정하는 함수
    /// </summary>
    private void SortOrderFairy()
    {
        if (canvas == null || raycaster == null)
        {
            canvas = gameObject.AddComponent<Canvas>();
            raycaster = gameObject.AddComponent<GraphicRaycaster>();
        }

        canvas.overrideSorting = true;
        canvas.sortingLayerName = "UI";
        canvas.sortingOrder = (int)(-transform.position.y * 1000.0f);
        canvas.vertexColorAlwaysGammaSpace = true;

    }
}
