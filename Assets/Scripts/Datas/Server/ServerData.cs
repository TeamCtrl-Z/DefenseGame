using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ServerData : Singleton<ServerData>
{
    private const string baseUrl = "https://121.130.77.123:5001/api";

    protected FirebaseAuth auth;
    protected string accountFilePath;
    protected override void OnPreInitialize()
    {
        base.OnPreInitialize();
        auth = FirebaseAuth.DefaultInstance;
        accountFilePath = accountFilePath = Path.Combine(Application.persistentDataPath, "user_data.json");
    }

    protected virtual void ApplyCommonResponse(string data)
    {
    }

    
    // ApplyCommonResponse : 공통적인 Data를 클라에 저장하는 작업

}
