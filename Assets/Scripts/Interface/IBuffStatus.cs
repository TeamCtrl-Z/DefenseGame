/// <summary>
/// 버프를 위한 Status 인터페이스
/// </summary>
public interface IBuffStatus
{
    /// <summary>
    /// 공격 속도 배수
    /// </summary>
    public float AttackSpeedFactor { get; }

    /// <summary>
    /// 공격력 배수
    /// </summary>
    public float AttackPowerFactor { get; }

    /// <summary>
    /// 버프해주는 함수
    /// </summary>
    /// <param name="type"> 버프 종류 </param>
    /// <param name="amount">버프할 양</param>
    public void BuffStatus(BuffType type, float amount);
    
    /// <summary>
    /// 버프를 중단해주는 함수
    /// </summary>
    /// <param name="type">버프 종류</param>
    public void BuffStop(BuffType type);
}