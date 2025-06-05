using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 로그인 UI
/// </summary>
public class LoginUI : MonoBehaviour
{
    /// <summary>
    /// 게스트로 로그인 버튼
    /// </summary>
    [SerializeField]
    private Button guestLoginButton;

    /// <summary>
    /// 진행 상태 Text
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI statusText;

    /// <summary>
    /// Loading 퍼센트 Text
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI percentText;

    /// <summary>
    /// 회원가입 Group
    /// </summary>
    [SerializeField]
    private CanvasGroup registerGroup;

    /// <summary>
    /// 로딩 Group
    /// </summary>
    [SerializeField]
    private CanvasGroup loadingGroup;

    /// <summary>
    /// 로그인 매니저
    /// </summary>
    [SerializeField]
    private LoginManager loginManager;

    private void Start()
    {
        HideRegisterPanel();
        HideLoadingPanel();

        loginManager.OnStatusChange += RefreshStatus;
        loginManager.OnRegister += ShowRegisterPanel;
        loginManager.OnLoading += ShowLoadingPanel;


        guestLoginButton.onClick.AddListener(() =>
        {
            loginManager.OnGuestLoginButtonClicked();
        });
    }

    /// <summary>
    /// 회원가입 패널을 보여주는 메서드
    /// </summary>
    private void ShowRegisterPanel()
    {
        HideLoadingPanel();
        registerGroup.alpha = 1f;
        registerGroup.interactable = true;
        registerGroup.blocksRaycasts = true;
    }

    /// <summary>
    /// 회원가입 패널을 숨기는 메서드
    /// </summary>
    private void HideRegisterPanel()
    {
        registerGroup.alpha = 0f;
        registerGroup.interactable = false;
        registerGroup.blocksRaycasts = false;
    }

    /// <summary>
    /// 로딩 패널을 보여주는 메서드
    /// </summary>
    private void ShowLoadingPanel()
    {
        HideRegisterPanel();
        loadingGroup.alpha = 1f;
        loadingGroup.interactable = true;
        loadingGroup.blocksRaycasts = true;
    }

    /// <summary>
    /// 로딩패널을 숨기는 메서드
    /// </summary>
    private void HideLoadingPanel()
    {
        loadingGroup.alpha = 0f;
        loadingGroup.interactable = false;
        loadingGroup.blocksRaycasts = false;
    }

    /// <summary>
    /// 진행 상태(Text)를 갱신하는 메서드
    /// </summary>
    private void RefreshStatus(string status)
    {
        statusText.text = status;
    }
}
