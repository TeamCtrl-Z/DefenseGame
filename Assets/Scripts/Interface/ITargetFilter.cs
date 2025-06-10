using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 타겟 후보군들 중 조건을 적용하여 걸러주기 위한 인터페이스
/// </summary>
public interface ITargetFilter
{
    /// <summary>
    /// 타겟 후보군에서 필터링 해주는 함수
    /// </summary>
    /// <param name="enemies"> 후보군 들 </param>
    /// <returns></returns>
    IEnumerable<ITargetable> Filter(IEnumerable<ITargetable> enemies);
}