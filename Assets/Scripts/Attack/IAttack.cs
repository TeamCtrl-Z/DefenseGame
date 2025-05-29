using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IAttack
{
    /// <summary>
    /// 공격 실행
    /// </summary>
    /// <param name="target"> 대상 </param>
    void DoAttack(Transform target);
}
