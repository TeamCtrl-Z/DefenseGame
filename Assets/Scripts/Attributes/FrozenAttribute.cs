using System;
using UnityEngine;

[CreateAssetMenu(fileName = "FrozenAttribute", menuName = "Attribute/FrozenAttribute")]
public class FrozenAttribute : AttributeBase, IOnIntervalEffect
{
    [SerializeField] private HittingData attributeData;

    [field: SerializeField] public float Interval { get; set; }

    public void OnInterval()
    {
        Vector3 origin = user.transform.position;
        float radius = Mathf.Abs(origin.x) + 9.0f;
        var cols = Physics2D.OverlapCircleAll(origin, radius, LayerMask.GetMask("Enemy"));
        Snow snow = Factory.Instance.GetSnow(new Vector2(0.0f, 4.0f));
        foreach (var col in cols)
        {
            if (col.TryGetComponent<IDamagable>(out IDamagable dmg))
            {
                dmg.OnDamage(user, attributeData);
            }
        }
    }
}