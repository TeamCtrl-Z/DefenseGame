using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 페어리 스킬 정보창
/// </summary>
public class FairySkillUI : MonoBehaviour
{
    /// <summary>
    /// 패시브 스킬 이미지
    /// </summary>
    [SerializeField]
    private Image passiveSkillImage;

    /// <summary>
    /// 패시브 스킬 설명
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI passiveSkillText;

    /// <summary>
    /// 액티브 스킬 이미지
    /// </summary>
    [SerializeField]
    private Image activeSkillImage;

    /// <summary>
    /// 액티브 스킬 설명
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI activeSkillText;

    public void RefreshSkillUI()
    {
        // 패시브 스킬 이미지 넣기
        // 패시브 스킬 설명 넣기
        // 엑티브 스킬 이미지 넣기
        // 엑티브 스킬 설명 넣기
    }
}
