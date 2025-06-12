using System;
using System.Collections;
using System.Text;
using Firebase.Auth;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// 서버와 통신을 도와주는 API제공 클래스
/// </summary>
public class Network
{
    /// <summary>
    /// 서버 api의 기본 Url
    /// </summary>
    private const string BaseUrl = "https://121.130.77.123:5001/api";

    /// <summary>
    /// 서버에 요청할 때 사용될 객체
    /// </summary>
    private UnityWebRequest webRequest;

    /// <summary>
    /// 요청 전 초기화를 하였는지
    /// </summary>
    private bool isRequestInitialized = false;

    /// <summary>
    /// 서버에 요청 후 응답 메세지
    /// </summary>
    public string ResponseText { get; private set; } = "";

    /// <summary>
    /// 서버에 요청 후 에러 메세지
    /// </summary>
    public string Error { get; private set; } = "";

    /// <summary>
    /// 로그인 후 서버가 내려주는 쿠키를 여기 저장
    /// </summary>
    private static string _sessionCookie = null;

    /// <summary>
    /// Network 생성자
    /// </summary>
    /// <param name="relativeUrl">서버 주소</param>
    /// <param name="httpMethod">접속 방법</param>
    public Network(string relativeUrl, string httpMethod)
    {
        if (string.IsNullOrEmpty(relativeUrl))
            throw new ArgumentException(nameof(relativeUrl) + "는 null 또는 빈 문자열일 수 없습니다.");

        string fullUrl = BaseUrl.TrimEnd('/') + "/" + relativeUrl.TrimStart('/');
        Debug.Log(fullUrl);
        webRequest = new UnityWebRequest(fullUrl, httpMethod.ToUpper());
        webRequest.disposeCertificateHandlerOnDispose = true;
    }

    /// <summary>
    /// 서버에 요청할 때 실어보낼 데이터가 없으면 실행하는 함수
    /// </summary>
    public void SetRequestData()
    {
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        isRequestInitialized = true;
    }

    /// <summary>
    /// 서버에 요청할 때 실어보낼 데이터를 설정.
    /// 반드시 SendRequest()를 호출하기 전에 한 번 호출해야 함.
    /// </summary>
    /// <typeparam name="T">임의의 데이터 타입(내부적으로 JSON으로 직렬화 함)</typeparam>
    /// <param name="data">서버에 전송할 객체</param>
    public void SetRequestData<T>(T data)
    {
        string json = JsonConvert.SerializeObject(data);
        byte[] postData = Encoding.UTF8.GetBytes(json);
        webRequest.uploadHandler = new UploadHandlerRaw(postData);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");
        isRequestInitialized = true;
    }

    /// <summary>
    /// 헤더 설정
    /// </summary>
    /// <param name="key"> 어떤 헤더 </param>
    /// <param name="value"> 헤더에 설정할 값 </param>
    public void SetRequestHeader(string key, string value)
    {
        webRequest.SetRequestHeader(key, value);
    }

    /// <summary>
    /// 서버에 요청을 보내는 코루틴 함수
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public IEnumerator SendRequest()
    {
        if (!isRequestInitialized)
        {
            throw new InvalidOperationException("SetRequestData<T>()를 먼저 호출해서 UploadHandler와 DownloadHandler를 설정해야 합니다.");
        }

        if (!string.IsNullOrEmpty(_sessionCookie))
        {
            webRequest.SetRequestHeader("Cookie", _sessionCookie);
        }
        else
        {
            // 1) Firebase 초기화 의존성 체크
            var depTask = Firebase.FirebaseApp.CheckAndFixDependenciesAsync();
            yield return new WaitUntil(() => depTask.IsCompleted);

            if (depTask.Result != Firebase.DependencyStatus.Available)
            {
                Debug.LogError($"Firebase 초기화 실패: {depTask.Result}");
                yield break;  // 초기화가 안 됐으면 요청 자체를 중단
            }
            FirebaseUser firebaseUser = FirebaseAuth.DefaultInstance.CurrentUser;
            if (firebaseUser == null)
            {
                Error = "로그인된 사용자가 없습니다.";
                yield break;
            }

            var tokenTask = firebaseUser.TokenAsync(forceRefresh: true);
            yield return new WaitUntil(() => tokenTask.IsCompleted);


            if (tokenTask.Exception != null)
            {
                AggregateException aggEx = tokenTask.Exception;
                string msg = aggEx.InnerException != null ? aggEx.InnerException.Message : aggEx.Message;
                Error = $"ID 토큰 요청 실패: {msg}";
                yield break;
            }

            string idToken = tokenTask.Result;

            webRequest.SetRequestHeader("Authorization", $"Bearer {idToken}");
        }

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
            webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            // 오류가 발생한 경우
            long statusCode = webRequest.responseCode; // 0 이면 네트워크 연결 조차 안 된 상태
            string errorMsg = webRequest.error;         // 프로토콜 에러 메시지 또는 네트워크 에러 메시지
            string bodyText = webRequest.downloadHandler != null
                                ? webRequest.downloadHandler.text
                                : "<No Body>";

            Debug.LogError($"[Network] 요청 실패 → StatusCode: {statusCode}, Error: {errorMsg}");
            Debug.LogError($"[Network] Response Body: {bodyText}");

            Error = errorMsg;
            ResponseText = "";
        }
        else
        {
            // 성공적으로 응답을 받았을 때
            Error = "";
            ResponseText = webRequest.downloadHandler.text;

            // 로그인할땐 세션 쿠키 저장
            if (webRequest.url.EndsWith("/user/login", StringComparison.OrdinalIgnoreCase))
            {
                Debug.Log($"[Network] 세션 쿠키 저장 시도");
                var setCookie = webRequest.GetResponseHeader("Set-Cookie");
                if (!string.IsNullOrEmpty(setCookie))
                {
                    var parts = setCookie.Split(';', 2);
                    _sessionCookie = parts[0];
                    Debug.Log($"[Network] 세션 쿠키 저장: {_sessionCookie}");
                }
                else
                {
                    Debug.Log($"[Network] 세션 쿠키 저장 실패");
                }
            }
            Debug.Log("요청 성공");
        }

        // 5) 사용 후 UnityWebRequest가 더 이상 필요 없으면 자원 해제
        webRequest.Dispose();
    }
}