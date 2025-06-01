using UnityEngine;

/// <summary>
/// 타겟으로 지정할 수 있는 Interface
/// </summary>
public interface ITargetable
{
    Transform Transform { get; }
    public bool IsAlive { get; }
    IStatusEffectProvider GetStatusEffectProvider();
}