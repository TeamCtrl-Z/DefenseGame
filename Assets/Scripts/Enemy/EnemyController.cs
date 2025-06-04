using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Enemy를 제어하는 중앙 체계 클래스
/// </summary>
[RequireComponent(typeof(DamageProcessor))]
[RequireComponent(typeof(EnemyStatusEffectComponent))]
public class EnemyController : RecycleObject, IDamagable, ITargetable
{
    /// <summary>
    /// StateMachine
    /// </summary>
    private EnemyStateMachine enemyStateMachine;
    public EnemyStatusComponent StatusComponent { get; private set; }

    public Transform Transform => transform;

    /// <summary>
    /// 적의 디버프 관리
    /// </summary>
    private EnemyStatusEffectComponent statusEffect;

    /// <summary>
    /// 데미지 총괄 처리
    /// </summary>
    private DamageProcessor damageProcessor;

    /// <summary>
    /// 살아 있는지
    /// </summary>
    public bool IsAlive => StatusComponent.CurrentHP > 0.0f;


    protected override void Awake()
    {
        base.Awake();
        StatusComponent = GetComponent<EnemyStatusComponent>();
        statusEffect = GetComponent<EnemyStatusEffectComponent>();
        damageProcessor = GetComponent<DamageProcessor>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        StatusComponent.OnHPChanged += HandleHpChanged;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        StatusComponent.OnHPChanged -= HandleHpChanged;
    }

    void Start()
    {
        enemyStateMachine = new EnemyStateMachine(this);
    }

    private void Update()
    {
        // State별로 Update함수 실행하기
        enemyStateMachine.Update();
    }

    public void OnDamage(GameObject attacker, HittingData data)
    {
        statusEffect.AddStack(data.Debuff);
        damageProcessor.DamageFuncs[data.Debuff](StatusComponent, data.Damage);
    }

    private void HandleHpChanged(float hp)
    {
        if (IsAlive == false)
            enemyStateMachine.TransitionTo(enemyStateMachine.Die);
    }

    public void Die()
    {
        GameManager.Instance.ChapterManager.KillCount++;
        Factory.Instance.GetEnemyDieEffect(transform.position);
        gameObject.SetActive(false);
    }

    public IStatusEffectProvider GetStatusEffectProvider()
    {
        return statusEffect as IStatusEffectProvider;
    }
}
