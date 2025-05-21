using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    /// <summary>
    /// StateMachine
    /// </summary>
    public StateMachine<EnemyController> EnemyStateMachine;

    // State��
    public IState<EnemyController> idle;
    public IState<EnemyController> attack;

    private void Awake()
    {
        // State �����
        idle = new EnemyIdle();
        attack = new EnemyAttack();
    }

    private void Update()
    {
        // State���� Update�Լ� �����ϱ�
        EnemyStateMachine.Update();
    }
}
