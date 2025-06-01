using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AnimatorHash;
using UnityEngine;

/// <summary>
/// 페어리의 공격을 처리하는 컴포넌트
/// </summary>
[RequireComponent(typeof(TargetingComponent))]
public class AttackHandler : MonoBehaviour
{
    /// <summary>
    /// Fairy가 사용할 공격
    /// </summary>
    [SerializeField] private AttackBase attack;

    /// <summary>
    /// 공격속도와 공격력을 알아내기 위한 변수
    /// </summary>
    private IBattleStatus status;

    /// <summary>
    /// 타겟을 선정하기 위한 변수
    /// </summary>
    private TargetingComponent targeting;

    /// <summary>
    /// 마지막으로 공격한 시간
    /// </summary>
    private float lastAttackTime;

    /// <summary>
    /// 공격 쿨타임
    /// </summary>
    private float coolTime => status.AttackSpeed;

    private Animator animator;

    public event Action OnAttack;

    private void Awake()
    {
        status = GetComponentInParent<IBattleStatus>();
        targeting = GetComponent<TargetingComponent>();
        animator = GetComponentInParent<Animator>();
    }

    private void Start()
    {
        attack.Initialize(GetComponentInParent<FairyController>());
    }

    private void Update()
    {
        if (CanAttack() == false)
            return;

        Transform chosen = targeting.SelectTarget(targeting.TargetsInRange);
        if (chosen != null)
            DoAttack(chosen);
    }
    public bool CanAttack()
    {
        return Time.time >= lastAttackTime + coolTime
            && targeting.TargetsInRange.Any();
    }

    public void DoAttack(Transform target)
    {
        attack.DoAttack(target);
        lastAttackTime = Time.time;
        animator.SetTrigger(AnimatorHash.Fairy.AttackTrigger);
        OnAttack?.Invoke();
    }
}
