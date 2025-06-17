using System;
using System.Collections;
using Newtonsoft.Json.Linq;
using UnityEngine;

/// <summary>
/// 페어리 관련 서버 데이터 요청
/// </summary>
public static class ServerData_Fairys
{
    /// <summary>
    /// 페어리 레벨업 요청
    /// </summary>
    /// <param name="foid"> 레벨업 할 페어리 </param>
    /// <param name="upCount"> 레벨 업 갯수 </param>
    /// <param name="success">성공 콜백</param>
    /// <param name="fail"> 실패 콜백</param>
    public static IEnumerator RequestFairyLevelUp(string foid, uint upCount, Action success, Action fail)
    {
        Debug.Log("RequestFairyLevelUp 시작");
        string url = "/fairy/levelup";
        Network network = new Network(url, "POST");
        network.SetRequestData(new
        {
            foid = foid,
            upCount = upCount,
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

    /// <summary>
    /// 페어리 치트용 얻기 요청
    /// </summary>
    /// <param name="fid"> 얻을 페어리 종류 </param>
    /// <param name="count"> 얻을 갯수 </param>
    /// <param name="success"> 성공 콜백 </param>
    /// <param name="fail"> 실패 콜백 </param>
    public static IEnumerator RequestCheatGetFairy(uint fid, uint count, Action success = null, Action fail = null)
    {
        Debug.Log("RequestCheatGetFairy 시작");
        string url = "/fairy/cheat/get";
        Network network = new Network(url, "POST");
        network.SetRequestData(new
        {
            fid = fid,
            count = count
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