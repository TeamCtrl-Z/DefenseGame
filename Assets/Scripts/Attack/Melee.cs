using System;
using UnityEngine;

/// <summary>
/// 근접 공격 클래스
/// </summary>
public class Melee : RecycleObject
{
    /// <summary>
    /// 공격했을 때 호출하는 이벤트
    /// </summary>
    public event Action<IDamageable, Vector3> OnHit;

    /// <summary>
    /// 근접 공격이 타겟에 닿았을 때 호출되는 함수
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.TryGetComponent<IDamageable>(out IDamageable dmg))
        {
            OnHit?.Invoke(dmg, transform.position);
            gameObject.SetActive(false);
        }
    }
}
