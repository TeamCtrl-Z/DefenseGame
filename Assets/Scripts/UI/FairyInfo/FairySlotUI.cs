using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 페어리 슬롯 UI
/// </summary>
public class FairySlotUI : MonoBehaviour
{
    /// <summary>
    /// 슬롯 버튼
    /// </summary>
    public Button SlotButton { get; private set; }

    /// <summary>
    /// 페어리 레벨
    /// </summary>
    [SerializeField] private TextMeshProUGUI fairyLevel;

    /// <summary>
    /// 페어리 이미지
    /// </summary>
    [SerializeField] private Image fairyImage;

    /// <summary>
    /// 페어리 배경
    /// </summary>
    [SerializeField] private Image fairyBG;

    /// <summary>
    /// 페어리 프레임
    /// </summary>
    [SerializeField] private Image fairyFrame;

    /// <summary>
    /// 페어리 배치 여부
    /// </summary>
    [SerializeField] private Image fairyPlace;

    /// <summary>
    /// 페어리 인스턴스 데이터
    /// </summary>
    public FairyInstanceData FairyInstanceData { get; private set; }

    /// <summary>
    /// 슬롯을 터치하면 실행되는 이벤트
    /// </summary>
    public event Action<FairyInstanceData> onSlotTouch;

    private void Awake()
    {
        SlotButton = GetComponent<Button>();
    }

    private void Start()
    {
        SlotButton.onClick.AddListener(() => onSlotTouch?.Invoke(FairyInstanceData));
    }

    /// <summary>
    /// 페어리 슬롯을 업데이트하는 함수
    /// </summary>
    /// <param name="fairyInstanceData">페어리 인스턴스 데이터</param>
    public void RefreshFairySlot(FairyInstanceData fairyInstanceData)
    {
        if (fairyInstanceData == null)
        {
            gameObject.SetActive(false);
            return;
        }

        gameObject.SetActive(true);
        FairyInstanceData = fairyInstanceData;
        fairyLevel.text = $"Lv.{fairyInstanceData.Level}";
        string fairyImageAddress = fairyInstanceData.FairyProfileImage;
        if (fairyImageAddress != string.Empty)
            AddressableUtility.LoadSpriteByAddress(fairyImageAddress, fairyImage);
        SetGradeSlot(fairyInstanceData.Grade);
        //fairyPlace.enabled = fairyInstanceData.IsPlaced;
    }

    /// <summary>
    /// 등급 별로 슬롯 배경과 프레임을 바꾸는 함수
    /// </summary>
    /// <param name="grade">페어리 등급</param>
    private void SetGradeSlot(FairyGrade grade)
    {
        string bgAddress = ConvertHelpers.GetFairyGradeBGAddress(grade);
        string frameAddress = ConvertHelpers.GetFairyGradeFrameAddress(grade);

        if (bgAddress == null || frameAddress == null) return;
        
        AddressableUtility.LoadSpriteByAddress(bgAddress, fairyBG);
        AddressableUtility.LoadSpriteByAddress(frameAddress, fairyFrame);
    }
}
