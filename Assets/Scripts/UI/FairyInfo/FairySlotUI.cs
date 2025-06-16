using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
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
        SetGradeSlot(fairyInstanceData.Grade);
    }

    /// <summary>
    /// 등급 별로 슬롯 배경과 프레임을 바꾸는 함수
    /// </summary>
    /// <param name="grade">페어리 등급</param>
    private void SetGradeSlot(FairyGrade grade)
    {
        switch (grade) 
        {
            case FairyGrade.Normal:
                LoadSpriteByAddress("FairyGrade/NormalBG", fairyBG);
                LoadSpriteByAddress("FairyGrade/NormalFrame", fairyFrame);
                break;

            case FairyGrade.Magic:
                LoadSpriteByAddress("FairyGrade/MagicBG", fairyBG);
                LoadSpriteByAddress("FairyGrade/MagicFrame", fairyFrame);
                break;

            case FairyGrade.Rare:
                LoadSpriteByAddress("FairyGrade/RareBG", fairyBG);
                LoadSpriteByAddress("FairyGrade/RareFrame", fairyFrame);
                break;

            case FairyGrade.Unique:
                LoadSpriteByAddress("FairyGrade/UniqueBG", fairyBG);
                LoadSpriteByAddress("FairyGrade/UniqueFrame", fairyFrame);
                break;

            case FairyGrade.Legend:
                LoadSpriteByAddress("FairyGrade/LegendBG", fairyBG);
                LoadSpriteByAddress("FairyGrade/LegendFrame", fairyFrame);
                break;
        }

    }

    /// <summary>
    /// 주소로 스프라이트를 불러오는 함수
    /// </summary>
    /// <param name="address">불러올 주소</param>
    /// <param name="targetImage">스프라이트를 저장할 이미지 컴포넌트</param>
    private void LoadSpriteByAddress(string address, Image targetImage)
    {
        Addressables.LoadAssetAsync<Sprite>(address).Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                Sprite loadedSprite = handle.Result;
                targetImage.sprite = loadedSprite;
            }
            else
            {
                Debug.LogError($"[Addressables] Sprite 로드 실패: {address}");
            }
        };
    }
}
