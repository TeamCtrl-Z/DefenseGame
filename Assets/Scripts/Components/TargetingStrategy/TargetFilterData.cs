using System.Collections.Generic;
using UnityEngine;

public abstract class TargetFilterData : ScriptableObject, ITargetFilter
{
    public abstract IEnumerable<ITargetable> Filter(IEnumerable<ITargetable> enemies);
}