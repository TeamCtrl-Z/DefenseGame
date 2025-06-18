using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 재화 치트 UI
/// </summary>
public class CurrencyCheatUI : MonoBehaviour
{
    /// <summary>
    /// 닫기 버튼
    /// </summary>
    [SerializeField]
    private Button closeBtn;

    /// <summary>
    /// 골드 수정 버튼
    /// </summary>
    [SerializeField]
    private Button goldModifyBtn;

    /// <summary>
    /// 골드 인풋
    /// </summary>
    [SerializeField]
    private TMP_InputField goldInput;

    /// <summary>
    /// 젬 수정 버튼
    /// </summary>
    [SerializeField]
    private Button gemModifyBtn;

    /// <summary>
    /// 젬 인풋
    /// </summary>
    [SerializeField]
    private TMP_InputField gemInput;

    /// <summary>
    /// 다이아 수정 버튼
    /// </summary>
    [SerializeField]
    private Button diaModifyBtn;

    /// <summary>
    /// 다이아 인풋
    /// </summary>
    [SerializeField]
    private TMP_InputField diaInput;

    private void Awake()
    {
        closeBtn.onClick.AddListener(() => { gameObject.SetActive(false); });
        goldModifyBtn.onClick.AddListener(() => { ClickCurrencyModifyBtn(CurrencyType.Gold); });
        gemModifyBtn.onClick.AddListener(() => { ClickCurrencyModifyBtn(CurrencyType.Gem); });
        diaModifyBtn.onClick.AddListener(() => { ClickCurrencyModifyBtn(CurrencyType.Diamond); });
    }

    private void ClickCurrencyModifyBtn(CurrencyType type)
    {
        string input = type switch
        {
            CurrencyType.Gold => goldInput.text,
            CurrencyType.Gem => gemInput.text,
            CurrencyType.Diamond => diaInput.text,
            _ => goldInput.text
        };

        if (input == "")
        {
            ToastManager.Instance.ShowToast($"얻고 싶은 재화 양을 입력해주세요.");
            return;
        }

        void success()
        {
            ToastManager.Instance.ShowToast($"{type.ToString()}가 수정되었습니다.");
        }

        if (ulong.TryParse(input, out ulong count))
        {
            StartCoroutine(ServerData_Items.RequestCheatModifyCurrency(type, count, success));
        }
        else
        {
            ToastManager.Instance.ShowToast($"입력 값은 0이상의 정수만 가능합니다. 현재 입력 값 {input}");
        }
    }
}
