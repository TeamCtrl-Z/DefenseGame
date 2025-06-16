using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 모든 개체 컨트롤러
/// </summary>
public abstract class EntityController : RecycleObject
{
    public abstract float GetAttackPower();
}
