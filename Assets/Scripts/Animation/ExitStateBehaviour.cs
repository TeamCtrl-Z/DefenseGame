using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitStateBehaviour : CustomSMB
{
    public event Action<Animator, int> OnStateExitEvent;
    protected bool isCompletelyFinished;

    protected override void SMBEnter(Animator animator, int layerIndex)
    {
        isCompletelyFinished = false;
    }

    protected override void SMBNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isCompletelyFinished == false && stateInfo.normalizedTime > 0.7f)
        {
            isCompletelyFinished = true;
            NotifyAnimationExit(animator, layerIndex);
        }
    }

    protected void NotifyAnimationExit(Animator animator, int layerIndex)
    {
        OnStateExitEvent?.Invoke(animator, layerIndex);
    }
}
