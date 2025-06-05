using Firebase.Auth;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerData_Users : ServerData
{
    public static new ServerData_Users Instance
    {
        get
        {
            return ServerData.Instance as ServerData_Users;
        }
    }

    public IEnumerator RequestRegister(Action success, Action fail)
    {
        string deviceId = SystemInfo.deviceUniqueIdentifier;

        var registerRequestData = new
        {
            provider = "guest",
            deviceId = deviceId
        };

        string registerUrl = "/user/register";
        Network network = new Network(registerUrl, "POST");
        network.SetRequestData(registerRequestData);

        yield return network.SendRequest();

        if (!string.IsNullOrEmpty(network.Error))
        {
            Debug.LogError($"[LoginManager] 게스트 등록 실패: {network.Error}");
            Debug.LogError($"서버 응답(문제가 있는 경우): {network.ResponseText}");
            fail?.Invoke();
            yield break;
        }

        // 회원가입 성공 → 서버 응답 JSON 파싱
        string responseJson = network.ResponseText;
        UserDataManager.Instance.LoadUserData(responseJson);
        ApplyCommonResponse(responseJson);
        success?.Invoke();
    }

    public IEnumerator RequestLogin(Action success, Action fail)
    {
        string loginUrl = "/user/login";
        Network network = new Network(loginUrl, "POST");
        network.SetRequestData();
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

    public IEnumerator RequestDelete(Action success, Action fail)
    {
        string deleteUrl = "/user/delete";

        var deleteRequestData = new { };
        Network network = new Network(deleteUrl, "POST");
        network.SetRequestData(deleteRequestData);
        yield return network.SendRequest();
        if (!string.IsNullOrEmpty(network.ResponseText))
        {
            Debug.LogError($"[LoginManager] 삭제 실패 : {network.Error}");
            Debug.LogError($"서버 응답 바디: {network.ResponseText}");
            fail?.Invoke();
            yield break;
        }

        success?.Invoke();
    }
}