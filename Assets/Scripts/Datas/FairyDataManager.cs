using System.Collections.Generic;

public class FairyDataManager : Singleton<FairyDataManager>
{
    private Dictionary<int, FairyStatusData> statusTable;

    protected override void OnPreInitialize()
    {
        base.OnPreInitialize();

        statusTable = CsvLoader.LoadTable<FairyStatusData>("FairyStatus");
    }

    public bool TryGetValue(int fid, out FairyStatusData statData)
    {
        statData = null;
        if (!statusTable.ContainsKey(fid))
            return false;

        statData = statusTable[fid];
        return true;
    }

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