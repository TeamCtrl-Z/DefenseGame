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
    /// 보트 운용 버튼
    /// </summary>
    [SerializeField]
    private Button boatOperationButton;

    /// <summary>
    /// 화면 전환 UI
    /// </summary>
    private FadeUI fadeUI;

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
        fadeUI = UIManager.Instance.FadeUI;
        fairyInfoCG = UIManager.Instance.FairyInfo.FairyInfoCG;
        boatOperationCG = UIManager.Instance.BoatOperation.BoatOpertaionCG;

        fairyInfoButton.onClick.AddListener(() =>
        {
            fadeUI.Fade(OpenFairyInfoUI);
        });

        boatOperationButton.onClick.AddListener(() =>
        {
            fadeUI.Fade(OpenBoatOperationUI);
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
    /// 보트 운용창을 여는 함수
    /// </summary>
    private void OpenBoatOperationUI()
    {
        boatOperationCG.alpha = 1f;
        boatOperationCG.interactable= true;
        boatOperationCG.blocksRaycasts = true;
    }
}
