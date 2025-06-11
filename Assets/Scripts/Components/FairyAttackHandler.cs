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
[DefaultExecutionOrder(ExcutionOrder.Main)]
public class FairyAttackHandler : MonoBehaviour
{
    /// <summary>
    /// 고유 공격 클래스
    /// </summary>
    private AttackBase attack;

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

    /// <summary>
    /// Fairy의 Animator
    /// </summary>
    private Animator animator;

    /// <summary>
    /// 공격을 시작할 때 알리기 위한 이벤트
    /// </summary>
    public event Action OnAttack;

    /// <summary>
    /// 외부에 공격했다는 것을 알리기 위한 이벤트
    /// </summary>
    public event Action<IDamageable, Vector3> OnHit;

    private void Awake()
    {
        status = GetComponentInParent<IBattleStatus>();
        targeting = GetComponent<TargetingComponent>();
        animator = GetComponentInParent<Animator>();
        BuildAttack();
    }

    /// <summary>
    /// 공격을 만드는 함수
    /// </summary>
    private void BuildAttack()
    {
        HittingData data = new HittingData();
        data.Damage = status.AttackPower;

        attack = status.AttackType switch
        {
            AttackType.Projectile => new ProjectileAttack(data, GetComponentInParent<FairyController>(), 0),
            _ => null
        };

        if (attack == null)
            Debug.LogError($"{transform.parent.name} : {status.AttackType}은 존재하지 않습니다.");
    }

    private void OnEnable()
    {
        attack.OnHit -= OnHitRecieved;
        attack.OnHit += OnHitRecieved;
    }

    private void Update()
    {
        if (CanAttack() == false)
            return;

        Transform chosen = targeting.SelectTarget(targeting.TargetsInRange);
        if (chosen != null)
            DoAttack(chosen);
    }

    /// <summary>
    /// 공격할 수 있는지 검사하는 함수
    /// </summary>
    /// <returns></returns>
    public bool CanAttack()
    {
        return Time.time >= lastAttackTime + coolTime
            && targeting.TargetsInRange.Any();
    }

    /// <summary>
    /// 공격을 실행하는 함수(TODO : 현재는 )
    /// </summary>
    /// <param name="target"></param>
    public void DoAttack(Transform target)
    {
        animator.SetTrigger(AnimatorHash.Fairy.AttackTrigger);
        attack.DoAttack(target);
        lastAttackTime = Time.time;
        OnAttack?.Invoke();
    }

    /// <summary>
    /// 공격했다는 알림을 받는 이벤트 함수
    /// </summary>
    /// <param name="dmg"> 데미지를 받은 피격체 </param>
    /// <param name="origin"> 데미지를 입은 위치 </param>
    private void OnHitRecieved(IDamageable dmg, Vector3 origin)
    {
        Debug.Log(this.transform.parent.name + ": " + this.GetType() + " : OnHit");
        OnHit?.Invoke(dmg, origin);
    }
}
