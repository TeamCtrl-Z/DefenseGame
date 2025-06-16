using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
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
    /// 페어리 이름
    /// </summary>
    public string Name;

    /// <summary>
    /// 페어리 타입
    /// </summary>
    public string Type;

    /// <summary>
    /// 페어리 일러스트 주소(Addressable)
    /// </summary>
    public string FairyImage;

    /// <summary>
    /// 페어리 등급
    /// </summary>
    public FairyGrade Grade => Table_Fairy.Instance.GetFairyGrade(FID) ?? FairyGrade.Normal;

    /// <summary>
    /// 페어리 레벨
    /// </summary>
    public uint Level;

    /// <summary>
    /// 페어리 승급 레벨(별 갯수)
    /// </summary>
    public uint CompoundLevel;

    /// <summary>
    /// 페어리 보유 수(승급 용)
    /// </summary>
    public uint Count;

    /// <summary>
    /// 페어리가 착용한 아이템 리스트
    /// </summary>
    private List<EquipmentData> equipments = new();

    /// <summary>
    /// 착용한 아이템 리스트 프로퍼티
    /// </summary>
    public List<EquipmentData> Equipments
    {
        get => equipments;
        set
        {
            equipments = value;
            EquipmentsBySlot = value.ToDictionary(e => (ItemType)e.SlotType, e => e.IOID);
        }
    }

    /// <summary>
    /// 해당 슬롯에 장착된 아이템
    /// </summary>
    [JsonIgnore]
    public Dictionary<ItemType, string> EquipmentsBySlot { get; private set; } = new();

    /// <summary>
    /// 페어리 기본 공격력
    /// </summary>
    private float baseAttackPower => Table_Fairy.Instance.GetFairyAttackPower(FID) ?? 0.0f;

    /// <summary>
    /// 추가 공격력
    /// </summary>
    private float bonusAttackPower => Equipments.Sum(equip =>
        DataService.Instance.ItemDataManager.TryGetItemDataByIoid(equip.IOID, out var data) ? data.AttackPowerBonus : 0f);

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
    private float bonusAttackSpeed => Equipments.Sum(equip =>
        DataService.Instance.ItemDataManager.TryGetItemDataByIoid(equip.IOID, out var data) ? data.AttackSpeedBonus : 0f);

    /// <summary>
    /// 페어리 공격 스피드(기본 스피드 * 추가 스피드 속도 비율)
    /// </summary>
    public float AttackSpeed => baseAttackSpeed * bonusAttackSpeed;

    /// <summary>
    /// 페어리 치명타율
    /// </summary>
    public float CriticalProbability;

    /// <summary>
    /// 페어리 치명타 데미지
    /// </summary>
    public float CirticalDamage;

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
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환될 페어리</returns>
    public FairyController GetFairyInstance(Vector3 position, float angle)
    {
        return Factory.Instance.GetFairyByType((FairyType)FID, this, position, angle);
    }
}