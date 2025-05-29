using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FairyStatusComponent))]
[RequireComponent(typeof(Animator))]
public class FairyController : RecycleObject
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
    }

    protected void Start()
    {
        fairyStateMachine = new FairyStateMachine(this, animator, fairyStatusComponent as IBattleStatus, attackHandler);
    }

    private void Update()
    {
        // State별로 Update함수 실행하기
        fairyStateMachine.Update();
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
