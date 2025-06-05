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
    /// <summary>
    /// 진행 상태 변경 이벤트
    /// </summary>
    public event Action<string> OnStatusChange;

    /// <summary>
    /// 회원가입 시작 이벤트
    /// </summary>
    public event Action OnRegister;

    /// <summary>
    /// 로딩 시작 이벤트
    /// </summary>
    public event Action OnLoading;

    /// <summary>
    /// Firebase 경로
    /// </summary>
    private FirebaseAuth auth;

    /// <summary>
    /// 계정 정보 파일 경로
    /// </summary>
    private string accountFilePath;

    private void Awake()
    {
        auth = FirebaseAuth.DefaultInstance;
        accountFilePath = Path.Combine(Application.persistentDataPath, "guest_account.json");

        OnStatusChange?.Invoke("");
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
                    StartCoroutine(LoginProcess());
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
        OnRegister?.Invoke();
    }

    #region ■ 게스트 로그인 → Firebase 익명 인증 → 서버 회원가입

    /// <summary>
    /// Guest 버튼을 누르면 실행되는 함수
    /// </summary>
    public void OnGuestLoginButtonClicked()
    {
        OnStatusChange?.Invoke("Firebase 익명 로그인 중…");
        StartCoroutine(SignInAnonymouslyAndRegister());
    }

    /// <summary>
    /// 회원가입 하기 전에 Firebase 익명 로그인 및 ID 토큰 요청을 처리하는 함수
    /// </summary>
    private IEnumerator SignInAnonymouslyAndRegister()
    {
        // 1) Firebase 익명 로그인
        var authTask = auth.SignInAnonymouslyAsync();
        yield return new WaitUntil(() => authTask.IsCompleted);

        if (authTask.Exception != null || authTask.Result == null)
        {
            OnStatusChange?.Invoke("익명 로그인 실패. Firebase 콘솔에서 확인하세요.");
            yield break;
        }

        FirebaseUser firebaseUser = authTask.Result.User;

        // 2) 항상 “최신” ID 토큰을 요청
        var tokenTask = firebaseUser.TokenAsync(forceRefresh: true);
        yield return new WaitUntil(() => tokenTask.IsCompleted);

        if (tokenTask.Exception != null)
        {
            OnStatusChange?.Invoke("토큰 요청 실패. 다시 시도하세요.");
            yield break;
        }

        string idToken = tokenTask.Result;

        // 3) 서버에 회원가입 요청
        StartCoroutine(RegisterWithServer(idToken, firebaseUser.UserId));
    }

    /// <summary>
    /// 서버에 회원가입 요청을 보내는 코루틴 함수
    /// </summary>
    /// <param name="idToken">아이디 토큰</param>
    /// <param name="firebaseUid">UID</param>
    private IEnumerator RegisterWithServer(string idToken, string firebaseUid)
    {
        OnStatusChange?.Invoke("서버 회원가입 중…");

        void fail()
        {
            OnStatusChange?.Invoke("회원가입 실패. 요청 형식을 확인하세요.");
        }

        void success()
        {
            SaveAccountToJson();

            StartCoroutine(LoginProcess());
        }

        yield return ServerData_Users.Instance.RequestRegister(success, fail);
    }
    #endregion


    #region ■ 로그인 (/user/login)

    /// <summary>
    /// 로그인을 시도하는 코루틴 함수
    /// </summary>
    private IEnumerator LoginProcess()
    {
        OnStatusChange?.Invoke("로그인 중…");
        void successCB()
        {
            SaveAccountToJson();
            string shortUid = UserDataManager.Instance.User.firebaseUID.Length >= 8
                        ? UserDataManager.Instance.User.firebaseUID.Substring(0, 8)
                        : UserDataManager.Instance.User.firebaseUID;
            OnLoading?.Invoke();
        }

        void failCB()
        {
            OnRegister?.Invoke();
        }

        yield return ServerData_Users.Instance.RequestLogin(successCB, failCB);
    }

    #endregion


    #region ■ 계정 삭제

    /// <summary>
    /// 계정을 삭제하는 코루틴 함수
    /// </summary>
    /// <returns></returns>
    private IEnumerator DeleteAccountFromServer()
    {
        OnStatusChange?.Invoke("계정 삭제 중…");

        // FirebaseUser가 살아 있다면, 최신 ID 토큰을 다시 받아온다.
        var firebaseUser = auth.CurrentUser;
        if (firebaseUser == null)
        {
            // 로컬만 삭제하고 UI로 복귀
            PerformLocalDeletion();
            yield break;
        }
        void fail()
        {
            OnStatusChange?.Invoke("계정 삭제 실패.");
        }

        void success()
        {
            // 삭제가 성공적으로 완료된 경우
            Debug.Log("[LoginManager] 서버 계정 삭제 성공");
            PerformLocalDeletion();
        }

        ServerData_Users.Instance.RequestDelete(success, fail);
    }

    /// <summary>
    /// 로컬 데이터에 있는 계정을 삭제하는 함수
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

        OnLoading?.Invoke();
        OnStatusChange?.Invoke("계정이 삭제되었습니다.");
    }
    #endregion


    #region ■ JSON 읽기/쓰기 헬퍼

    /// <summary>
    /// json 파일에서 계정 정보를 읽어오는 함수
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// 불러온 계정 정보를 json 파일에 저장하는 함수
    /// </summary>
    /// <returns></returns>
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
