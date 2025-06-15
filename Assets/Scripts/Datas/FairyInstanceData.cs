using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 서버에서 가져온 유저의 고유 페어리 데이터
/// </summary>
public class FairyInstanceData
{
    /// <summary>
    /// 페어리 아이디(종류)
    /// </summary>
    public uint FID;

    /// <summary>
    /// 페어리 인스턴스 아이디
    /// </summary>
    public string FOID;

    /// <summary>
    /// 페어리 등급
    /// </summary>
    public FairyGrade Grade;

    /// <summary>
    /// 페어리 레벨
    /// </summary>
    public uint Level;

    /// <summary>
    /// 페어리 합성 레벨(별 갯수)
    /// </summary>
    public uint CompoundLevel;

    /// <summary>
    /// 페어리 조각(승급 용)
    /// </summary>
    public uint FairyPieceCount;

    /// <summary>
    /// 페어리가 착용한 아이템 리스트(ioid)
    /// </summary>
    public List<string> EquippedItemList;

    /// <summary>
    /// 페어리 기본 공격력
    /// </summary>
    private float baseAttackPower => Table_Fairy.Instance.GetFairyAttackPower(FID) ?? 0.0f;

    /// <summary>
    /// 추가 공격력
    /// </summary>
    private float bonusAttackPower => EquippedItemList.Sum(ioid =>
        DataService.Instance.ItemDataManager.TryGetItemDataByIoid(ioid, out var data) ? data.AttackPowerBonus : 0f);

    /// <summary>
    /// 페어리 공격력(기본 공격력 + 추가 공격력)
    /// </summary>
    public float AttackPower => baseAttackPower + bonusAttackPower;

    /// <summary>
    /// 페어리 기본 공격 스피드
    /// </summary>
    private float baseAttackSpeed => Table_Fairy.Instance.GetFairyAttackSpeed(FID) ?? 0.0f;

    /// <summary>
    /// 추가 공격 스피드
    /// </summary>
    private float bonusAttackSpeed => EquippedItemList.Sum(ioid =>
        DataService.Instance.ItemDataManager.TryGetItemDataByIoid(ioid, out var data) ? data.AttackSpeedBonus : 0f);

    /// <summary>
    /// 페어리 공격 스피드(기본 스피드 * 추가 스피드 속도 비율)
    /// </summary>
    public float AttackSpeed => baseAttackSpeed * bonusAttackSpeed;

    /// <summary>
    /// 페어리 공격 타입
    /// </summary>
    public AttackType AttackType => Table_Fairy.Instance.GetFairyAttackType(FID) ?? global::AttackType.None;

    /// <summary>
    /// 페어리 공격 아이디(프로젝타일 종류)
    /// </summary>
    public uint AttackId => Table_Fairy.Instance.GetFairyAttackId(FID) ?? 0;

    /// <summary>
    /// 페어리 인스턴스 가져오기
    /// </summary>
    /// <param name="position"></param>
    /// <param name="angle"></param>
    /// <returns></returns>
    public FairyController GetFairyInstance(Vector3 position, float angle)
    {
        return Factory.Instance.GetFariyByType((FairyType)FID, this, position, angle);
    }
}