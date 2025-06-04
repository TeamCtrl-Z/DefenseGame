using UnityEngine;

/// <summary>
/// 피격 당할 수 있는 인터페이스
/// </summary>
public interface IDamagable
{
    /// <summary>
    /// 피격 당했을 때 실행하는 함수
    /// </summary>
    /// <param name="attacker"> 공격한 오브젝트 </param>
    /// <param name="data"> 현재 피격 정보 </param>
    void OnDamage(GameObject attacker, HittingData data);

    /// <summary>
    /// 디버프 스택 조회용
    /// </summary>
    /// <returns></returns>
    IStatusEffectProvider GetStatusEffectProvider();
}