/// <summary>
/// 디버프 상태 제공을 위한 인터페이스
/// </summary>
public interface IStatusEffectProvider
{
    /// <summary>
    /// 디버프 상태의 번호를 반환하는 함수
    /// </summary>
    /// <param name="type">디버프 종류</param>
    /// <returns>디버프 번호</returns>
    public int GetStackCount(DebuffType type);
}