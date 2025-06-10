using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 필터링 SO 클래스
/// </summary>
public abstract class TargetFilterData : ScriptableObject, ITargetFilter
{  
    /// <summary>
    /// 필터링 해주는 함수 인터페이스 구현
    /// </summary>
    /// <param name="enemies"> 적 후보군 </param>
    /// <returns>필터링 된 적 후보군</returns>
    public abstract IEnumerable<ITargetable> Filter(IEnumerable<ITargetable> enemies);
}