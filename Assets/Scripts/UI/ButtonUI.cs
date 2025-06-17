using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 버튼 UI 클래스
/// </summary>
public class ButtonUI : MonoBehaviour
{
    /// <summary>
    /// 페어리 정보 버튼
    /// </summary>
    [SerializeField]
    private Button fairyInfoButton;

    /// <summary>
    /// 치트키 선택창 오픈 버튼
    /// </summary>
    [SerializeField]
    private Button cheatOpenButton;

    /// <summary>
    /// 페어리 정보UI(나중에 UI컴포넌트로 바꾸기)
    /// </summary>
    [SerializeField]
    private CanvasGroup fairyInfoCG;

    /// <summary>
    /// 치트키 선택창 UI의 CG
    /// </summary>
    [SerializeField]
    private CanvasGroup cheatSelectCG;

    private void Start()
    {
        fairyInfoButton.onClick.AddListener(() => { OpenFairyInfoUI(); });
        cheatOpenButton.onClick.AddListener(() => { OpenCheatSelectUI(); });
    }

    /// <summary>
    /// 페어리 정보창을 여는 함수
    /// </summary>
    private void OpenFairyInfoUI()
    {
        StartCoroutine(UIUtility.OpenPopupUIWithCanvasGroup(fairyInfoCG));
    }

    private void OpenCheatSelectUI()
    {
        StartCoroutine(UIUtility.OpenPopupUIWithCanvasGroup(cheatSelectCG));
        ToastManager.Instance.ShowToast("abasbabasdfasdfasfdasf");
    }

}
