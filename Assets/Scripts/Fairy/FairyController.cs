using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyController : RecycleObject, IPlaceable
{
    /// <summary>
    /// StateMachine
    /// </summary>
    public StateMachine<FairyController> characterStateMachine;

    // State들
    public IState<FairyController> idle;
    public IState<FairyController> attack;
    public IState<FairyController> skill;

    private void Awake()
    {
        // State 만들기
        idle = new FairyIdle();
        attack = new FairyAttack();
        skill = new FairySkill();
    }

    private void Start()
    {
        characterStateMachine = new StateMachine<FairyController>(this, idle);
    }

    private void Update()
    {
        // State별로 Update함수 실행하기
        characterStateMachine.Update();
    }

    /// <summary>
    /// 페어리를 Node에 배치하는 함수
    /// </summary>
    /// <param name="placePosition">배치할 위치</param>
    public void Place(Vector2 placePosition)
    {
        transform.position = placePosition;
    }
}
