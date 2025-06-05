using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Collections;
using Firebase.Auth;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

/// <summary>
/// 로그인 및 계정 관리 매니저
/// </summary>
public class LoginManager : MonoBehaviour
{
    [Header("— UI Panels —")]
    public GameObject loginPanel;
    public GameObject mainPanel;

    [Header("— LoginPanel Components —")]
    public Button guestLoginButton;
    public TextMeshProUGUI statusText;

    [Header("— MainPanel Components —")]
    public TextMeshProUGUI welcomeText;
    public Button deleteAccountButton;

    private FirebaseAuth auth;

    private const string baseUrl = "https://121.130.77.123:5001/api";
    private string registerUrl = baseUrl + "/user/register";
    private string loginUrl = baseUrl + "/user/login";
    private string deleteUrl = baseUrl + "/user/delete";  // 계정 삭제용 엔드포인트

    private string accountFilePath;

    private void Awake()
    {
        auth = FirebaseAuth.DefaultInstance;
        accountFilePath = Path.Combine(Application.persistentDataPath, "guest_account.json");

        guestLoginButton.onClick.AddListener(OnGuestLoginButtonClicked);
        deleteAccountButton.onClick.AddListener(OnDeleteAccountButtonClicked);

        loginPanel.SetActive(false);
        mainPanel.SetActive(false);
        statusText.text = "";
        welcomeText.text = "";
    }

    private void Start()
    {
        // 1) 로컬에 guest_account.json이 있으면 복원 시도
        if (File.Exists(accountFilePath))
        {
            bool loaded = LoadAccountFromJson();
            if (loaded)
            {
                // 2) Firebase 세션이 살아 있는지 확인
                if (auth.CurrentUser != null)
                {
                    // 세션이 살아 있다면, 항상 최신 ID 토큰으로 /user/login 호출해서 프로필 갱신
                    StartCoroutine(LoginWithFirebaseSession());
                    return;
                }
                else
                {
                    // Firebase 세션이 만료된 경우
                    File.Delete(accountFilePath);
                }
            }
            else
            {
                File.Delete(accountFilePath);
            }
        }
        ShowLoginUI();
    }

    private void ShowLoginUI()
    {
        loginPanel.SetActive(true);
        mainPanel.SetActive(false);
        statusText.text = "게스트로 로그인하려면 버튼을 누르세요.";
    }

    private void ShowMainUI(string message)
    {
        loginPanel.SetActive(false);
        mainPanel.SetActive(true);
        welcomeText.text = message;
    }

    #region ■ 게스트 로그인 → Firebase 익명 인증 → 서버 회원가입

    private void OnGuestLoginButtonClicked()
    {
        statusText.text = "Firebase 익명 로그인 중…";
        StartCoroutine(SignInAnonymouslyAndRegister());
    }

    private IEnumerator SignInAnonymouslyAndRegister()
    {
        // 1) Firebase 익명 로그인
        var authTask = auth.SignInAnonymouslyAsync();
        yield return new WaitUntil(() => authTask.IsCompleted);

        if (authTask.Exception != null || authTask.Result == null)
        {
            statusText.text = "익명 로그인 실패. Firebase 콘솔에서 확인하세요.";
            yield break;
        }

        FirebaseUser firebaseUser = authTask.Result.User;

        // 2) 항상 “최신” ID 토큰을 요청
        var tokenTask = firebaseUser.TokenAsync(forceRefresh: true);
        yield return new WaitUntil(() => tokenTask.IsCompleted);

        if (tokenTask.Exception != null)
        {
            statusText.text = "토큰 요청 실패. 다시 시도하세요.";
            yield break;
        }

        string idToken = tokenTask.Result;

        // 3) 서버에 회원가입 요청
        yield return StartCoroutine(RegisterWithServer(idToken, firebaseUser.UserId));
    }

