using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    /// <summary>
    /// StateMachine
    /// </summary>
    public StateMachine<EnemyController> EnemyStateMachine;

    // State들
    public IState<EnemyController> idle;
    public IState<EnemyController> attack;

    private void Awake()
    {
        // State 만들기
        idle = new EnemyIdle();
        attack = new EnemyAttack();
    }

    private void Update()
    {
        // State별로 Update함수 실행하기
        EnemyStateMachine.Update();
    }
}
