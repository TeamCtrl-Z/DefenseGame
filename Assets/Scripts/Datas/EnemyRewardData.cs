/// <summary>
/// Enemy를 처치했을 때 얻는 보상 데이터 클래스
/// </summary>
public class EnemyRewardData
{
    /// <summary>
    /// Enemy ID
    /// </summary>
    public int eid;
    
    /// <summary>
    /// Enemy 처치 시 얻는 Gold
    /// </summary>
    public uint gold;

    /// <summary>
    /// Enemy 처치 시 얻는 Gem
    /// </summary>
    public uint gem;

    /// <summary>
    /// Enemy 처치 시 얻는 EXP
    /// </summary>
    public uint exp;
}
