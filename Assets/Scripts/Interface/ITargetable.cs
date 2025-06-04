using UnityEngine;

/// <summary>
/// 타겟으로 지정할 수 있는 Interface
/// </summary>
public interface ITargetable
{
    /// <summary>
    /// 타겟의 Transform
    /// </summary>
    Transform Transform { get; }

    /// <summary>
    /// 타겟이 살아 있는 지
    /// </summary>
    public bool IsAlive { get; }

    /// <summary>
    /// 타겟의 디버프 상태를 가져오기 위한 함수
    /// </summary>
    /// <returns></returns>
    IStatusEffectProvider GetStatusEffectProvider();
}