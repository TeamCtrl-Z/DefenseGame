using System.Collections.Generic;
using AnimatorHash;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

/// <summary>
/// 페어리의 데이터들을 관리하는 클래스(CSV파일 로드 데이터)
/// </summary>
public class FairyDataManager : MonoBehaviour, IServerData
{
    /// <summary>
    /// 페어리 status 데이터 테이블 - k : fid, v : FairyStatusData
    /// </summary>
    private Dictionary<int, FairyBaseStatusData> statusTable;

    /// <summary>
    /// 페어리 attribute 데이터 테이블 - k : fid, v : FairyStatusData
    /// </summary>
    private Dictionary<int, FairyAttributeData> attributeTable;

    /// <summary>
    /// 페어리 상세 정보(서버에서 가져온 값)
    /// </summary>
    private Dictionary<int, FairyDetailStatusData> detailStatusTable;

    /// <summary>
    /// 초기화
    /// </summary>
    public void Initialize()
    {
        statusTable = CsvLoader.LoadTable<FairyBaseStatusData>("table_fairyStatus");
        attributeTable = CsvLoader.LoadTable<FairyAttributeData>("table_fairyAttribute");
        detailStatusTable = new();
    }

    #region StatusData
    /// <summary>
    /// StatusData를 얻는 함수
    /// </summary>
    /// <param name="fid"> 페어리 아이디 </param>
    /// <param name="statData"> 해당 statusData </param>
    /// <returns>성공 실패</returns>
    public bool TryGetStatData(int fid, out FairyBaseStatusData statData)
    {
        statData = null;
        if (!statusTable.ContainsKey(fid))
            return false;

        statData = statusTable[fid];
        return true;
    }

    /// <summary>
    /// 플레이어가 가진 페어리의 상세 정보를 얻어오는 함수
    /// </summary>
    /// <param name="fid"> 패어리 아이디 </param>
    /// <param name="statData"> 해당 detailStatusData </param>
    /// <returns>성공 실패</returns>
    public bool TryGetDetailStatData(int fid, out FairyDetailStatusData statData)
    {
        statData = null;
        if (!statusTable.ContainsKey(fid))
            return false;

        statData = detailStatusTable[fid];
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
        targetingType = TargetingType.Nearest;
        if (!statusTable.ContainsKey(fid))
            return false;

        FairyBaseStatusData statData = statusTable[fid];
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
        attributeData = null;
        if (!attributeTable.ContainsKey(fid))
            return false;

        attributeData = attributeTable[fid];
        return true;
    }

    #endregion
    /// <summary>
    /// 서버 데이터 적용
    /// </summary>
    /// <param name="res"></param>
    public void ApplyServerData(JObject res)
    {
        if (res["fairy_list"] == null)
            return;

        // 플레이어가 가진 페어리 리스트 
        var fariyArray = res["fairy_list"] as JArray;

        foreach (var item in fariyArray)
        {
            int fid = item["fid"].Value<int>();

            if (detailStatusTable.ContainsKey(fid))
            {
                JsonConvert.PopulateObject(item.ToString(), detailStatusTable[fid]);
            }
            else
            {
                var data = item.ToObject<FairyDetailStatusData>();
                if (data != null)
                    detailStatusTable[data.FID] = data;
            }
        }
    }
}