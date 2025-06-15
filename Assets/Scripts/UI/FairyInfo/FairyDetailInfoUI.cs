using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 페어리의 상세 정보창
/// </summary>
public class FairyDetailInfoUI : MonoBehaviour
{
    /// <summary>
    /// 페어리 일러스트
    /// </summary>
    [SerializeField]
    private Image fairyImage;

    /// <summary>
    /// 페어리 번호
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI fairyNumber;

    /// <summary>
    /// 페어리 별
    /// </summary>
    [SerializeField]
    private Image[] fairyStars;

    /// <summary>
    /// 페어리 이름
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI fairyName;

    /// <summary>
    /// 페어리 타입
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI fairyType;

    /// <summary>
    /// 페어리 공격력
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI fairyAttackPower;

    /// <summary>
    /// 페어리 공격 속도
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI fairyAttackSpeed;

    /// <summary>
    /// 페어리 치명타율
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI fairyCriticalProbability;

    /// <summary>
    /// 페어리 치명타 데미지
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI fairyCriticalDamage;

    /// <summary>
    /// 페어리 레벨
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI fairyLevel;

    /// <summary>
    /// 페어리 아이템 UI
    /// </summary>
    [SerializeField]
    private FairyItemUI fairyItemUI;

    /// <summary>
    /// 페어리 스킬 UI
    /// </summary>
    [SerializeField]
    private FairySkillUI fairySkillUI;

    private void Start()
    {
        
    }

    /// <summary>
    /// 페어리 상세 정보창을 새로고침하는 함수
    /// </summary>
    /// <param name="baseStatusData">페어리 기본 스테이터스 데이터</param>
    /// <param name="detailFairyData">페어리 상세 스테이터스 데이터</param>
    public void RefreshFairyDetailInfo(FairyBaseStatusData baseStatusData, FairyDetailStatusData detailFairyData)
    {
        // 페어리 사진
        fairyNumber.text = $"No.{baseStatusData.FID.ToString("D4")}";
        // 별 개수 맞추기
        // 페어리 이름
        // 페어리 타입
        fairyAttackPower.text = $"공격력 : {baseStatusData.AttackPower}";
        fairyAttackSpeed.text = $"공격 속도 : {baseStatusData.AttackSpeed}";
        // 치명타률
        // 치명타 데미지
        // 레벨
        fairyItemUI.RefreshItemUI();
        fairySkillUI.RefreshSkillUI();
    }
}
