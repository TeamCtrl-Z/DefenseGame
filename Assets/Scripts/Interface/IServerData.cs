using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

/// <summary>
/// 서버 데이터를 적용 시키기 위한 인터페이스
/// </summary>
public interface IServerData
{
    /// <summary>
    /// 서버로 부터 내려온 값을 적용시키기는 함수
    /// </summary>
    /// <param name="res"> json형식의 응답(response) </param>
    public void ApplyServerData(JObject res);
}