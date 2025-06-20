using System;
using System.Collections;
using Newtonsoft.Json.Linq;
using UnityEngine;

/// <summary>
/// 아이템 관련 서버 데이터
/// </summary>
public static class ServerData_Items
{
    /// <summary>
    /// 아이템 장착 요청(ioid가 null이면 장착 해제 요청)
    /// </summary>
    /// <param name="foid">장착시킬 페어리</param>
    /// <param name="type">장착할 아이템 종류</param>
    /// <param name="ioid">장착할 아이템 오브젝트 아이디</param>
    /// <param name="success">성공 콜백 함수</param>
    /// <param name="fail">실패 콜백 함수</param>
    /// <returns></returns>
    public static IEnumerator RequestEquipItem(string foid, ItemType type, string ioid, Action success, Action fail)
    {
        Debug.Log("RequestStageClear 시작");
        string url = "/items/equip";
        Network network = new Network(url, "POST");
        network.SetRequestData(new
        {
            foid = foid,
            itemType = type,
            ioid = ioid
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
    /// 재화를 수정하는 치트키(DB상 User쪽에 있는 게 맞지만 맥락 상 여기에 두기로 결정)
    /// </summary>
    /// <param name="type"> 재화 타입 </param>
    /// <param name="amount"> 수정하고 싶은 양 </param>
    /// <param name="success"> 성공 콜백 </param>
    /// <param name="fail"> 실패 콜백 </param>
    /// <returns></returns>
    public static IEnumerator RequestCheatModifyCurrency(CurrencyType type, ulong amount, Action success, Action fail = null)
    {
        string url = "/item/cheat/modify";
        Network network = new Network(url, "POST");
        network.SetRequestData(new
        {
            uid = DataService.Instance.UserDataManager.User.uid,
            currencyType = type.ToString(),
            amount = amount
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