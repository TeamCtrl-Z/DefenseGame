using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITargetFilter
{
    IEnumerable<ITargetable> Filter(IEnumerable<ITargetable> enemies);
}