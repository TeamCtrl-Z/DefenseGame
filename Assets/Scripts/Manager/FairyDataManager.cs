using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 페어리의 데이터들을 관리하는 클래스(CSV파일 로드 데이터)
/// </summary>
public class FairyDataManager : Singleton<FairyDataManager>
{
    /// <summary>
    /// 페어리 status 데이터 테이블 - k : fid, v : FairyStatusData
    /// </summary>
    private Dictionary<int, FairyStatusData> statusTable;

    /// <summary>
    /// 페어리 attribute 데이터 테이블 - k : fid, v : FairyStatusData
    /// </summary>
    private Dictionary<int, FairyAttributeData> attributeTable;

    #region StatusData
    /// <summary>
    /// StatusData를 얻는 함수
    /// </summary>
    /// <param name="fid"> 페어리 아이디 </param>
    /// <param name="statData"> 해당 statusData </param>
    /// <returns>성공 실패</returns>
    public bool TryGetStatData(int fid, out FairyStatusData statData)
    {
        if (statusTable == null)
            statusTable = CsvLoader.LoadTable<FairyStatusData>("table_fairyStatus");

        statData = null;
        if (!statusTable.ContainsKey(fid))
            return false;

        statData = statusTable[fid];
        return true;
    }

    /// <summary>
    /// 해당 페어리의 타겟팅 타입을 얻는 함수
    /// </summary>
    /// <param name="fid"> 페어리 아이디 </param>
    /// <param name="targetingType"> 해당 타겟팅 타입 </param>
    /// <returns> 성공 실패 </returns>
    public bool TryGetTargetingType(int fid, out TargetingType targetingType)
    {
        if (statusTable == null)
            statusTable = CsvLoader.LoadTable<FairyStatusData>("table_fairyStatus");

        targetingType = TargetingType.Nearest;
        if (!statusTable.ContainsKey(fid))
            return false;

        FairyStatusData statData = statusTable[fid];
        if (statData == null)
            return false;

        targetingType = statData.Target;
        return true;
    }
    #endregion

    #region AttributeData

    /// <summary>
    /// AttributeData(Csv파일 데이터 저장본)을 얻는 함수
    /// </summary>
    /// <param name="fid"> 페어리 아이디 </param>
    /// <param name="attributeData"> 속성 데이터 </param>
    /// <returns>성공 실패</returns>
    public bool TryGetAttributeData(int fid, out FairyAttributeData attributeData)
    {
        if (attributeTable == null)
            attributeTable = CsvLoader.LoadTable<FairyAttributeData>("table_fairyAttribute");

        attributeData = null;
        if (!attributeTable.ContainsKey(fid))
            return false;

        attributeData = attributeTable[fid];
        return true;
    }
    #endregion
}