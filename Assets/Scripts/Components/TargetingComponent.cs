using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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
    /// 캐릭터 ID를 가져오는 인터페이스
    /// </summary>
    private ICharacterIdentity characterIdentity;

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

    private void Start()
    {
        characterIdentity = GetComponentInParent<ICharacterIdentity>();
        // FairyDataManager.Instance.TryGetTargetingType(characterIdentity.ID, out TargetingType type);
        // targetingStrategy = type switch
        // {
        //     TargetingType.Nearest => new NearestTargeting(transform),
        //     TargetingType.Random => new RandomTargeting(),
        //     TargetingType.Healthiest => new HealthiestTargeting(),
        //     _ => throw new System.NotImplementedException()
        // };
    }

    /// <summary>
    /// 타겟을 가져오는 메서드
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

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<ITargetable>(out ITargetable target))
        {
            RemoveTarget(target);
        }
    }

    private void RemoveTarget(ITargetable target)
    {
        if (targetsInRange.Remove(target))
            OnTargetExitRange?.Invoke(target);
    }
}
