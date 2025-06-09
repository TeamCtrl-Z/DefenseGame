using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 상태 패턴Machine 클래스
/// </summary>
/// <typeparam name="T">제네릭 클래스</typeparam>
public class StateMachine<T>
{
    /// <summary>
    /// 오브젝트의 정보를 보내주는 변수
    /// </summary>
    private T sender;

    /// <summary>
    /// sender의 프로퍼티(읽기 전용)
    /// </summary>
    public T Sender => sender;

    /// <summary>
    /// 오브젝트의 현재 상태를 저장하는 프로퍼티
    /// </summary>
    public IState<T> Current { get; private set; }

    /// <summary>
    /// 생성자
    /// </summary>
    /// <param name="sender">오브젝트</param>
    /// <param name="defaultState">초기 상태</param>
    public StateMachine(T sender)
    {
        this.sender = sender;
    }

    /// <summary>
    /// 상태가 전환될 때 실행되는 함수
    /// </summary>
    /// <param name="nextState">다음 상태</param>
    public virtual void TransitionTo(IState<T> nextState)
    {
        if (nextState == null)
            return;

        if (Current == nextState)
            return;

        // 전환되기 전 상태의 Exit() 실행
        if (Current != null)
            Current.Exit(sender);

        // 바꿀 상태로 전화
        Current = nextState;

        // 바꾼 상태의 Enter() 실행
        Current.Enter(sender);
    }

    /// <summary>
    /// 각 상태별 Update 함수
    /// </summary>
    public void Update()
    {
        if (Current != null)
        {
            Current.UpdateState(sender);
        }
    }
}
