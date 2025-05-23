using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FairyStatusComponent))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(TargetingComponent))]
[RequireComponent(typeof(AttackHandler))]
public class FairyController : RecycleObject, IPlaceable
{
    public Transform TargetTransform => targetingComponent.GetTarget();
    /// <summary>
    /// StateMachine
    /// </summary>
    private FairyStateMachine fairyStateMachine;
    private Animator animator;
    private FairyStatusComponent fairyStatusComponent;
    private TargetingComponent targetingComponent;
    private AttackHandler attackHandler;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        fairyStatusComponent = GetComponent<FairyStatusComponent>();
        targetingComponent = GetComponent<TargetingComponent>();
        attackHandler = GetComponent<AttackHandler>();
        fairyStateMachine = new FairyStateMachine(this, animator, fairyStatusComponent as IBattleStatus, attackHandler);
    }

    private void Update()
    {
        // State별로 Update함수 실행하기
        fairyStateMachine.Update();
    }

    /// <summary>
    /// 페어리를 배치하는 함수
    /// </summary>
    /// <param name="placePosition"> 배치할 위치 </param>
    public void Place(Vector2 placePosition)
    {
        transform.position = placePosition;
    }

    //에디터가 실행 중일 때만
    private void OnDrawGizmosSelected()
    {
        if (Application.isPlaying == false)
            return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, targetingComponent.AttackRange);  // radius = 5
    }
}
