using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Enemy를 제어하는 중앙 체계 클래스
/// </summary>
[RequireComponent(typeof(DamageProcessor))]
[RequireComponent(typeof(EnemyStatusEffectComponent))]
public class EnemyController : EntityController, IDamageableWithDebuff, ITargetable
{
    /// <summary>
    /// StateMachine
    /// </summary>
    private EnemyStateMachine enemyStateMachine;

    /// <summary>
    /// Status Component의 프로퍼티
    /// </summary>
    public EnemyStatusComponent StatusComponent { get; private set; }

    /// <summary>
    /// 이 Enemy의 Transform을 반환하는 프로퍼티
    /// </summary>
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
        StatusComponent.OnDie += Die;
    }

    protected override void OnDisable()
    {
        StatusComponent.OnDie -= Die;
        base.OnDisable();
    }

    private void Start()
    {
        enemyStateMachine = new EnemyStateMachine(this);
    }

    private void Update()
    {
        // State별로 Update함수 실행하기
        enemyStateMachine.Update();
    }

    /// <summary>
    /// 데미지를 입는 함수
    /// </summary>
    /// <param name="attacker">공격한 오브젝트</param>
    /// <param name="data">히팅 데이터</param>
    public void OnDamage(GameObject attacker, HittingData data)
    {
        if (gameObject.activeSelf == false) return;
        statusEffect.AddStack(data.Debuff);
        damageProcessor.DamageFuncs[data.Debuff](StatusComponent, data.Damage);
        Factory.Instance.GetEnemyHit(transform.position);
    }

    /// <summary>
    /// Enemy가 죽었을 때 호출되는 함수
    /// </summary>
    public void Die()
    {
        GameManager.Instance.ChapterManager.KillCount++;
        Factory.Instance.GetEnemyDieEffect(transform.position);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 디버프 스택 조회용 함수(EnemyController)
    /// </summary>
    /// <returns></returns>
    public IStatusEffectProvider GetStatusEffectProvider()
    {
        return statusEffect as IStatusEffectProvider;
    }
}
