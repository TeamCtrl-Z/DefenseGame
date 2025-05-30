using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITargetFilter
{
    IEnumerable<EnemyController> Filter(IEnumerable<EnemyController> enemies);
}