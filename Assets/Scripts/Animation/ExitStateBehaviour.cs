using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 애니메이션이 종료되었을 때 호출되는 커스텀 스테이트 머신 비헤이비어
/// </summary>
public class ExitStateBehaviour : CustomSMB
{
    /// <summary>
    /// 애니메이션이 종료되었을 때 알리는 이벤트
    /// </summary>
    public event Action<Animator, int> OnStateExitEvent;
    
    /// <summary>
    /// 애니메이션이 종료되었는지 확인하는 변수
    /// </summary>
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
