using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 로그인 UI
/// </summary>
public class LoginUI : MonoBehaviour
{
    /// <summary>
    /// 로딩 속도를 느리게 기작할 기준 퍼센트
    /// </summary>
    private float slowdownThreshold = 70.0f;

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

    [SerializeField]
    private Slider loadingSlider;

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
        StartCoroutine(UpdateLoadingProgress());
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

    /// <summary>
    /// 로딩 진행 상황을 업데이트하는 코루틴
    /// </summary>
    /// <returns></returns>
    private IEnumerator UpdateLoadingProgress()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainScene");
        asyncLoad.allowSceneActivation = false;

        float progressValue = 0f;
        while (progressValue < slowdownThreshold)
        {
            progressValue += Time.deltaTime * 7.5f;
            progressValue = Mathf.Min(progressValue, slowdownThreshold);
            loadingSlider.value = progressValue;
            percentText.text = $"{(int)progressValue}%";

            yield return null;
        }

        progressValue = slowdownThreshold;


        while (progressValue < 100f)
        {
            progressValue += 1f;
            progressValue = Mathf.Min(progressValue, 100f);

            loadingSlider.value = progressValue;
            percentText.text = $"{(int)progressValue}%";

            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(2f);

        asyncLoad.allowSceneActivation = true;
    }
}
