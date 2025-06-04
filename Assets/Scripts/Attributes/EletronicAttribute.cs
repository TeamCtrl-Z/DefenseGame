using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "EletronicAttribute", menuName = "Attribute/EletronicAttribute")]
public class EletronicAttribute : AttributeBase, IOnHitEffect
{
    private TargetingComponent targeting;

    /// <summary>
    /// 타겟팅 전략
    /// </summary>
    public TargetingStrategyData targetingStrategy;

    /// <summary>
    /// 전기속성 데이터
    /// </summary>
    public HittingData[] datas;

    public override void Initialize(GameObject user)
    {
        base.Initialize(user);

        targeting = user.GetComponent<TargetingComponent>();
    }

    public void OnHit(IDamagable damagable, Vector3 origin)
    {
        var allInRange = targeting.TargetsInRange;

        var secondaryCandidates = allInRange
            .Where(t =>
            {
                var dmg = t.Transform.GetComponent<IDamagable>();
                return dmg != damagable;
            });

        var picked = targetingStrategy.SelectTargets(user.transform, allInRange, datas.Length + 1);

        for (int i = 1;  i < picked.Count; i++)
        {
            if (picked[i].TryGetComponent<IDamagable>(out var dmg))
            {
                if (dmg == damagable) continue;
                Lightning lightning = Factory.Instance.GetLightning(picked[i].position);
                dmg.OnDamage(user.gameObject, datas[i - 1]);
            }
        }
    }
}
