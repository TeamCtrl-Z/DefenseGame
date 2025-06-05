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

    /// <summary>
    /// 애니메이션이 시작될 때 호출되는 함수
    /// </summary>
    /// <param name="animator">애니메이션을 가진 애니메이터</param>
    /// <param name="layerIndex">애니메이션의 레이어 번호</param>
    protected override void SMBEnter(Animator animator, int layerIndex)
    {
        isCompletelyFinished = false;
    }

    /// <summary>
    /// 애니메이션이 전환상태가 아닐 때 호출되는 함수
    /// </summary>
    /// <param name="animator">애니메이션을 가진 애니메이터</param>
    /// <param name="stateInfo">상태 정보</param>
    /// <param name="layerIndex">애니메이션의 레이어 번호</param>
    protected override void SMBNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isCompletelyFinished == false && stateInfo.normalizedTime > 0.7f)
        {
            isCompletelyFinished = true;
            NotifyAnimationExit(animator, layerIndex);
        }
    }

    /// <summary>
    /// 애니메이션 끝을 알리기위한 함수
    /// </summary>
    /// <param name="animator">현재 에니메이터</param>
    /// <param name="layerIndex">애니메이션의 레이어 번호</param>
    protected void NotifyAnimationExit(Animator animator, int layerIndex)
    {
        OnStateExitEvent?.Invoke(animator, layerIndex);
    }
}
