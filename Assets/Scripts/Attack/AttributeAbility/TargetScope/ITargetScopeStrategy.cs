using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ITargetStrategy와 다른 인터페이스, 속성 능력을 발휘할 대상 지정(ITargetStrategy로 합칠 생각 해야 함.)
/// </summary>
public interface ITargetScopeStrategy
{
    /// <summary>
    /// 속성 능력을 발동할 대상들을 선정
    /// </summary>
    /// <param name="executer"> 속성 능력을 실행한 사람 </param>
    /// <param name="origin"> 선정하기 위한 기준점 </param>
    /// <returns></returns>
    IEnumerable<GameObject> SelectTargets(GameObject origin);
}