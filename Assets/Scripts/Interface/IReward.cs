/// <summary>
/// 처치하면 얻는 보상 정보들이 들어있는 인터페이스
/// </summary>
public interface IReward
{
    /// <summary>
    /// Gold 양
    /// </summary>
    public uint Gold { get; }

    /// <summary>
    /// Gem 양
    /// </summary>
    public uint Gem { get; }

    /// <summary>
    /// EXP 양
    /// </summary>
    public uint Exp { get; }

    /// <summary>
    /// 보상 데이터를 로드하는 메소드
    /// </summary>
    public void LoadRewardData();

    /// <summary>
    /// 보상 픽업을 생성하는 메소드
    /// </summary>
    public void SpawnRewardPickups();
}
