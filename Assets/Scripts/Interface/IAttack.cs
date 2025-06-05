using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 공격을 위한 인터페이스
/// </summary>
public interface IAttack
{
    /// <summary>
    /// 공격 실행
    /// </summary>
    /// <param name="target"> 대상 </param>
    void DoAttack(Transform target);
}