    private IEnumerator RegisterWithServer(string idToken, string firebaseUid)
    {
        statusText.text = "서버 회원가입 중…";

        string deviceId = SystemInfo.deviceUniqueIdentifier;
        var registerRequestData = new
        {
            provider = "guest",
            deviceId = deviceId
        };
        string registerJson = JsonConvert.SerializeObject(registerRequestData);
        byte[] postData = Encoding.UTF8.GetBytes(registerJson);

        using (UnityWebRequest request = new UnityWebRequest(registerUrl, "POST"))
        {
            request.certificateHandler = new AcceptAllCerts();
            request.disposeCertificateHandlerOnDispose = true;

            request.uploadHandler = new UploadHandlerRaw(postData);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", $"Bearer {idToken}");

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                statusText.text = "회원가입 실패. 요청 형식을 확인하세요.";
                yield break;
            }

            // 회원가입 성공 → 서버 응답 JSON 파싱
            string responseJson = request.downloadHandler.text;
            try
            {
                UserDataManager.Instance.LoadUserData(responseJson);
            }
            catch
            {
                statusText.text = "서버 응답 파싱 오류.";
                yield break;
            }

            // 로컬 JSON(guest_account.json) 에는 “변하지 않는 정보”만 저장
            SaveAccountToJson();

            yield return StartCoroutine(LoginAfterRegister(idToken));
        }
    }

    private IEnumerator LoginAfterRegister(string idToken)
    {
        statusText.text = "가입 완료, 로그인 중…";

        var loginRequestData = new { idToken = idToken };
        string loginJson = JsonConvert.SerializeObject(loginRequestData);
        byte[] postData = Encoding.UTF8.GetBytes(loginJson);

        using (UnityWebRequest request = new UnityWebRequest(loginUrl, "POST"))
        {
            request.certificateHandler = new AcceptAllCerts();
            request.disposeCertificateHandlerOnDispose = true;

            request.uploadHandler = new UploadHandlerRaw(postData);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", $"Bearer {idToken}");

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                statusText.text = "가입 후 로그인 실패.";
                yield break;
            }

            string responseJson = request.downloadHandler.text;
            try
            {
                UserDataManager.Instance.LoadUserData(responseJson);
                SceneManager.LoadScene("MainScene");
            }
            catch
            {
                statusText.text = "서버 응답 파싱 오류.";
                yield break;
            }

            SaveAccountToJson();

            string shortUid = UserDataManager.Instance.User.firebaseUID.Length >= 8
                ? UserDataManager.Instance.User.firebaseUID.Substring(0, 8)
                : UserDataManager.Instance.User.firebaseUID;
            ShowMainUI($"환영합니다, 게스트님!\n(UID: {shortUid})");
        }
    }
    #endregion


    #region ■ 자동 로그인 (/user/login)

    private IEnumerator LoginWithFirebaseSession()
    {
        statusText.text = "자동 로그인 중…";

        // 1) Firebase.CurrentUser로부터 항상 “최신” ID 토큰을 받아온다
        var tokenTask = auth.CurrentUser.TokenAsync(forceRefresh: true);
        yield return new WaitUntil(() => tokenTask.IsCompleted);

        if (tokenTask.Exception != null)
        {
            ShowLoginUI();
            yield break;
        }

        string freshIdToken = tokenTask.Result;

        // 2) 서버 /user/login 호출
        var loginRequestData = new { idToken = freshIdToken };
        string loginJson = JsonConvert.SerializeObject(loginRequestData);
        byte[] postData = Encoding.UTF8.GetBytes(loginJson);

        using (UnityWebRequest request = new UnityWebRequest(loginUrl, "POST"))
        {
            request.certificateHandler = new AcceptAllCerts();
            request.disposeCertificateHandlerOnDispose = true;

            request.uploadHandler = new UploadHandlerRaw(postData);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", $"Bearer {freshIdToken}");

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                ShowLoginUI();
                yield break;
            }

            string responseJson = request.downloadHandler.text;
            try
            {
                UserDataManager.Instance.LoadUserData(responseJson);
                SceneManager.LoadScene("MainScene");
            }
            catch
            {
                ShowLoginUI();
                yield break;
            }

            // 로컬 JSON에 “변하지 않는” 정보만 덮어써서 저장
            SaveAccountToJson();

            string shortUid = UserDataManager.Instance.User.firebaseUID.Length >= 8
                ? UserDataManager.Instance.User.firebaseUID.Substring(0, 8)
                : UserDataManager.Instance.User.firebaseUID;
            ShowMainUI($"자동 로그인 성공!\nUID: {shortUid}");
        }
    }

    #endregion


    #region ■ 계정 삭제

    private void OnDeleteAccountButtonClicked()
    {
        if (UserDataManager.Instance.User == null)
        {
            statusText.text = "삭제할 계정이 없습니다.";
            return;
        }

        // 1) 서버에 삭제 요청을 먼저 보낸다.
        StartCoroutine(DeleteAccountFromServer());
    }

    private IEnumerator DeleteAccountFromServer()
    {
        statusText.text = "계정 삭제 중…";

        // FirebaseUser가 살아 있다면, 최신 ID 토큰을 다시 받아온다.
        var firebaseUser = auth.CurrentUser;
        if (firebaseUser == null)
        {
            // 로컬만 삭제하고 UI로 복귀
            PerformLocalDeletion();
            yield break;
        }

        var tokenTask = firebaseUser.TokenAsync(forceRefresh: true);
        yield return new WaitUntil(() => tokenTask.IsCompleted);

        if (tokenTask.Exception != null)
        {
            statusText.text = "알 수 없는 오류가 발생했습니다.";
            yield break;
        }

        string idToken = tokenTask.Result;

        // 서버 삭제 요청: { idToken: "..." } 형식의 간단한 body
        var deleteRequestData = new { idToken = idToken };
        string deleteJson = JsonConvert.SerializeObject(deleteRequestData);
        byte[] postData = Encoding.UTF8.GetBytes(deleteJson);

        using (UnityWebRequest request = new UnityWebRequest(deleteUrl, "POST"))
        {
            request.certificateHandler = new AcceptAllCerts();
            request.disposeCertificateHandlerOnDispose = true;

            request.uploadHandler = new UploadHandlerRaw(postData);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", $"Bearer {idToken}");

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                statusText.text = "계정 삭제 실패. 다시 시도하세요.";
                yield break;
            }

            // 삭제가 성공적으로 완료된 경우
            PerformLocalDeletion();
        }
    }

    /// <summary>
    /// 서버 삭제가 완료된 후 로컬 데이터까지 깨끗하게 지웁니다.
    /// </summary>
    private void PerformLocalDeletion()
    {
        if (File.Exists(accountFilePath))
        {
            File.Delete(accountFilePath);
        }

        // FirebaseAuth에서도 익명 유저를 완전히 삭제하려면 다음을 호출할 수 있습니다.
        // (선택 사항) 
        // auth.CurrentUser?.DeleteAsync();

        ShowLoginUI();
        statusText.text = "계정이 삭제되었습니다.";
    }
    #endregion


    #region ■ JSON 읽기/쓰기 헬퍼

    private bool LoadAccountFromJson()
    {
        try
        {
            string json = File.ReadAllText(accountFilePath, Encoding.UTF8);
            UserDataManager.Instance.LoadFromJson(json);
            return (UserDataManager.Instance.User != null && !string.IsNullOrEmpty(UserDataManager.Instance.User.firebaseUID));
        }
        catch
        {
            return false;
        }
    }

    private bool SaveAccountToJson()
    {
        if (UserDataManager.Instance.User == null)
            return false;

        try
        {
            string json = JsonConvert.SerializeObject(UserDataManager.Instance.User, Formatting.Indented);
            File.WriteAllText(accountFilePath, json, Encoding.UTF8);
            return true;
        }
        catch
        {
            return false;
        }
    }

    #endregion
}

/// <summary>
/// 유저 정보 클래스
/// </summary>
[Serializable]
public class UserData
{
    public string firebaseUID;
    public string provider;
    public string playerID;
    public string lastLoginAt;
    public ulong gold;
    public ulong gem;
    public uint diamond;
}

/// <summary>
/// 개발/테스트용: SSL 인증서를 무조건 통과시키는 CertificateHandler
/// </summary>
public class AcceptAllCerts : CertificateHandler
{
    protected override bool ValidateCertificate(byte[] certificateData) => true;
}
