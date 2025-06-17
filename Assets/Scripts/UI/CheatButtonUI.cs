using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 치트 선택창 오픈 버튼
/// </summary>
public class CheatButtonUI : MonoBehaviour
{
    /// <summary>
    /// 치트키 선택창 오픈 버튼
    /// </summary>
    [SerializeField]
    private Button cheatOpenButton;

    /// 치트키 선택창 UI의 CG
    /// </summary>
    [SerializeField]
    private CanvasGroup cheatSelectCG;

    private void Start()
    {
        cheatOpenButton.onClick.AddListener(() => { StartCoroutine(UIUtility.OpenPopupUIWithCanvasGroup(cheatSelectCG)); });
    }
}
