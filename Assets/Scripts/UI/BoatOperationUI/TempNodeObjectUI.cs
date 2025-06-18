using UnityEngine;

/// <summary>
/// 임시 UI 노드 (드래그 중 마우스를 따라다니는 페어리 위치)
/// </summary>
public class TempNodeObjectUI : NodeBase
{
    /// <summary>
    /// 임시 노드의 인덱스
    /// </summary>
    private const uint tempNodeIndex = 99999999;

    /// <summary>
    /// 임시 노드의 인덱스를 반환하는 프로퍼티
    /// </summary>
    public uint TempNodeIndex => tempNodeIndex;

    /// <summary>
    /// 페어리UI를 집기 시작한 인덱스
    /// </summary>
    public uint? FromIndex { get; set; }

    private void Update()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform.parent as RectTransform,
            Input.mousePosition,
            null,
            out Vector2 localPoint);

        transform.localPosition = localPoint;

        if (Fairy != null)
            Fairy.Place(tempNodeIndex);
    }

    /// <summary>
    /// 페어리를 임시노드에 배치하는 함수
    /// </summary>
    /// <param name="fairy">배치되는 페어리</param>
    public override void PlaceNode(IPlaceable fairy)
    {
        this.fairy = fairy;
        isEmpty = false;
    }

    /// <summary>
    /// 노드에 페어리를 없애는 함수
    /// </summary>
    public override void ClearNode()
    {
        base.ClearNode();
        FromIndex = null;
    }

    /// <summary>
    /// 임시노드를 초기화 하는 함수
    /// </summary>
    public void InitializeTempNode()
    {
        FromIndex = null;
        nodeIndex = tempNodeIndex;
    }
}
