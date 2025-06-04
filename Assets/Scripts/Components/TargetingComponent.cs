using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 타겟팅 타입
/// </summary>
public enum TargetingType
{
    /// <summary>
    /// 가장 가까운 적
    /// </summary>
    Nearest,
    /// <summary>
    /// 랜덤
    /// </summary>
    Random,
    /// <summary>
    /// 가장 체력이 많은 적
    /// </summary>
    Healthiest,
}

/// <summary>
/// 어떤 적을 먼저 공격할지 정하는 Component
/// </summary>
public class TargetingComponent : MonoBehaviour
{
    // TODO: Status에 따로 추가할지 추후에 결정
    /// <summary>
    /// 공격 범위
    /// </summary>
    [field: Header("Battle Status")]
    [field: SerializeField] public float AttackRange { get; private set; }

    /// <summary>
    /// 사용할 타겟팅 전략
    /// </summary>
    [SerializeField] private TargetingStrategyData targetingStrategy;

    /// <summary>
    /// 선택 조건
    /// </summary>
    [SerializeField] private TargetFilterData fillterType;

    /// <summary>
    /// 범위 안에 있는 타겟들
    /// </summary>
    private readonly HashSet<ITargetable> targetsInRange = new();

    /// <summary>
    /// 범위 안에 있는 타겟틀을 가져오는 프로퍼티
    /// </summary>

    public IEnumerable<ITargetable> TargetsInRange => targetsInRange;

    /// <summary>
    /// 타겟이 감지되면 호출되는 이벤트
    /// </summary>
    public event Action<ITargetable> OnTargetEnterRange;

    /// <summary>
    /// 타겟이 범위 안에 나가면 호출되는 이벤트
    /// </summary>
    public event Action<ITargetable> OnTargetExitRange;

    private void Awake()
    {
        CircleCollider2D col = GetComponent<CircleCollider2D>();
        col.isTrigger = true;
        col.radius = AttackRange;
    }


    /// <summary>
    /// 적 타겟을 가져오는 메서드
    /// </summary>
    /// <returns></returns>
    public Transform SelectTarget(IEnumerable<ITargetable> candidates)
    {
        if (fillterType != null)
        {
            var fillteringCandidates = fillterType.Filter(candidates);

            return targetingStrategy.SelectTarget(transform, fillteringCandidates);
        }
        return targetingStrategy.SelectTarget(transform, candidates);
    }

    /// <summary>
    /// 적 타겟들을 가져오는 메서드
    /// </summary>
    /// <param name="candidates"> 후보 </param>
    /// <param name="count"> 몇 마리 </param>
    /// <returns> 적 Transform List </returns>
    public List<Transform> SelectTargets(IEnumerable<ITargetable> candidates, int count)
    {
        if (fillterType != null)
        {
            var fillteringCandidates = fillterType.Filter(candidates);

            return targetingStrategy.SelectTargets(transform, fillteringCandidates, count);
        }
        return targetingStrategy.SelectTargets(transform, candidates, count);
    }

    /// <summary>
    /// 적이 감지 됐을 때 호출되는 함수
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<ITargetable>(out ITargetable target))
        {
            if (targetsInRange.Add(target))
            {
                if (target is EnemyController enemy)
                    enemy.onDisable += () => RemoveTarget(target);
                OnTargetEnterRange?.Invoke(target);
            }
        }
    }

    /// <summary>
    /// 적이 감지 범위 밖으로 나갔을 때 호출되는 함수
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<ITargetable>(out ITargetable target))
        {
            RemoveTarget(target);
        }
    }

    /// <summary>
    /// 캐싱한 타겟들에서 지우기 위한 함수
    /// </summary>
    /// <param name="target"></param>
    private void RemoveTarget(ITargetable target)
    {
        if (targetsInRange.Remove(target))
            OnTargetExitRange?.Invoke(target);
    }
}
