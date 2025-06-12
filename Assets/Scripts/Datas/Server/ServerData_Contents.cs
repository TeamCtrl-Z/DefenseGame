using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

/// <summary>
/// 방치형 게임에 관한 서버 데이터
/// </summary>
public class ServerData_Contents : Singleton<ServerData_Contents>
{
    /// <summary>
    /// 스테이지를 클리어할 때 요청하는 함수
    /// </summary>
    /// <param name="success"> 성공할 때 호출 </param>
    /// <param name="fail">실패할 때 호출</param>
    /// <returns></returns>
    public IEnumerator RequestStageClear(Action success, Action fail)
    {
        Debug.Log("RequestStageClear 시작");
        string url = "/contents/stage/clear";
        Network network = new Network(url, "POST");
        network.SetRequestData(new
        {
            stageId = DataService.Instance.ContentsDataManager.CurrentStage.StageID
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
    /// 스테이지를 클리어할 때 요청하는 함수
    /// </summary>
    /// <param name="success"> 성공할 때 호출 </param>
    /// <param name="fail">실패할 때 호출</param>
    /// <returns></returns>
    public IEnumerator RequestChapterClear(Action success, Action fail)
    {
        string url = "/contents/chapter/clear";
        Network network = new Network(url, "POST");
        network.SetRequestData(new
        {
            chapterId = DataService.Instance.ContentsDataManager.CurrentChapter.ChapterID
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