using UnityEngine;

public interface IDamagable
{
    /// <summary>
    /// 피격 당했을 때 실행하는 함수
    /// </summary>
    /// <param name="attacker"> 공격한 오브젝트 </param>
    /// <param name="data"> 현재 피격 정보 </param>
    void OnDamage(GameObject attacker, HittingData data);

    /// <summary>
    /// 도트 데미지를 당했을 때 실행되는 함수
    /// </summary>
    /// <param name="attacker"> 공격한 오브젝트 </param>
    /// <param name="data"> 피격 정보 </param>
    /// <param name="term"> 데미지 텀 </param>
    void OnDotDamage(GameObject attacker, HittingData data, float term);
}