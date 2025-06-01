using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageProcessor : MonoBehaviour
{
    public readonly Dictionary<DebuffType, Action<EnemyStatusComponent, float>> DamageFuncs = new();

    private Coroutine dotDamageRoutine;

    private void Awake()
    {
        DamageFuncs[DebuffType.None] = (status, amount) => ApplyDamage(status, amount);
        DamageFuncs[DebuffType.Poison] = (status, amount) => ApplyDotDamage(status, amount);
        DamageFuncs[DebuffType.Freeze] = (status, amount) => ApplySlowDebuff(status, amount);
        DamageFuncs[DebuffType.Frozen] = (status, amount) => ApplySlowDebuff(status, amount);
    }

    public void ApplyDamage(IHealthStatus hp, float dmg)
    {
        hp.ChangeHP(-dmg);
    }

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

        dotDamageRoutine = StartCoroutine(DotDamageRoutine(dmg, 1f));
    }

    public void ApplySlowDebuff(IMoveStatus move, float slowRatio)
    {
        // TODO : 슬로우 디버프
        if (move.MoveSpeedMultiplier > slowRatio)
            move.MoveSpeedMultiplier = slowRatio;
    }
}