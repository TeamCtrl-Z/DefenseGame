using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    protected virtual void SMBTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
    protected virtual void SMBNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
    protected virtual void SMBUpdate(Animator animator, int layerIndex) { }
    protected virtual void SMBExit(Animator animator, int layerIndex) { }

}