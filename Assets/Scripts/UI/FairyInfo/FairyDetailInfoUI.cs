using System.Collections;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
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

    /// <summary>
    /// 페어리 상세 정보창을 새로고침하는 함수
    /// </summary>
    /// <param name="instanceData">페어리 인스턴스 데이터</param>
    public void RefreshFairyDetailInfo(FairyInstanceData instanceData)
    {
        RefreshFairyImage(instanceData.FairyImage);
        fairyNumber.text = $"No.{instanceData.FID.ToString("D4")}";
        RefreshCompoundImage(instanceData.CompoundLevel);
        fairyName.text = $"{instanceData.Name}";
        fairyType.text = $"{instanceData.Type}";
        fairyAttackPower.text = $"공격력 : {instanceData.AttackPower:f0}";
        fairyAttackSpeed.text = $"공격 속도 : {instanceData.AttackSpeed:f0}";
        fairyCriticalProbability.text = $"치명타율 : {instanceData.CriticalProbability:f0}";
        fairyCriticalDamage.text = $"치명타 데미지 : {instanceData.CirticalDamage:f0}";
        fairyLevel.text = $"Lv.{instanceData.Level}";
        fairyItemUI.RefreshItemUI();
        fairySkillUI.RefreshSkillUI();
    }

    /// <summary>
    /// CompoundLevel만큼 별 그림을 활성화하는 함수
    /// </summary>
    /// <param name="compoundLevel">초월 레벨</param>
    private void RefreshCompoundImage(uint compoundLevel)
    {
        for (int i = 0; i < fairyStars.Length; i++)
        {
            fairyStars[i].enabled = i < compoundLevel;
        }
    }

    /// <summary>
    /// 페어리 이미지를 Addressables를 이용해 새로고침하는 함수
    /// </summary>
    /// <param name="address">페어리 이미지 주소</param>
    private void RefreshFairyImage(string address)
    {
        Addressables.LoadAssetAsync<Sprite>(address).Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                Sprite loadedSprite = handle.Result;
                fairyImage.sprite = loadedSprite;
            }
            else
            {
                Debug.LogError($"[Addressables] Sprite 로드 실패: {address}");
            }
        };
    }
}
