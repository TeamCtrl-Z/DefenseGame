using System;
using UnityEngine;

/// <summary>
/// 눈보라 속성
/// </summary>
public class FrozenAttribute : AttributeBase, IOnIntervalEffect
{
    /// <summary>
    /// 눈보라 속성 피격 데이터
    /// </summary>
    public HittingData data;

    /// <summary>
    /// 눈보라 발현 간격
    /// </summary>
    public float Interval { get; set; }

    public override void Initialize(GameObject user)
    {
        base.Initialize(user);

        data = new HittingData { Damage = value1, Debuff = DebuffType.Frozen };
        Interval = value2;
    }

    /// <summary>
    /// 일정 시간마다 눈보라를 발현시켜 전체 적에게 슬로우를 걸어주는 함수
    /// </summary>
    public void OnInterval()
    {
        Vector3 origin = user.transform.position;
        float radius = Mathf.Abs(origin.x) + 9.0f;
        var cols = Physics2D.OverlapCircleAll(origin, radius, LayerMask.GetMask("Enemy"));
        Effect snow = Factory.Instance.GetSnow(new Vector2(0.0f, 4.0f));
        snow.transform.SetParent(UIManager.Instance.FullScreenEffects.transform);

        foreach (var col in cols)
        {
            if (col.TryGetComponent<IDamageable>(out IDamageable dmg))
            {
                dmg.OnDamage(user, data);
            }
        }
    }
}