using UnityEngine;

/// <summary>
/// 배치 할 수 있는 오브젝트가 가지는 인터페이스
/// </summary>
public interface IPlaceable
{
    /// <summary>
    /// 배치하는 함수
    /// </summary>
    /// <param name="placePosition">배치하는 위치</param>
    public void Place(Vector2 placePosition);
}
