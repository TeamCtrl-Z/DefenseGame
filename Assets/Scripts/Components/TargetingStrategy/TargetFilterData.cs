using System.Collections.Generic;
using UnityEngine;

public abstract class TargetFilterData : ScriptableObject, ITargetFilter
{
    public abstract IEnumerable<EnemyController> Filter(IEnumerable<EnemyController> enemies);
}