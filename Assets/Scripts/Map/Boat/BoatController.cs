using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Boat의 Controller
/// </summary>
public class BoatController : MonoBehaviour, IDamageable
{
    /// <summary>
    /// 보트 Status 컴포넌트
    /// </summary>
    private BoatStatusComponent boatStatus;

    /// <summary>
    /// 살아 있는지
    /// </summary>
    public bool IsAlive => boatStatus.CurrentHP > 0.0f;

    private void Awake()
    {
        boatStatus = GetComponent<BoatStatusComponent>();
    }

    private void OnEnable()
    {
        boatStatus.OnDie += Die;
    }

    private void OnDisable()
    {
        boatStatus.OnDie -= Die;
    }

    /// <summary>
    /// 디버프 체크용 함수(보트는 사용을 안하므로 빈함수)
    /// </summary>
    public IStatusEffectProvider GetStatusEffectProvider()
    {
        return null;
    }

    /// <summary>
    /// 데미지를 입는 함수
    /// </summary>
    /// <param name="attacker">공격하는 주체</param>
    /// <param name="data">공격 데이터</param>
    public void OnDamage(GameObject attacker, HittingData data)
    {
        boatStatus.ChangeHP(data.Damage);
        Factory.Instance.GetEnemyHit(transform.position);
    }

    /// <summary>
    /// Boat가 부숴졌을 때 호출되는 함수
    /// </summary>
    public void Die()
    {
    }
}
