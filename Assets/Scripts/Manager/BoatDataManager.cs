using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Boat의 DataManager 클래스
/// </summary>
public class BoatDataManager : Singleton<BoatDataManager>
{
    /// <summary>
    /// Boat 데이터를 담고 있는 딕셔너리
    /// </summary>
    private Dictionary<int, BoatStatusData> statusTable;

    /// <summary>
    /// BoatDataManager 초기화 메서드(싱글톤 생성 시 1번 호출)
    /// </summary>
    protected override void OnPreInitialize()
    {
        base.OnPreInitialize();

        statusTable = CsvLoader.LoadTable<BoatStatusData>("BoatStatus");
    }

    /// <summary>
    /// 스텟 데이터를 가져오는 메서드
    /// </summary>
    /// <param name="level">Boat Level</param>
    /// <param name="statData">Boat Stat Data</param>
    /// <returns>true면 성공, false면 실패</returns>
    public bool TryGetStatData(int level, out BoatStatusData statData)
    {
        statData = null;
        if (!statusTable.ContainsKey(level))
            return false;

        statData = statusTable[level];
        return true;
    }
}
