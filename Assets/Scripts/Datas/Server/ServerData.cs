using Firebase.Auth;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using UnityEngine;

/// <summary>
/// 서버에 요청하여 받은 데이터를 처리하는 클래스
/// </summary>
public class ServerData : Singleton<ServerData>
{
    /// <summary>
    /// 서버데이터로 부터 받은 데이터에 공통적인 것을 처리하는 함수
    /// </summary>
    /// <param name="res"></param>
    protected virtual void ApplyCommonResponse(JObject res)
    {
        DataService.Instance.ApplyCommonResponse(res);
    }

}
