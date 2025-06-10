using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 전기 속성
/// </summary>
public class ElectronicAttribute : AttributeBase, IOnHitEffect
{
    /// <summary>
    /// 타겟팅을 위한 컴포넌트 
    /// </summary>
    private TargetingComponent targeting;

    /// <summary>
    /// 타겟팅 전략
    /// </summary>
    public NearestTargeting targetingStrategy;

    /// <summary>
    /// 전기속성 데이터
    /// </summary>
    public HittingData[] data;

    /// <summary>
    /// 적 마다 데미지 비율(가까운 순으로)
    /// </summary>
    public readonly float[] DamageRatio = new float[2] { 0.7f, 0.3f };

    /// <summary>
    /// 초기화 함수
    /// </summary>
    /// <param name="user"> 사용하는 페어리 </param>
    public override void Initialize(GameObject user)
    {
        base.Initialize(user);

        targeting = user.GetComponent<TargetingComponent>();
        targetingStrategy = new NearestTargeting();
        data = new HittingData[3]
        {
            new HittingData{Damage = value1},
            new HittingData{Damage = value1 * DamageRatio[0]},
            new HittingData{Damage = value1 * DamageRatio[1]},
        };
    }

    /// <summary>
    /// 몬스터가 피격됐을 때 2명의 적을 더 산출하여 번개 데미지 적용
    /// </summary>
    /// <param name="damagable"> 피격 받은 몬스터 </param>
    /// <param name="origin"> 피격 받은 위치 </param>
    public void OnHit(IDamageableWithDebuff damagable, Vector3 origin)
    {
        var allInRange = targeting.TargetsInRange;

        var secondaryCandidates = allInRange
            .Where(t =>
            {
                var dmg = t.Transform.GetComponent<IDamageable>();
                return dmg != damagable;
            });

        var picked = targetingStrategy.SelectTargets(user.transform, allInRange, data.Length + 1);

        for (int i = 1; i < picked.Count; i++)
        {
            if (picked[i].TryGetComponent<IDamageable>(out var dmg))
            {
                if (dmg == damagable) continue;
                Factory.Instance.GetLightning(picked[i].position);
                dmg.OnDamage(user.gameObject, data[i - 1]);
            }
        }
    }
}
