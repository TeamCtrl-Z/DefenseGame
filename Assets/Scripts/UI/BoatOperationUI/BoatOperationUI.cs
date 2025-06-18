using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 보트 운용창 UI
/// </summary>
public class BoatOperationUI : MonoBehaviour
{
    /// <summary>
    /// 페어리 정보창 버튼(누르면 닫힘)
    /// </summary>
    [field: SerializeField]
    public Button FairyInfoButton { get; private set; }

    /// <summary>
    /// 보트 운용창 버튼
    /// </summary>
    [field: SerializeField]
    public Button BoatOperationButton { get; private set; }

    /// <summary>
    /// 보트 운용UI CG
    /// </summary>
    public CanvasGroup BoatOpertaionCG { get; private set; }

    private void Awake()
    {
        BoatOpertaionCG = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        FairyInfoButton.onClick.AddListener(() =>
        {
            UIManager.Instance.FadeUI.Fade(() =>
            {
                UIUtility.ClosePopupUIWithCanvasGroup(BoatOpertaionCG);
                UIUtility.OpenPopupUIWithCanvasGroup(UIManager.Instance.FairyInfo.FairyInfoCG);
            });
        });

        BoatOperationButton.onClick.AddListener(() =>
        {
            UIManager.Instance.FadeUI.Fade(() =>
            {
                UIUtility.ClosePopupUIWithCanvasGroup(BoatOpertaionCG);
            });
        });
    }
}
