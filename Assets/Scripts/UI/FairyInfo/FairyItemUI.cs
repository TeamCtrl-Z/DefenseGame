using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 페어리 아이템 정보창
/// </summary>
public class FairyItemUI : MonoBehaviour
{
    /// <summary>
    /// 무기 이미지
    /// </summary>
    [SerializeField]
    private Image weaponImage;

    /// <summary>
    /// 나침반 이미지
    /// </summary>
    [SerializeField]
    private Image compassImage;

    /// <summary>
    /// 악세 이미지
    /// </summary>
    [SerializeField]
    private Image accessoryImage;

    /// <summary>
    /// 무기 버튼
    /// </summary>
    [SerializeField]
    private Button weaponButton;

    /// <summary>
    /// 나침반 버튼
    /// </summary>
    [SerializeField]
    private Button compassButton;

    /// <summary>
    /// 악세 버튼
    /// </summary>
    [SerializeField]
    private Button accessoryButton;

    public void RefreshItemUI()
    {
        // 무기 이미지 넣기
        // 나침반 이미지 넣기
        // 악세 이미지 넣기
    }
}
