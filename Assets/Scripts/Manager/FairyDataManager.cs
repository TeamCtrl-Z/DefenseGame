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
    /// 내가 보유한 페어리 인스턴스 테이블 (fid 버전)
    /// </summary>
    private Dictionary<uint, FairyInstanceData> instanceFidTable;

    /// <summary>
    /// 초기화
    /// </summary>
    public void Initialize()
    {
        instanceFidTable = new();
    }

    /// <summary>
    /// 플레이어가 가진 페어리의 상세 정보를 얻어오는 함수
    /// </summary>
    /// <param name="fid"> 패어리 아이디 </param>
    /// <param name="statData"> 해당 instanceData </param>
    /// <returns>성공 실패</returns>
    public bool TryGetInstanceData(uint fid, out FairyInstanceData statData)
    {
        statData = null;
        if (!instanceFidTable.ContainsKey(fid))
            return false;

        statData = instanceFidTable[fid];
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
    /// 페어리 UI 소환 함수
    /// </summary>
    /// <param name="fid"> 소환하고 싶은 페어리 아이디 </param>
    /// <param name="position"> 소환 위치 </param>
    /// <param name="angle"> 소환 각도 </param>
    /// <returns> 소환 페어리 UI</returns>
    public FairyUI SpawnFairyUIByFid(uint fid, Vector3 position, float angle = 0.0f)
    {
        return instanceFidTable[fid].GetFairyUI(position, angle);
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
        var fairyArray = res["fairys"] as JArray;

        // 단일 페어리 데이터
        if (fairyArray == null)
        {
            var fairy = res["fairys"];
            uint fid = fairy["fid"].Value<uint>();

            if (instanceFidTable.ContainsKey(fid)) // 이미 있는 경우
            {
                JsonConvert.PopulateObject(fairy.ToString(), instanceFidTable[fid]);
            }
            else // 처음 생성
            {
                var data = fairy.ToObject<FairyInstanceData>();
                if (data != null)
                {
                    instanceFidTable[data.FID] = data;
                }
            }
            return;
        }
        else
        {
            foreach (var fairy in fairyArray)
            {
                uint fid = fairy["fid"].Value<uint>();

                if (instanceFidTable.ContainsKey(fid)) // 이미 있는 경우
                {
                    JsonConvert.PopulateObject(fairy.ToString(), instanceFidTable[fid]);
                }
                else // 처음 생성
                {
                    var data = fairy.ToObject<FairyInstanceData>();
                    if (data != null)
                    {
                        instanceFidTable[data.FID] = data;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 페어리의 모든 데이터를 리스트화 시켜서 반환하는 함수(FairyInfoUI용)
    /// </summary>
    /// <returns>페어리데이터 리스트</returns>
    public List<FairyInstanceData> GetAllFairyInstanceData()
    {
        return new List<FairyInstanceData>(instanceFidTable.Values);
    }
}