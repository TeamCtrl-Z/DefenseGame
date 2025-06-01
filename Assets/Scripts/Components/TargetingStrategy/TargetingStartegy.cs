using System.Collections.Generic;
using UnityEngine;

public interface ITargetingStrategy
{
    /// <summary>
    /// 타겟을 선택하는 함수
    /// </summary>
    /// <param name="enemies"> 타겟을 선정할 후보들 </param>
    /// <returns> 선정된 적 Transform </returns>
    public Transform SelectTarget(Transform origin, IEnumerable<ITargetable> enemies);
}

public abstract class TargetingStrategyData : ScriptableObject, ITargetingStrategy
{
    public abstract Transform SelectTarget(Transform origin, IEnumerable<ITargetable> enemies);
}