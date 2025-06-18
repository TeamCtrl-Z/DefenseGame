using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 치트 커맨드
/// </summary>
public enum CheatCommand
{
    /// <summary>
    /// 페어리 얻기 or 삭제
    /// </summary>
    FairyModify,

    /// <summary>
    /// 재화 얻기 or 삭제
    /// </summary>
    CurrencyModify,

    /// <summary>
    /// 아이템 얻기 or 삭제
    /// </summary>
    ItemModify,

    Max,
}

/// <summary>
/// 치트키 선택 UI 클래스
/// </summary>
public class CheatSelectUI : MonoBehaviour
{
    /// <summary>
    /// 치트 버튼 셀 프리팹
    /// </summary>
    [SerializeField]
    private GameObject cellPrefab;

    /// <summary>
    /// 치트 버튼 셀들 추가할 Content 트랜스폼
    /// </summary>
    [SerializeField]
    private Transform content;

    /// <summary>
    /// 닫기 버튼
    /// </summary>
    [SerializeField]
    private Button closeBtn;

    /// <summary>
    /// 페어리 치트 창
    /// </summary>
    [SerializeField]
    private GameObject fairyCheat;

    /// <summary>
    /// 재화 치트 창
    /// </summary>
    [SerializeField]
    private GameObject currencyCheat;

    /// <summary>
    /// 치트 선택창 CG
    /// </summary>
    private CanvasGroup canvasGroup;

    /// <summary>
    /// 치트 커맨드 타입으로 버튼 클릭 이벤트 액션 맵핑
    /// </summary>
    private Dictionary<CheatCommand, Action> cheatActionMap;

    /// <summary>
    /// 치트 커맨드 타입으로 버튼 이름 맵핑
    /// </summary>
    private Dictionary<CheatCommand, string> cheatNameMap;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        cheatActionMap = new();
        cheatNameMap = new();

        cheatActionMap[CheatCommand.FairyModify] = OpenFairyCheatUI;
        cheatActionMap[CheatCommand.CurrencyModify] = OpenCurrencyCheatUI;
        cheatActionMap[CheatCommand.ItemModify] = OpenItemCheatUI;

        cheatNameMap[CheatCommand.FairyModify] = "페어리 수정";
        cheatNameMap[CheatCommand.CurrencyModify] = "재화 수정";
        cheatNameMap[CheatCommand.ItemModify] = "아이템 수정";
    }

    private void Start()
    {
        closeBtn.onClick.AddListener(() => 
        {
            UIManager.Instance.FadeUI.Fade(() =>
            {
                UIUtility.OpenPopupUIWithCanvasGroup(canvasGroup);
            });
        });

        for (int i = 0; i < (int)CheatCommand.Max; i++)
        {
            AddItem((CheatCommand)i);
        }
    }

    /// <summary>
    /// 치트 아이템 셀 추가 함수
    /// </summary>
    /// <param name="cmd">치트 키 종류</param>
    private void AddItem(CheatCommand cmd)
    {
        GameObject cell = Instantiate(cellPrefab, content);
        var btnCell = cell.GetComponent<CheatBtnCell>();
        btnCell.Initialize(cheatNameMap[cmd], cheatActionMap[cmd]);
    }

    /// <summary>
    /// 페어리 치트 UI 오픈
    /// </summary>
    private void OpenFairyCheatUI()
    {
        fairyCheat.SetActive(true);
    }

    /// <summary>
    /// 재화 치트 UI 오픈
    /// </summary>
    private void OpenCurrencyCheatUI()
    {
        currencyCheat.SetActive(true);
    }

    /// <summary>
    /// 아이템 치트 UI 오픈
    /// </summary>
    private void OpenItemCheatUI()
    {

    }
}