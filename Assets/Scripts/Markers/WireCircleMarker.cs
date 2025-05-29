using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireCircleMarker : RecycleObject
{

    protected override void OnEnable()
    {
        base.OnEnable();

        DisableTimer(3.0f);
    }

    protected override void OnDisable()
    {
        transform.localScale = Vector2.one;
        base.OnDisable();
    }
}
