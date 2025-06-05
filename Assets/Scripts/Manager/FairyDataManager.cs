using System.Collections.Generic;

/// <summary>
/// FairyData를 관리하는 매니저 클래스
/// </summary>
public class FairyDataManager : Singleton<FairyDataManager>
{
    /// <summary>
    /// 페어리의 Status 데이터를 담고 있는 딕셔너리
    /// </summary>
    private Dictionary<int, FairyStatusData> statusTable;

    /// <summary>
    /// FairyDataManager의 초기화 메소드(FairyDataManager가 처음 생성될 때 1번 호출됨)
    /// </summary>
    protected override void OnPreInitialize()
    {
        base.OnPreInitialize();

        statusTable = CsvLoader.LoadTable<FairyStatusData>("FairyStatus");
    }

    /// <summary>
    /// Fairy의 ID에 해당하는 Status 데이터를 가져오는 메소드
    /// </summary>
    /// <param name="fid">Fairy ID</param>
    /// <param name="statData">Fairy Stat Data</param>
    /// <returns>true면 성공 false면 실패</returns>
    public bool TryGetValue(int fid, out FairyStatusData statData)
    {
        statData = null;
        if (!statusTable.ContainsKey(fid))
            return false;

        statData = statusTable[fid];
        return true;
    }

    /// <summary>
    /// Fairy의 ID에 해당하는 TargetingType을 가져오는 메소드
    /// </summary>
    /// <param name="fid">Fairy ID</param>
    /// <param name="targetingType">타겟팅 타입</param>
    /// <returns>true면 성공, false면 실패</returns>
    public bool TryGetTargetingType(int fid, out TargetingType targetingType)
    {
        targetingType = TargetingType.Nearest;
        if (!statusTable.ContainsKey(fid))
            return false;

        FairyStatusData statData = statusTable[fid];
        if (statData == null)
            return false;

        targetingType = (TargetingType)statData.Target;
        return true;
    }
}