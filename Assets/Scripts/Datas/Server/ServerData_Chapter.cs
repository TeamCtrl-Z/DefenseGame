using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 방치형 게임에 관한 서버 데이터
/// </summary>
public class ServerData_Chapter : ServerData
{
    /// <summary>
    /// ServerData_Lobby 싱글톤 인스턴스
    /// </summary>
    public static new ServerData_Chapter Instance
    {
        get
        {
            return ServerData.Instance as ServerData_Chapter;
        }
    }

    /// <summary>
    /// 스테이지를 클리어할 때 요청하는 함수
    /// </summary>
    /// <param name="success"> 성공할 때 호출 </param>
    /// <param name="fail">실패할 때 호출</param>
    /// <returns></returns>
    public IEnumerator RequestStageClear(Action success, Action fail)
    {
        string url = "lobby/clear";
        Network network = new Network(url, "POST");
        network.SetRequestData(new
        {
            gold = UserDataManager.Instance.Currency_Gold,
            gem = UserDataManager.Instance.Currency_Gem,
            stage_id = GameManager.Instance.ChapterManager.CurrentStage.StageID
        });
        yield return network.SendRequest();

        if (!string.IsNullOrEmpty(network.Error))
        {
            Debug.LogWarning(network.Error);
            fail?.Invoke();
            yield break;
        }

        string responseJson = network.ResponseText;
        UserDataManager.Instance.LoadUserData(responseJson);
        ApplyCommonResponse(responseJson);
        success?.Invoke();
    }
    
        /// <summary>
    /// 스테이지를 클리어할 때 요청하는 함수
    /// </summary>
    /// <param name="success"> 성공할 때 호출 </param>
    /// <param name="fail">실패할 때 호출</param>
    /// <returns></returns>
    public IEnumerator RequestChapterClear(Action success, Action fail)
    {
        string url = "lobby/clear";
        Network network = new Network(url, "POST");
        network.SetRequestData(new { gold = UserDataManager.Instance.Currency_Gold,
            gem = UserDataManager.Instance.Currency_Gem,
            chapter_id = GameManager.Instance.ChapterManager.CurrentChapter.ChapterID});
        yield return network.SendRequest();

        if (!string.IsNullOrEmpty(network.Error))
        {
            Debug.LogWarning(network.Error);
            fail?.Invoke();
            yield break;
        }

        string responseJson = network.ResponseText;
        UserDataManager.Instance.LoadUserData(responseJson);
        ApplyCommonResponse(responseJson);
        success?.Invoke();
    }
}