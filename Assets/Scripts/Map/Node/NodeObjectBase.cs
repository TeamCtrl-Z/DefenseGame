using System;
using UnityEngine;

/// <summary>
/// 노드 오브젝트의 기본 클래스
/// </summary>
public class NodeObjectBase : MonoBehaviour
{
    /// <summary>
    /// NodeContainer에서 몇 번째 노드인지를 나타내는 변수
    /// </summary>
    protected uint nodeIndex;

    /// <summary>
    /// 노드의 인덱스를 확인하기 위한 프로퍼티
    /// </summary>
    public uint Index => nodeIndex;

    /// <summary>
    /// 이 노드에 배치됐는지 기록하는 변수
    /// </summary>
    protected bool isEmpty = true;

    /// <summary>
    /// 이 노드에 배치됐는지 알려주는 프로퍼티 
    /// </summary>
    public bool IsEmpty => isEmpty;

    /// <summary>
    /// 이 노드가 가지고 있는 페어리
    /// </summary>
    protected IPlaceable fairy;

    /// <summary>
    /// 이 노드가 가지고 있는 페어리를 알려주는 프로퍼티
    /// </summary>
    public IPlaceable Fairy => fairy;

    public event Action<uint, IPlaceable> OnPlacedFairy;

    /// <summary>
    /// 이 노드에 페어리를 추가하는 함수
    /// </summary>
    public virtual void PlaceNode(IPlaceable fairy)
    {
        if (fairy != null)
        {
            this.fairy = fairy;
            fairy.Place(Index);
            isEmpty = false;

            OnPlacedFairy?.Invoke(Index, fairy);
        }
        else
        {
            Debug.Log("PlaceNode");
            ClearNode();
            OnPlacedFairy?.Invoke(Index, null);
        }
    }

    /// <summary>
    /// 이 노드에 들어있는 페어리를 제거하는 함수
    /// </summary>
    public virtual void ClearNode()
    {
        isEmpty = true;
        fairy = null;
    }
}
