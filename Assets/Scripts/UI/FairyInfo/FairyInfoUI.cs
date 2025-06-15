using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 페어리 정보창 UI 클래스
/// </summary>
public class FairyInfoUI : MonoBehaviour
{
    /// <summary>
    /// Fairy 슬롯들
    /// </summary>
    [SerializeField]
    private FairySlotUI[] fairySlots;

    /// <summary>
    /// 페어리 정보창 닫기 버튼
    /// </summary>
    [SerializeField]
    public Button CloseButton { get; private set; }

    /// <summary>
    /// 페어리 정보창 버튼(누르면 닫힘)
    /// </summary>
    [SerializeField]
    public Button FairyInfoButton { get; private set; }

    /// <summary>
    /// 페어리 정보창의 CG
    /// </summary>
    private CanvasGroup fairyInfoCG;

    private void Awake()
    {
        fairyInfoCG = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        CloseButton.onClick.AddListener(() => { CloseFairyInfoUI(); });
        FairyInfoButton.onClick.AddListener(() => { CloseFairyInfoUI(); });
    }

    /// <summary>
    /// 페어리 정보창을 끄는 함수
    /// </summary>
    private void CloseFairyInfoUI()
    {
        StartCoroutine(CloseFairyInfoUICoroutine());
    }

    private void RefreshFairySlot()
    {
        
    }

    private void FairySorting()
    {
        
    }

    /// <summary>
    /// 페어리 정보창을 끄는 코루틴
    /// </summary>
    private IEnumerator CloseFairyInfoUICoroutine()
    {
        float timeElapsed = 0.2f;

        while (timeElapsed > 0f)
        {
            timeElapsed -= Time.deltaTime;
            fairyInfoCG.alpha = timeElapsed * 5;
            yield return null;
        }

        fairyInfoCG.alpha = 0f;
        fairyInfoCG.interactable = false;
        fairyInfoCG.blocksRaycasts = false;
    }
}
