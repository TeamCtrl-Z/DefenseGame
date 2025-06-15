using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 페어리 슬롯 UI 클래스
/// </summary>
public class FairySlotUI : MonoBehaviour
{
    /// <summary>
    /// 슬롯 버튼
    /// </summary>
    public Button SlotButton { get; private set; }

    /// <summary>
    /// 페어리 레벨 텍스트
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI fairyLevel;

    /// <summary>
    /// 페어리 이미지
    /// </summary>
    [SerializeField]
    private Image fairyImage;

    /// <summary>
    /// 페어리 디테일 데이터
    /// </summary>
    private FairyDetailStatusData fairyStatus;

    /// <summary>
    /// 슬롯을 터치하면 실행되는 이벤트
    /// </summary>
    public event Action<FairyDetailStatusData> onSlotTouch;

    private void Awake()
    {
        SlotButton = GetComponent<Button>();
    }

    private void Start()
    {
        SlotButton.onClick.AddListener(() => { 
            onSlotTouch?.Invoke(fairyStatus);
        });
    }

    /// <summary>
    /// 페어리 슬롯을 업데이트하는 함수
    /// </summary>
    /// <param name="fairyStatus">페어리의 정보</param>
    public void RefreshFairySlot(FairyDetailStatusData fairyStatus)
    {
        this.fairyStatus = fairyStatus;
        // 페어리 이미지 넣기
        // fairyImage = 
        fairyLevel.text = $"Lv.{fairyStatus.Level}";
    }
}
