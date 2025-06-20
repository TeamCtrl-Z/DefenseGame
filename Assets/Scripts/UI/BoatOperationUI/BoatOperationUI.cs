using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 보트 운용창 UI
/// </summary>
public class BoatOperationUI : MonoBehaviour
{
    /// <summary>
    /// 창 닫기 버튼
    /// </summary>
    [SerializeField]
    private Button closeButton;

    /// <summary>
    /// 페어리 정보창 버튼(누르면 닫힘)
    /// </summary>
    [SerializeField]
    private Button fairyInfoButton;

    /// <summary>
    /// 보트 운용창 버튼
    /// </summary>
    [SerializeField]
    private Button boatOperationButton;

    /// <summary>
    /// 보트 운용UI CG
    /// </summary>
    [field: SerializeField]
    public CanvasGroup BoatOpertaionCG { get; private set; }

    private void Start()
    {
        closeButton.onClick.AddListener(() =>
        {
            UIManager.Instance.FadeUI.Fade(() =>
            {
                fairyInfoButton.interactable = false;
                boatOperationButton.interactable = false;
            }
            , () =>
            {
                UIUtility.ClosePopupUIWithCanvasGroup(BoatOpertaionCG);
            }
            , () =>
            {
                fairyInfoButton.interactable = true;
                boatOperationButton.interactable = true;
            });
        });

        fairyInfoButton.onClick.AddListener(() =>
        {
            UIManager.Instance.FadeUI.Fade(() =>
            {
                fairyInfoButton.interactable = false;
                boatOperationButton.interactable = false;
            }
            , () =>
            {
                UIUtility.ClosePopupUIWithCanvasGroup(BoatOpertaionCG);
                UIUtility.OpenPopupUIWithCanvasGroup(UIManager.Instance.FairyInfo.FairyInfoCG);
            }
            , () =>
            {
                fairyInfoButton.interactable = true;
                boatOperationButton.interactable = true;
            });
        });

        boatOperationButton.onClick.AddListener(() =>
        {
            UIManager.Instance.FadeUI.Fade(() =>
            {
                fairyInfoButton.interactable = false;
                boatOperationButton.interactable = false;
            }
            , () =>
            {
                UIUtility.ClosePopupUIWithCanvasGroup(BoatOpertaionCG);
            }
            , () =>
            {
                fairyInfoButton.interactable = true;
                boatOperationButton.interactable = true;
            });
        });
    }
}
