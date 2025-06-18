using System;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 페어리 UI (드래그 가능한 유닛)
/// </summary>
public class FairyUI : RecycleObject, IPlaceable, IBeginDragHandler, IEndDragHandler, IDragHandler, ICharacterIdentity
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
    /// 페어리가 배치되면 실행되는 이벤트
    /// </summary>
    public event Action<uint> OnPlaced;

    /// <summary>
    /// NodeContainerUI
    /// </summary>
    private NodeContainerUI container;

    /// <summary>
    /// 현재 배치된 노드의 인덱스
    /// </summary>
    public uint CurrentNodeIndex { get; private set; }

    /// <summary>
    /// 페어리 fid
    /// </summary>
    [field: SerializeField]
    public uint ID { get; private set; }

    /// <summary>
    /// 페어리 FOID
    /// </summary>
    public string FOID { get; private set; }

    private void Start()
    {
        container = GameManager.Instance.ContainerManager.BoatNodeContainerUI;
    }

    /// <summary>
    /// 초기화
    /// </summary>
    /// <param name="foid">해당 페어리 foid</param>
    public void Initialize(FairyInstanceData data)
    {
        FOID = data.FOID;
    }

    /// <summary>
    /// 드래그가 시작되면 실행하는 함수
    /// </summary>
    /// <param name="eventData">포인터 데이터</param>
    public void OnBeginDrag(PointerEventData eventData) => onDragBegin?.Invoke();

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
            onDragBegin += container[index].OnBeginDrag;
            onDragEnd += container[index].OnDrop;

            transform.SetParent(container[index].transform, false);
            transform.localPosition = Vector3.zero;
            OnPlaced?.Invoke(index);
        }
    }
}
