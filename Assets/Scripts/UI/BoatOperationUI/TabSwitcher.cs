using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 탭을 바꾸는 UI클래스
/// </summary>
public class TabSwitcher : MonoBehaviour
{
    [Header("탭과 해당 버튼(버튼과 탭을 순서대로 넣을 것)")]
    /// <summary>
    /// 콘텐츠 탭들
    /// </summary>
    [SerializeField]
    private List<CanvasGroup> contentsTabs;

    /// <summary>
    /// 탭 버튼들
    /// </summary>
    [SerializeField]
    private List<Button> tabButtons;

    /// <summary>
    /// 버튼 이벤트
    /// </summary>
    public event Action<int> TabActions;

    /// <summary>
    /// 현재 탭
    /// </summary>
    private CanvasGroup currentTab;

    private void Awake()
    {
        for (int i = 0; i < tabButtons.Count; i++)
        {
            int idx = i;
            tabButtons[idx].onClick.AddListener(() => ShowTabs(idx));
        }
    }

    private void Start()
    {
        ShowTabs(0);
    }

    /// <summary>
    /// 탭을 보여주는 함수
    /// </summary>
    /// <param name="index">탭에 해당하는 인덱스</param>
    private void ShowTabs(int index)
    {
        CloseTabs();
        TabActions?.Invoke(index);
        currentTab = contentsTabs[index];
        contentsTabs[index].alpha = 1f;
        contentsTabs[index].interactable = true;
        contentsTabs[index].blocksRaycasts = true;
        contentsTabs[index].transform.parent.SetAsLastSibling();
    }

    /// <summary>
    /// 현재 탭을 끄는 함수
    /// </summary>
    private void CloseTabs()
    {
        if (currentTab != null)
        {
            currentTab.alpha = 0f;
            currentTab.interactable = false;
            currentTab.blocksRaycasts = false;
        }
    }
}
