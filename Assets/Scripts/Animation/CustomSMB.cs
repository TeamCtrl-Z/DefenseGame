using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 커스텀 스테이트 머신 비헤이비어
/// </summary>
public abstract class CustomSMB : StateMachineBehaviour
{
    public sealed override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SMBEnter(animator, layerIndex);
    }

    public sealed override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.IsInTransition(layerIndex) && animator.GetNextAnimatorStateInfo(layerIndex).fullPathHash == stateInfo.fullPathHash)
        {
            SMBTransitionUpdate(animator, stateInfo, layerIndex);
            SMBUpdate(animator, layerIndex);
        }

        if (animator.IsInTransition(layerIndex) == false)
        {
            SMBNoTransitionUpdate(animator, stateInfo, layerIndex);
            SMBUpdate(animator, layerIndex);
        }
    }
    public sealed override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SMBExit(animator, layerIndex);
    }
    
    protected virtual void SMBEnter(Animator animator, int layerIndex) { }
    /// <summary>
    /// 애니메이션이 전환될 떼 호출되는 함수
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="stateInfo"></param>
    /// <param name="layerIndex"></param>
    protected virtual void SMBTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
    /// <summary>
    /// 애니메이션이 전환되지 않을 때 호출되는 함수
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="stateInfo"></param>
    /// <param name="layerIndex"></param>
    protected virtual void SMBNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
    /// <summary>
    /// 애니메이션 실행중에 호출되는 함수
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="layerIndex"></param>
    protected virtual void SMBUpdate(Animator animator, int layerIndex) { }
    protected virtual void SMBExit(Animator animator, int layerIndex) { }

}