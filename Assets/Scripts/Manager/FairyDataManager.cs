using System.Collections.Generic;
using AnimatorHash;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

/// <summary>
/// 페어리의 데이터들을 관리하는 클래스
/// </summary>
public class FairyDataManager : MonoBehaviour, IServerData
{
    /// <summary>
    /// 내가 보유한 페어리 인스턴스 테이블- k : foid, v : FairyInstanceData
    /// </summary>
    private Dictionary<string, FairyInstanceData> instanceFoidTable;

    /// <summary>
    /// 내가 보유한 페어리 인스턴스 테이블 (fid 버전)
    /// </summary>
    private Dictionary<uint, FairyInstanceData> instanceFidTable;

    /// <summary>
    /// 초기화
    /// </summary>
    public void Initialize()
    {
        instanceFoidTable = new();
        instanceFidTable = new();
    }

    /// <summary>
    /// 플레이어가 가진 페어리의 상세 정보를 얻어오는 함수
    /// </summary>
    /// <param name="fid"> 패어리 아이디 </param>
    /// <param name="statData"> 해당 detailStatusData </param>
    /// <returns>성공 실패</returns>
    public bool TryGetInstanceData(string foid, out FairyInstanceData statData)
    {
        statData = null;
        if (!instanceFoidTable.ContainsKey(foid))
            return false;

        statData = instanceFoidTable[foid];
        return true;
    }

    /// <summary>
    /// 페어리 소환 함수
    /// </summary>
    /// <param name="fid"> 소환하고 싶은 페어리 아이디 </param>
    /// <param name="position"> 소환 위치 </param>
    /// <param name="angle"> 소환 각도 </param>
    /// <returns> 소환 페어리 </returns>
    public FairyController SpawnFairyByFid(uint fid, Vector3 position, float angle = 0.0f)
    {
        return instanceFidTable[fid].GetFairyInstance(position, angle);
    }

    /// <summary>
    /// 서버 데이터 적용
    /// </summary>
    /// <param name="res"></param>
    public void ApplyServerData(JObject res)
    {
        if (res["fairys"] == null)
            return;

        // 플레이어가 가진 페어리 리스트 
        var fariyArray = res["fairys"] as JArray;

        foreach (var fairy in fariyArray)
        {
            string foid = fairy["foid"].Value<string>();

            if (instanceFoidTable.ContainsKey(foid)) // 이미 있는 경우
            {
                JsonConvert.PopulateObject(fairy.ToString(), instanceFoidTable[foid]);
            }
            else // 처음 생성
            {
                var data = fairy.ToObject<FairyInstanceData>();
                if (data != null)
                {
                    instanceFoidTable[data.FOID] = data;

                    instanceFidTable[data.FID] = data;
                }
            }
        }
    }
}