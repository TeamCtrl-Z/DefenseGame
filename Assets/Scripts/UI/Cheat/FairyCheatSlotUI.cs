using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 페어리 치트용 슬롯 UI 클래스
/// </summary>
public class FairyCheatSlotUI : MonoBehaviour
{
    /// <summary>
    /// 슬롯 버튼
    /// </summary>
    public Button SlotButton { get; private set; }

    /// <summary>
    /// 페어리 이름 텍스트
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI fairyName;

    /// <summary>
    /// 슬롯을 터치하면 실행되는 이벤트
    /// </summary>
    public event Action<uint> onSlotTouch;

    /// <summary>
    /// 내 fid
    /// </summary>
    private uint fid;

    private void Awake()
    {
        SlotButton = GetComponent<Button>();
    }

    private void Start()
    {
        SlotButton.onClick.AddListener(() =>
        {
            onSlotTouch?.Invoke(fid);
        });
    }

    /// <summary>
    /// 페어리 슬롯을 업데이트하는 함수
    /// </summary>
    /// <param name="fid">페어리 종류</param>
    public void RefreshFairySlot(uint fid)
    {
        this.fid = fid;
        // TODO : 페어리 등급에 맞는 image 삽입(enum으로 처리)
        // TODO : 페어리 이미지 넣기(Table_Fairy 참조)
        // fairyName.text = Table_Fairy.Instance.GetFairyName(fid);
    }
}
