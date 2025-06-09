using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Boat의 DataManager 클래스
/// </summary>
public class BoatDataManager : MonoBehaviour
{
    /// <summary>
    /// Boat 데이터를 담고 있는 딕셔너리
    /// </summary>
    private Dictionary<int, BoatStatusData> statusTable;

    /// <summary>
    /// 스텟 데이터를 가져오는 메서드
    /// </summary>
    /// <param name="level">보트 레벨</param>
    /// <param name="statData">보트 Stat Data</param>
    /// <returns>true면 성공, false면 실패</returns>
    public bool TryGetStatData(int level, out BoatStatusData statData)
    {
        // 늦은 초기화
        if (statusTable == null)
            statusTable = CsvLoader.LoadTable<BoatStatusData>("BoatStatus");

        statData = null;
        if (!statusTable.ContainsKey(level))
            return false;

        statData = statusTable[level];
        return true;
    }
}
