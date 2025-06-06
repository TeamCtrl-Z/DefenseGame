using UnityEngine;

/// <summary>
/// 배치 할 수 있는 오브젝트가 가지는 인터페이스
/// </summary>
public interface IPlaceable
{
    /// <summary>
    /// 배치하는 함수
    /// </summary>
    /// <param name="index">배치하는 노드의 번호</param>
    public void Place(uint index);
}
