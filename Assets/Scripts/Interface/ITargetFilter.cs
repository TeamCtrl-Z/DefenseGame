using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 타겟 후보군들 중 조건을 적용하여 걸러주기 위한 인터페이스
/// </summary>
public interface ITargetFilter
{
    IEnumerable<ITargetable> Filter(IEnumerable<ITargetable> enemies);
}