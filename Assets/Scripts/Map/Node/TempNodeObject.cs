using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 임시 노드 오브젝트 클래스
/// </summary>
public class TempNodeObject : NodeObjectBase
{
    /// <summary>
    /// 임시 노드용 인덱스(안쓰는 인덱스 숫자)
    /// </summary>
    private const uint tempNodeIndex = 99999999;

    /// <summary>
    /// 임시 노드용 인덱스를 확인하기 위한 프로퍼티
    /// </summary>
    public uint TempNodeIndex => tempNodeIndex;

    /// <summary>
    /// 드래그를 시작한 노드의 인덱스(null이면 드래그가 시작 안됨)
    /// </summary>
    public uint? FromIndex { get; set; }

    private void Update()
    {
        transform.position = GetMouseWorldPosition();
        if (Fairy != null)
            Fairy.Place(tempNodeIndex);
    }

    /// <summary>
    /// Node에 페어리를 배치하는 함수
    /// </summary>
    /// <param name="fairy">배치할 Fairy</param>
    public override void PlaceNode(IPlaceable fairy)
    {
        if (fairy != null)
        {
            this.fairy = fairy;
            fairy.Place(tempNodeIndex);
            isEmpty = false;
        }
        else
        {
            ClearNode();
        }
    }

    /// <summary>
    /// 이 노드의 페어리를 제거하는 함수
    /// </summary>
    public override void ClearNode()
    {
        base.ClearNode();
        FromIndex = null;
    }

    /// <summary>
    /// temp 노드를 초기화 하는 함수
    /// </summary>
    /// <param name="index"></param>
    public void InitializeTempNode()
    {
        FromIndex = null;
        nodeIndex = tempNodeIndex;
    }

    /// <summary>
    /// 화면상의 마우스 위치를 2D좌표로 변환하여 반환하는 함수
    /// </summary>
    /// <returns>변환된 위치</returns>
    private Vector3 GetMouseWorldPosition()
    {
        Vector2 pos2D = Mouse.current.position.ReadValue();
        Vector3 screenPos = new Vector3(pos2D.x, pos2D.y, -Camera.main.transform.position.z);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0f;
        return worldPos;
    }
}
