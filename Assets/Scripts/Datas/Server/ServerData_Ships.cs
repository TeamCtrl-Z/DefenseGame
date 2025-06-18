using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

/// <summary>
/// 배에 관한 서버 데이터 요청
/// </summary>
public static class ServerData_Ships
{
    /// <summary>
    /// 배에 페어리들 배치 요청
    /// </summary>
    /// <param name="slotFairys"> 배치된 페어리 목록 (k - 슬롯 인덱스, v - foid) </param>
    /// <param name="success"> 성공 콜백 </param>
    /// <param name="fail"> 실패 콜백 </param>
    /// <returns></returns>
    public static IEnumerator RequestAssignFairys(Dictionary<uint, string> slotFairys, Action success, Action fail = null)
    {
        string url = "/ship/assign";
        Network network = new Network(url, "POST");
        network.SetRequestData(new
        {
            slotFairys = slotFairys
        });
        yield return network.SendRequest();

        if (!string.IsNullOrEmpty(network.Error))
        {
            Debug.LogWarning(network.Error);
            fail?.Invoke();
            yield break;
        }

        string responseJson = network.ResponseText;
        JObject res = JObject.Parse(responseJson);
        DataService.Instance.ApplyCommonResponse(res);
        success?.Invoke();
    }
}