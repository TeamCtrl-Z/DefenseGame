using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 타겟팅 전략을 위한 인터페이스
/// </summary>
public interface ITargetingStrategy
{
    /// <summary>
    /// 타겟을 선택하는 함수
    /// </summary>
    /// <param name="enemies"> 타겟을 선정할 후보들 </param>
    /// <returns> 선정된 적 Transform </returns>
    public Transform SelectTarget(Transform origin, IEnumerable<ITargetable> enemies);

    /// <summary>
    /// 타겟들을 선택하는 함수
    /// </summary>
    /// <param name="origin">페어리 위치 </param>
    /// <param name="enemies">적 후보군</param>
    /// <param name="count">몇 명</param>
    /// <returns></returns>
    public List<Transform> SelectTargets(Transform origin, IEnumerable<ITargetable> enemies, int count);
}

/// <summary>
/// 타겟팅 전략 SO
/// </summary>
public abstract class TargetingStrategyData : ScriptableObject, ITargetingStrategy
{
    /// <summary>
    /// 적을 선택하는 함수
    /// </summary>
    /// <param name="origin">페어리 위치</param>
    /// <param name="enemies">적 후보군들</param>
    /// <returns>적 Transform</returns>
    public abstract Transform SelectTarget(Transform origin, IEnumerable<ITargetable> enemies);

    /// <summary>
    /// 적들을 선택하는 함수
    /// </summary>
    /// <param name="origin">페어리 위치</param>
    /// <param name="enemies">적 후보군들</param>
    /// <param name="count">적 마릿수</param>
    /// <returns>적 Transform List</returns>
    public abstract List<Transform> SelectTargets(Transform origin, IEnumerable<ITargetable> enemies, int count);
}