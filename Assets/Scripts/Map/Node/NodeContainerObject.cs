using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 노드 컨테이너 오브젝트 클래스
/// </summary>
public class NodeContainerObject : MonoBehaviour
{
    /// <summary>
    /// 드래그 시작을 알리는 델리게이트
    /// </summary>
    public event Action onDragBegin;

    /// <summary>
    /// 드래그 종료를 알리는 델리게이트
    /// </summary>
    public event Action onDragEnd;

    /// <summary>
    /// 컨테이너의 노드들
    /// </summary>
    [SerializeField]
    private NodeObject[] nodes;

    /// <summary>
    /// 컨테이너의 노드의 갯수
    /// </summary>
    public int NodeCount => nodes.Length;

    /// <summary>
    /// 임시 노드
    /// </summary>
    [SerializeField]
    private TempNodeObject tempNode;

    /// <summary>
    /// 컨테이너의 노드에 접근하기 위한 인덱스
    /// </summary>
    /// <param name="index">노드의 인덱스</param>
    /// <returns>인덱스 번째의 노드</returns>
    public NodeObject this[uint index] => nodes[index];

    /// <summary>
    /// 임시 노드 확인용 프로퍼티
    /// </summary>
    public TempNodeObject TempNode => tempNode;

    /// <summary>
    /// 컬럼별 Node 인덱스 맵, k = 반올림 x좌표, v = 그 컬럼의 노드 인덱스 리스트
    /// </summary>
    private Dictionary<int, List<uint>> columnMap;

    /// <summary>
    /// 노드 컨테이너를 초기화 하는 함수
    /// </summary>
    public void InitializeNodeContainer()
    {
        for (uint i = 0; i < nodes.Length; i++)
        {
            nodes[i].InitializeNode(i);
            nodes[i].onDragBegin += OnFairyMoveBegin;
            nodes[i].onDragEnd += OnFairyMoveEnd;
        }

        tempNode.InitializeTempNode();
        BuildColumnMap();
    }

    private void OnDisable()
    {
        ClearAllDelegates();
    }

    /// <summary>
    /// 세로줄 그룹짓는 함수
    /// </summary>
    private void BuildColumnMap()
    {
        columnMap = new Dictionary<int, List<uint>>();

        for (uint i = 0; i < nodes.Length; i++)
        {
            int colKey = Mathf.RoundToInt(nodes[i].transform.position.x);

            if (columnMap.ContainsKey(colKey) == false)
            {
                columnMap[colKey] = new List<uint>();
            }

            columnMap[colKey].Add(i);
        }
    }

    /// <summary>
    /// 드래그가 시작되면 페어리를 집는 함수
    /// </summary>
    /// <param name="index">드래그가 시작되는 인덱스</param>
    private void OnFairyMoveBegin(uint index)
    {
        MoveFairy(index, tempNode.Index);
        onDragBegin?.Invoke();
    }

    /// <summary>
    /// 드래그가 끝나면 페어리를 배치하는 함수
    /// </summary>
    /// <param name="index">드래그가 끝나는 시점의 인덱스</param>
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
    /// 컨테이너의 특정 노드에 페어리를 배치하는 함수
    /// </summary>
    /// <param name="nodeIndex">배치할 노드의 인덱스</param>
    /// <returns>true면 배치 성공, false면 배치 실패</returns>
    public bool PlaceFairy(uint nodeIndex, IPlaceable fairy)
    {
        bool result = false;

        // 인덱스가 정상
        if (IsValidIndex(nodeIndex, out NodeObjectBase node))
        {
            node.PlaceNode(fairy);
            result = true;
        }

        return result;
    }

    /// <summary>
    /// 컨테이너의 특정 노드에 페어리를 제거하는 함수
    /// </summary>
    /// <param name="nodeIndex">제거할 노드의 인덱스</param>
    /// <returns>true면 제거 성공, false면 제거 실패</returns>
    public bool ClearFairy(uint nodeIndex)
    {
        bool result = false;

        if (IsValidIndex(nodeIndex, out NodeObjectBase node))
        {
            if (!node.IsEmpty)
            {
                node.ClearNode();
                result = true;
            }
        }

        return result;
    }

    /// <summary>
    /// 컨테이너의 모든 노드를 비우는 함수
    /// </summary>
    public void ClearContainer()
    {
        foreach (var node in nodes)
        {
            node.ClearNode();
        }
    }

    /// <summary>
    /// 컨테이너의 from노드에 있는 페어리를 to 위치로 옮기는 함수
    /// </summary>
    /// <param name="from">위치 변경 시작 인덱스</param>
    /// <param name="to">위치 변경 도착 인덱스</param>
    public void MoveFairy(uint from, uint to)
    {
        if (from != to
            && IsValidIndex(from, out NodeObjectBase fromNode)
            && IsValidIndex(to, out NodeObjectBase toNode))
        {
            if (!fromNode.IsEmpty)
            {
                if (toNode is TempNodeObject)
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

    public bool TryGetFairyAt(uint index, out IPlaceable fairy)
    {
        fairy = null;
        if (IsValidIndex(index, out NodeObjectBase node))
        {
            if (node.IsEmpty == false)
            {
                fairy = node.Fairy;
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 옮기는 것을 취소하는 함수
    /// </summary>
    public void CancelMove()
    {
        uint fromIndex = (uint)TempNode.FromIndex;
        PlaceFairy(fromIndex, TempNode.Fairy);
        tempNode.ClearNode();

    }

    /// <summary>
    /// Index 노드와 같은 세로줄에 있는 다른 노드 인덱스들을 리턴
    /// </summary>
    /// <param name="index"> 노드 인덱스 </param>
    /// <returns></returns>
    public List<uint> GetVerticalNeighbors(uint index)
    {
        if (index >= nodes.Length) return new List<uint>();

        int colKey = Mathf.RoundToInt(nodes[index].transform.position.x);
        if (columnMap.TryGetValue(colKey, out var list) == false)
            return new List<uint>();

        return list.ToList();
    }

    /// <summary>
    /// 노드 인덱스가 적절한 인덱스인지 확인하는 함수
    /// </summary>
    /// <param name="index">확인할 인덱스 번호</param>
    /// <param name="targetNode">index가 가리키는 노드</param>
    /// <returns>존재하는 인덱스면 true, 아니면 false</returns>
    private bool IsValidIndex(uint index, out NodeObjectBase targetNode)
    {
        targetNode = null;

        if (index < NodeCount)
        {
            targetNode = nodes[index];
        }
        else if (index == tempNode.TempNodeIndex)
        {
            targetNode = TempNode;
        }

        return targetNode != null;
    }

    /// <summary>
    /// 모든 델리게이트들을 해제하는 함수
    /// </summary>
    private void ClearAllDelegates()
    {
        for (uint i = 0; i < nodes.Length; i++)
        {
            nodes[i].ClearDelegates();
        }
    }
}
