using UnityEngine;

/// <summary>
/// 공격에 필요한 데이터를 저장하기 위한 SO
/// </summary>
public abstract class AttackData : ScriptableObject
{
    /// <summary>
    /// 피격 데이터
    /// </summary>
    public HittingData data;

    /// <summary>
    /// 공격 클래스 만들어주는 함수
    /// </summary>
    /// <param name="owner"> 공격 하는 페어리 </param>
    /// <returns></returns>
    public abstract AttackBase CreateAttack(FairyController owner);
}