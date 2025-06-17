using System.Collections;
using System.Collections.Generic;
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
        //goldModifyBtn.onClick.AddListener
    }

    private void ClickGoldModifyBtn()
    {

    }

    private void ClickGemModifyBtn()
    {

    }

    private void ClickDiaModifyBtn()
    {

    }
}
