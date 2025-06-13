using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    /// <summary>
    /// 페어리 정보 버튼
    /// </summary>
    [SerializeField]
    private Button fairyInfoButton;

    /// <summary>
    /// 페어리 정보UI(나중에 UI컴포넌트로 바꾸기)
    /// </summary>
    [SerializeField]
    private CanvasGroup fairyInfoCG;

    private void Start()
    {
        fairyInfoButton.onClick.AddListener(() =>
        {
            OpenFairyInfoUI();
        });
    }

    /// <summary>
    /// 페어리 정보창을 여는 함수
    /// </summary>
    private void OpenFairyInfoUI()
    {
        fairyInfoCG.alpha = 1f;
        fairyInfoCG.interactable = true;
        fairyInfoCG.blocksRaycasts = true;
    }

    /// <summary>
    /// 페어리 정보창을 닫는 함수
    /// </summary>
    private void CloseFairyInfoUI()
    {
        fairyInfoCG.alpha = 0f;
        fairyInfoCG.interactable = false;
        fairyInfoCG.blocksRaycasts = false;
    }
}
