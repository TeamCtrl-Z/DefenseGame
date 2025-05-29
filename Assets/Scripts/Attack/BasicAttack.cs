using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 기본 공격
/// </summary>
[CreateAssetMenu(fileName = "BasicAttack", menuName = "Attack/BasicAttack")]
public class BasicAttack : AttackBase
{
    public override void Initialize(FairyController attacker)
    {
        this.attacker = attacker;
    }
}
