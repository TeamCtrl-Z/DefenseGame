using UnityEngine;

public class FireExplosion : RecycleObject
{
    protected override void OnDisable()
    {
        transform.localScale = Vector2.one;
        base.OnDisable();
    }   
}