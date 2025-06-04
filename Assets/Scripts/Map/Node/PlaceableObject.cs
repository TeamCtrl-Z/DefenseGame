using System;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 배치 가능한 오브젝트를 나타내는 클래스
/// </summary>
public class PlaceableObject : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPlaceable
{
    /// <summary>
    /// 드래그가 시작될 때 호출되는 이벤트
    /// </summary>
    public event Action onDragBegin;

    /// <summary>
    /// 드래그가 끝날 때 호출되는 이벤트
    /// </summary>
    public event Action<PointerEventData> onDragEnd;

    /// <summary>
    /// 페어리가 배치됐을 때 호출되는 이벤트
    /// </summary>
    public event Action<uint> OnPlaced;

    /// <summary>
    /// 컨테이너 매니저
    /// </summary>
    private ContainerManager containerManager;

    /// <summary>
    /// 오브젝트 풀의 트랜스폼
    /// </summary>
    Transform poolTransform;

    /// <summary>
    /// 현재 노드 인덱스를 반환하는 프로퍼티
    /// </summary>
    public uint CurrentNodeIndex { get; private set; }

    private void Awake()
    {
        containerManager = GameManager.Instance.ContainerManager;
        poolTransform = transform.parent;
    }

    /// <summary>
    /// 드래그가 시작되면 호출되는 함수
    /// </summary>
    /// <param name="eventData">이벤트 데이터</param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        onDragBegin?.Invoke();
    }

    /// <summary>
    /// 드래그 중에 호출되는 함수(빈함수)
    /// </summary>
    /// <param name="eventData">이벤트 데이터</param>
    public void OnDrag(PointerEventData eventData)
    {
    }

    /// <summary>
    /// 드래그가 끝나면 호출되는 함수
    /// </summary>
    /// <param name="eventData">이벤트 데이터</param>
    public void OnEndDrag(PointerEventData eventData)
    {
        onDragEnd?.Invoke(eventData);
    }

    /// <summary>
    /// 배치하는 함수
    /// </summary>
    /// <param name="index">배치하는 노드의 번호</param>
    public void Place(uint index)
    {
        if (index > containerManager.BoatNodeContainer.NodeCount)
        {
            transform.position = containerManager.BoatNodeContainer.TempNode.transform.position;
        }
        else
        {
            CurrentNodeIndex = index;
            onDragBegin = null;
            onDragEnd = null;
            onDragBegin += containerManager.BoatNodeContainer[index].OnBeginDrag;
            onDragEnd += containerManager.BoatNodeContainer[index].OnEndDrag;
            transform.SetParent(containerManager.BoatNodeContainer[index].transform, false);
            transform.position = containerManager.BoatNodeContainer[index].transform.position;
            SortOrderFairy();
            OnPlaced?.Invoke(index);
        }
    }

    /// <summary>
    /// 원래의 풀로 되돌리는 함수
    /// </summary>
    public void ReturnToPool()
    {
        transform.SetParent(poolTransform, false);
    }

    /// <summary>
    /// SortingOrder를 페어리의 위치에 맞게 설정하는 함수
    /// </summary>
    private void SortOrderFairy()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sortingOrder = -Mathf.FloorToInt(transform.position.y * 1000);
    }
}
