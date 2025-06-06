using UnityEngine;

namespace AnimatorHash
{
    /// <summary>
    /// 애니메이터 해시 값을 저장하는 클래스(static) - 적용 대상: Fairy
    /// </summary>
    public static class Fairy
    {
        /// <summary>
        /// 페어리 Attack 애니메이션의 해시 값
        /// </summary>
        public static readonly int AttackTrigger = Animator.StringToHash("Attack");
    }

    /// <summary>
    /// 애니메이터 해시 값을 저장하는 클래스(static) - 적용 대상: Enemy
    /// </summary>
    public static class Enemy
    {
        /// <summary>
        /// 적 Attack 애니메이션의 해시 값
        /// </summary>
        public static readonly int AttackTrigger = Animator.StringToHash("Attack");
    }
}
