using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 치트 버튼 셀
/// </summary>
public class CheatBtnCell : MonoBehaviour
{
    /// <summary>
    /// 버튼 설명 텍스트
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI btnText;

    /// <summary>
    /// 클릭했을 때 실행되는 이벤트
    /// </summary>
    private Action onClickEvent;

    /// <summary>
    /// 버튼
    /// </summary>
    private Button btn;

    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener( () => onClickEvent?.Invoke());
    }

    /// <summary>
    /// 초기화
    /// </summary>
    /// <param name="name"> 버튼 이름 </param>
    /// <param name="onClickEvent"> 클릭했을 때 실행되는 함수 </param>
    public void Initialize(string name, Action onClickEvent)
    {
        btnText.text = name;
        this.onClickEvent = onClickEvent;
    }
}
