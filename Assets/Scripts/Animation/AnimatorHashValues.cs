using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimatorHash
{
    /// <summary>
    /// 애니메이터 해시 값을 저장하는 클래스(static)
    /// </summary>
    public static class Fairy
    {
        // 해시 값
        public static readonly int AttackTrigger = Animator.StringToHash("Attack");
    }
}
