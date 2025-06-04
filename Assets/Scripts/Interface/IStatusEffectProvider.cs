/// <summary>
/// 디버프 상태 제공을 위한 인터페이스
/// </summary>
public interface IStatusEffectProvider
{
    public int GetStackCount(DebuffType type);
}