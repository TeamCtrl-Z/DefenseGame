using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 필터링 SO 클래스
/// </summary>
public abstract class TargetFilterData : ScriptableObject, ITargetFilter
{
    public abstract IEnumerable<ITargetable> Filter(IEnumerable<ITargetable> enemies);
}