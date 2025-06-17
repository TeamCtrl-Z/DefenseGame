using System;
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
    /// Fairy의 디테일 Info
    /// </summary>
    [SerializeField]
    private FairyDetailInfoUI detailInfo;

    /// <summary>
    /// FairyInfoUI의 Sorting 클래스
    /// </summary>
    [SerializeField]
    private SortingFairyUI sortingFairyUI;

    /// <summary>
    /// 페어리 정보창 닫기 버튼
    /// </summary>
    [field:SerializeField]
    public Button CloseButton { get; private set; }

    /// <summary>
    /// 페어리 정보창 버튼(누르면 닫힘)
    /// </summary>
    [field:SerializeField]
    public Button FairyInfoButton { get; private set; }

    /// <summary>
    /// 페어리 정보창의 CG
    /// </summary>
    private CanvasGroup fairyInfoCG;

    /// <summary>
    /// 현재 정렬 타입
    /// </summary>
    private FairySortCriteiria currentSortCriteria = FairySortCriteiria.Number;

    /// <summary>
    /// 정렬 순서
    /// </summary>
    private bool isAscending = true;

    private void Awake()
    {
        fairyInfoCG = GetComponent<CanvasGroup>();

        sortingFairyUI.onSortingChanged += SetSortAndRefresh;
        FairyInfoInitialize();
    }

    private void Start()
    {
        CloseButton.onClick.AddListener(() => { CloseFairyInfoUI(); });
        FairyInfoButton.onClick.AddListener(() => { CloseFairyInfoUI(); });
    }

    private void OnEnable()
    {
        RefreshFairySlot();
    }

    /// <summary>
    /// 페어리 정보창을 끄는 함수
    /// </summary>
    private void CloseFairyInfoUI()
    {
        StartCoroutine(UIUtility.ClosePopupUIWithCanvasGroup(fairyInfoCG));
    }

    /// <summary>
    /// 슬롯과 페어리 DetailInfo를 초기화하는 함수
    /// </summary>
    private void FairyInfoInitialize()
    {
        foreach (var slot in fairySlots)
        {
            slot.onSlotTouch += detailInfo.RefreshFairyDetailInfo;
        }
    }

    /// <summary>
    /// 현재 정렬 기준과 방향으로 페어리 슬롯을 새로 고침
    /// </summary>
    public void RefreshFairySlot()
    {
        List<FairyInstanceData> fairyList = DataService.Instance.FairyDataManager.GetAllFairyInstanceData();
        SortFairyList(ref fairyList, currentSortCriteria, isAscending);

        for (int i = 0; i < fairySlots.Length; i++)
        {
            if (i < fairyList.Count)
            {
                fairySlots[i].gameObject.SetActive(true);
                fairySlots[i].RefreshFairySlot(fairyList[i]);
            }
            else
            {
                fairySlots[i].gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// 외부 UI 버튼에서 호출하는 정렬 변경 함수
    /// </summary>
    public void SetSortAndRefresh(FairySortCriteiria sortCriteria, bool ascending)
    {
        currentSortCriteria = sortCriteria;
        isAscending = ascending;
        RefreshFairySlot();
    }

    /// <summary>
    /// 정렬 수행만 담당하는 함수 (리스트 전달받음)
    /// </summary>
    private void SortFairyList(ref List<FairyInstanceData> list, FairySortCriteiria sortCriteria, bool isAscending)
    {
        list.Sort((a, b) =>
        {
            if (a == null) return 1;
            if (b == null) return -1;

            int primary = sortCriteria switch
            {
                FairySortCriteiria.Grade => a.Grade.CompareTo(b.Grade),
                FairySortCriteiria.Level => a.Level.CompareTo(b.Level),
                FairySortCriteiria.CompoundLevel => a.CompoundLevel.CompareTo(b.CompoundLevel),
                _ => a.FID.CompareTo(b.FID)
            };

            if (primary == 0)
                primary = a.FID.CompareTo(b.FID);

            return isAscending ? primary : -primary;
        });
    }
}
