using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

/// <summary>
/// 적 데이터를 관리하는 매니저 클래스
/// </summary>
public class EnemyDataManager : MonoBehaviour
{
    /// <summary>
    /// 적 데이터를 담고 있는 딕셔너리
    /// </summary>
    private Dictionary<int, EnemyStatusData> statusTable;

    /// <summary>
    /// 적 처치시 보상 데이터를 담고 있는 딕셔너리
    /// </summary>
    private Dictionary<int, EnemyRewardData> rewardTable;

    /// <summary>
    /// 스텟 데이터를 가져오는 메서드
    /// </summary>
    /// <param name="eid">Enemy ID</param>
    /// <param name="statData">Enemy Stat Data</param>
    /// <returns>true면 성공, false면 실패</returns>
    public bool TryGetStatData(int eid, out EnemyStatusData statData)
    {
        // 늦은 초기화
        if (statusTable == null)
            statusTable = CsvLoader.LoadTable<EnemyStatusData>("table_EnemyStatus");
        
        statData = null;
        if (!statusTable.ContainsKey(eid))
            return false;

        statData = statusTable[eid];
        return true;
    }

    /// <summary>
    /// 보상 데이터를 가져오는 메서드
    /// </summary>
    /// <param name="eid">Enemy ID</param>
    /// <param name="rewardData">EnemyRewardData</param>
    /// <returns>true면 성공, false면 실패</returns>
    public bool TryGetRewardData(int eid, out EnemyRewardData rewardData)
    {
        // 늦은 초기화
        if (rewardTable == null)
            rewardTable = CsvLoader.LoadTable<EnemyRewardData>("table_EnemyReward");
        
        rewardData = null;
        if (!rewardTable.ContainsKey(eid))
            return false;

        rewardData = rewardTable[eid];
        return true;
    }
}