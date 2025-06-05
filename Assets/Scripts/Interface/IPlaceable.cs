using System;

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

    /// <summary>
    /// 배치가 완료되었을 때 호출되는 이벤트
    /// </summary>
    public event Action<uint> OnPlaced;
}
