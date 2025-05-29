using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 상태 이상 종류(이름 바꾸기)
/// </summary>
[Serializable]
public enum MarkCondition { None = 0, Poison, Freeze, }

[CreateAssetMenu(fileName = "NoMarkFilter", menuName = "Targeting/Filter/NoMarkFilter")]
public class NoMarkFilter : ScriptableObject, ITargetFilter
{
    public MarkCondition MarkType;
    public IEnumerable<EnemyController> Filter(IEnumerable<EnemyController> enemies) => enemies.Where(e => e.MarkCondition != MarkType);
}