/// <summary>
/// Fairy의 기본(고유) Status 데이터 클래스
/// </summary>
public class FairyBaseStatusData
{
    /// <summary>
    /// Fairy의 ID
    /// </summary>
    public uint FID;

    /// <summary>
    /// 치명타 데미지
    /// </summary>
    public float CriticalDamage;

    /// <summary>
    /// 치명타 확률
    /// </summary>
    public float CiriticalRate;

    /// <summary>
    /// Fairy의 공격력
    /// </summary>
    public float AttackPower;

    /// <summary>
    /// Fairy의 공격 속도
    /// </summary>
    public float AttackSpeed;

    /// <summary>
    /// Fairy의 대상 지정 타입
    /// </summary>
    public TargetingType Target;

    /// <summary>
    /// Fairy의 공격 타입
    /// </summary>
    public AttackType AttackType;

    /// <summary>
    /// Fairy의 AttackID
    /// </summary>
    public uint AttackId;
}
