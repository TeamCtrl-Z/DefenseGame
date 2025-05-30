using System.Collections.Generic;

public class EnemyDataManager : Singleton<EnemyDataManager>
{
    private Dictionary<int, EnemyStatusData> statusTable;

    protected override void OnPreInitialize()
    {
        base.OnPreInitialize();

        statusTable = CsvLoader.LoadTable<EnemyStatusData>("EnemyStatus");
    }

    public bool TryGetStatData(int eid, out EnemyStatusData statData)
    {
        statData = null;
        if (!statusTable.ContainsKey(eid))
            return false;

        statData = statusTable[eid];
        return true;
    }
}