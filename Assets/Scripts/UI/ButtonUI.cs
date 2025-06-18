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
    /// 페어리 정보UI(나중에 UI컴포넌트로 바꾸기)
    /// </summary>
    [SerializeField]
    private Button boatOperationButton;

    /// <summary>
    /// 페어리 정보UI CG
    /// </summary>
    private CanvasGroup fairyInfoCG;

    /// <summary>
    /// 보트 운용UI CG
    /// </summary>
    private CanvasGroup boatOperationCG;

    private void Start()
    {
        fairyInfoCG = UIManager.Instance.FairyInfo.FairyInfoCG;
        boatOperationCG = UIManager.Instance.BoatOperation.BoatOpertaionCG;

        fairyInfoButton.onClick.AddListener(() =>
        {
            UIManager.Instance.FadeUI.Fade(() => 
            {
                UIUtility.OpenPopupUIWithCanvasGroup(fairyInfoCG);
            });
        });

        boatOperationButton.onClick.AddListener(() =>
        {
            UIManager.Instance.FadeUI.Fade(() =>
            {
                UIUtility.OpenPopupUIWithCanvasGroup(boatOperationCG);
            });
        });
    }
}
