using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerData_Users : ServerData
{


    private IEnumerator SignInAnonymouslyAndRegister()
    {
        // 1) Firebase 익명 로그인
        var authTask = auth.SignInAnonymouslyAsync();
        yield return new WaitUntil(() => authTask.IsCompleted);

        if (authTask.Exception != null || authTask.Result == null)
        {
            yield break;
        }

        FirebaseUser firebaseUser = authTask.Result.User;

        // 2) 항상 “최신” ID 토큰을 요청
        var tokenTask = firebaseUser.TokenAsync(forceRefresh: true);
        yield return new WaitUntil(() => tokenTask.IsCompleted);

        if (tokenTask.Exception != null)
        {
            yield break;
        }

        string idToken = tokenTask.Result;

        // 3) 서버에 회원가입 요청
        //yield return StartCoroutine(RegisterWithServer(idToken, firebaseUser.UserId));
    }


}
