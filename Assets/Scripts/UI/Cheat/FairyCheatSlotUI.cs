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
    /// 페어리 이름 텍스트
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI fairyName;

    /// <summary>
    /// 등급 bg
    /// </summary>
    [SerializeField]
    private Image bg;

    /// <summary>
    /// 등급 프레임
    /// </summary>
    [SerializeField]
    private Image frame;

    /// <summary>
    /// 페어리 이미지
    /// </summary>
    [SerializeField]
    private Image fairyImage;

    /// <summary>
    /// 부여된 fid
    /// </summary>
    public uint FID { get; private set; }

    private void Awake()
    {
        Toggle toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener((isOn) => { Debug.Log($"[{toggle.name}] isOn: {isOn}"); });
    }

    /// <summary>
    /// 페어리 슬롯을 업데이트하는 함수
    /// </summary>
    /// <param name="fid">페어리 종류</param>
    public void RefreshFairySlot(uint fid)
    {
        FID = fid;

        string bgAddress = ConvertHelpers.GetFairyGradeBGAddress((FairyGrade)Table_Fairy.Instance.GetFairyGrade(fid));
        string frameAddress = ConvertHelpers.GetFairyGradeFrameAddress((FairyGrade)Table_Fairy.Instance.GetFairyGrade(fid));
        AddressableUtility.LoadSpriteByAddress(bgAddress, bg);
        AddressableUtility.LoadSpriteByAddress(frameAddress, frame);

        string fairyImageAddress = Table_Fairy.Instance.GetFairyProfileImageAddress(fid);
        if (fairyImageAddress != string.Empty)
        {
            Debug.Log($"RefreshFairySlot : {fairyImageAddress}");
            AddressableUtility.LoadSpriteByAddress(fairyImageAddress, fairyImage);
        }

        fairyName.text = Table_Fairy.Instance.GetFairyName(fid);
    }
}
