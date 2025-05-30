using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : RecycleObject, IDamagable
{
    /// <summary>
    /// StateMachine
    /// </summary>
    private EnemyStateMachine enemyStateMachine;
    public IMoveStatus MoveStatus { get; private set; }
    public IHealthStatus HealthStatus { get; private set; }
    public MarkCondition MarkCondition { get; private set; }

    private void Awake()
    {
        MoveStatus = GetComponent<IMoveStatus>();
        HealthStatus = GetComponent<IHealthStatus>();
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

    private void OnDrawGizmosSelected()
    {
        // Gizmos.color = Color.red;
        // Gizmos.DrawWireSphere(transform.position, 1.0f);  // radius = 1
    }

    public void OnDamage(GameObject attacker, HittingData data)
    {
        HealthStatus.ChangeHP(-data.Damage);
    }

    public void OnDotDamage(GameObject attacker, HittingData data, float term)
    {
        StartCoroutine(DotDamageRoutine(data, term));
        MarkCondition = data.condition;
    }

    private IEnumerator DotDamageRoutine(HittingData data, float term)
    {
        while (true)
        {
            HealthStatus.ChangeHP(-data.Damage);
            yield return new WaitForSeconds(term);
        }
    }
}
