using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

/// <summary>
/// 배 데이터 관리자
/// </summary>
public class ShipDataManager : MonoBehaviour, IServerData
{
    /// <summary>
    /// 유저의 배 정보
    /// </summary>
    public ShipData ShipData { get; private set; }

    /// <summary>
    /// 서버에 내려온 값 적용
    /// </summary>
    /// <param name="res"> 서버 응답 json 데이터 </param>
    public void ApplyServerData(JObject res)
    {
        if (res["ship"] == null)
            return;

        if (ShipData == null)
        {
            ShipData = res["ship"].ToObject<ShipData>();
        }
        else
        {
            JsonConvert.PopulateObject(res["ship"].ToString(), ShipData);
        }
    }
}