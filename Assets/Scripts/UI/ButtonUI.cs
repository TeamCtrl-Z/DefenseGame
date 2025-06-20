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

    private void Start()
    {
        fairyInfoButton.onClick.AddListener(() =>
        {
            UIManager.Instance.FadeUI.Fade(() => 
            {
                fairyInfoButton.interactable = false;
                boatOperationButton.interactable = false;
            }
            , () => 
            {
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
                UIUtility.OpenPopupUIWithCanvasGroup(UIManager.Instance.BoatOperation.BoatOpertaionCG);
            }
            , () =>
            {
                fairyInfoButton.interactable = true;
                boatOperationButton.interactable = true;
            });
        });
    }
}
