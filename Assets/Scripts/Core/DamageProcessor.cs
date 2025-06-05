using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy의 피격을 처리하기 위한 클래스
/// </summary>
public class DamageProcessor : MonoBehaviour
{
    /// <summary>
    /// Damage 처리 함수 테이블 K : 디버프 타입, V : 값
    /// </summary>
    public readonly Dictionary<DebuffType, Action<EnemyStatusComponent, float>> DamageFuncs = new();

    /// <summary>
    /// dotDamage를 위한 코루틴
    /// </summary>
    private Coroutine dotDamageRoutine;

    /// <summary>
    /// 이동을 멈추기 위한 코루틴
    /// </summary>
    private Coroutine stopRoutine;

    /// <summary>
    /// 도트 데미지 주기
    /// </summary>
    private const float DotInterval = 1f;

    private void Awake()
    {
        DamageFuncs[DebuffType.None] = (status, amount) => ApplyDamage(status, amount);
        DamageFuncs[DebuffType.Poison] = (status, amount) => ApplyDotDamage(status, amount);
        DamageFuncs[DebuffType.Freeze] = (status, amount) => ApplySlowDebuff(status, amount);
        DamageFuncs[DebuffType.Frozen] = (status, amount) => ApplySlowDebuff(status, amount);
    }

    /// <summary>
    /// 일반 데미지 적용
    /// </summary>
    /// <param name="hp"> 적의 hp 인터페이스 </param>
    /// <param name="dmg"> 데미지 </param>
    public void ApplyDamage(IHealthStatus hp, float dmg)
    {
        hp.ChangeHP(-dmg);
    }

    /// <summary>
    /// 도트 데미지 적용
    /// </summary>
    /// <param name="hp"> 적의 hp 인터페이스 </param>
    /// <param name="dmg"> 데미지 </param>
    public void ApplyDotDamage(IHealthStatus hp, float dmg)
    {
        IEnumerator DotDamageRoutine(float dmg, float term)
        {
            while (true)
            {
                yield return new WaitForSeconds(term);
                hp.ChangeHP(-dmg);
            }
        }
        if (dotDamageRoutine != null)
            StopCoroutine(dotDamageRoutine);

        dotDamageRoutine = StartCoroutine(DotDamageRoutine(dmg, DotInterval));
    }
    
    /// <summary>
    /// 슬로우 적용
    /// </summary>
    /// <param name="move"> 적의 움직임 인터페이스 </param>
    /// <param name="slowRatio"> 슬로우 비율 </param>
    public void ApplySlowDebuff(IMoveStatus move, float slowRatio)
    {
        float realSlowRatio = Mathf.Min((1 - slowRatio), 1);
        if (move.MoveSpeedMultiplier > realSlowRatio)
            move.MoveSpeedMultiplier = realSlowRatio;
    }

    /// <summary>
    /// 이동 멈춤 적용
    /// </summary>
    /// <param name="move"> 적의 움직임 인터페이스 </param>
    /// <param name="duration"> 멈춤 시간 </param>
    public void ApplyStopDebuff(IMoveStatus move, float duration)
    {
        IEnumerator StopRoutine(float duration)
        {
            float origin = move.MoveSpeedMultiplier;
            move.MoveSpeedMultiplier = 0.0f;
            yield return new WaitForSeconds(duration);
            move.MoveSpeedMultiplier = origin;
        }

        if (stopRoutine != null)
            StopCoroutine(stopRoutine);

        stopRoutine = StartCoroutine(StopRoutine(duration));
    }
}