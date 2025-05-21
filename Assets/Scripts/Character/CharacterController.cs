using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : RecycleObject
{
    /// <summary>
    /// StateMachine
    /// </summary>
    public StateMachine<CharacterController> characterStateMachine;

    // State들
    public IState<CharacterController> idle;
    public IState<CharacterController> attack;
    public IState<CharacterController> skill;

    private void Awake()
    {
        // State 만들기
        idle = new CharacterIdle();
        attack = new CharacterAttack();
        skill = new CharacterSkill();
    }

    private void Start()
    {
        characterStateMachine = new StateMachine<CharacterController>(this, idle);
    }

    private void Update()
    {
        // State별로 Update함수 실행하기
        characterStateMachine.Update();
    }


}
