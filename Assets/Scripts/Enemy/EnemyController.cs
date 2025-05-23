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

    private void Awake()
    {
        enemyStateMachine = new EnemyStateMachine(this);
        MoveStatus = GetComponent<IMoveStatus>();
        HealthStatus = GetComponent<IHealthStatus>();
    }

    private void Update()
    {
        // State별로 Update함수 실행하기
        enemyStateMachine.Update();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1.0f);  // radius = 1
    }

    public void OnDamage(GameObject attacker, HittingData data)
    {
        HealthStatus.ChangeHP(-data.Damage);
    }
}
