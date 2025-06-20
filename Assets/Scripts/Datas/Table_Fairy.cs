using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 페어리 관련 CSV파일 로드 테이블 클래스
/// </summary>
public class Table_Fairy : TableClass
{
    /// <summary>
    /// 싱글톤용 instance 변수
    /// </summary>
    private static Table_Fairy instance;

    /// <summary>
    /// 참조하기 위한 instance 프로퍼티
    /// </summary>
    public static Table_Fairy Instance => instance ??= new Table_Fairy();

    /// <summary>
    /// 페어리 기본 스탯 데이터 테이블
    /// </summary>
    private Dictionary<uint, FairyBaseStatusData> statusTable;

    /// <summary>
    /// 페어리 attribute 데이터 테이블 - k : fid, v : FairyStatusData
    /// </summary>
    private Dictionary<uint, FairySkillData> skillTable;

    /// <summary>
    /// 페어리 정보 데이터 테이블 - k: fid, v : FairyInfoData
    /// </summary>
    private Dictionary<uint, FairyInfoData> infoTable;

    /// <summary>
    /// 생성자 막기 용도
    /// </summary>
    private Table_Fairy()
    { }

    /// <summary>
    /// 테이블 로드
    /// </summary>
    public override void LoadTable()
    {
        base.LoadTable();

        statusTable = CsvLoader.LoadTable<FairyBaseStatusData>("table_fairyStatus");
        skillTable = CsvLoader.LoadTable<FairySkillData>("table_fairySkill");
        infoTable = CsvLoader.LoadTable<FairyInfoData>("table_fairyInfo");
    }

    #region StatusData
    /// <summary>
    /// StatusData를 얻는 함수
    /// </summary>
    /// <param name="fid"> 페어리 아이디 </param>
    /// <param name="statData"> 해당 statusData </param>
    /// <returns>성공 실패</returns>
    public bool TryGetStatData(uint fid, out FairyBaseStatusData statData)
    {
        statData = null;
        if (!statusTable.ContainsKey(fid))
            return false;

        statData = statusTable[fid];
        return true;
    }

    /// <summary>
    /// 해당 페어리의 타겟팅 타입을 얻는 함수
    /// </summary>
    /// <param name="fid"> 페어리 아이디 </param>
    /// <param name="targetingType"> 해당 타겟팅 타입 </param>
    /// <returns> 성공 실패 </returns>
    public bool TryGetTargetingType(uint fid, out TargetingType targetingType)
    {
        targetingType = TargetingType.Nearest;
        if (!statusTable.ContainsKey(fid))
            return false;

        FairyBaseStatusData statData = statusTable[fid];
        if (statData == null)
            return false;

        targetingType = statData.Target;
        return true;
    }

    /// <summary>
    /// 페어리의 공격력을 알려주는 함수
    /// </summary>
    /// <param name="fid">페어리 종류</param>
    /// <returns>공격력 (못찾으면 null)</returns>
    public float? GetFairyAttackPower(uint fid)
    {
        if (!statusTable.ContainsKey(fid))
        {
            Debug.LogError($"{fid}라는 페어리 아이디는 존재하지 않습니다.");
            return null;
        }

        return statusTable[fid].AttackPower;
    }

    /// <summary>
    /// 페어리의 공격 속도를 알려주는 함수
    /// </summary>
    /// <param name="fid"> 페어리 종류 </param>
    /// <returns>공격 속도(못찾으면 null)</returns>
    public float? GetFairyAttackSpeed(uint fid)
    {
        if (!statusTable.ContainsKey(fid))
        {
            Debug.LogError($"{fid}라는 페어리 아이디는 존재하지 않습니다.");
            return null;
        }

        return statusTable[fid].AttackSpeed;
    }

    /// <summary>
    /// 페어리의 공격 타입을 알려주는 함수
    /// </summary>
    /// <param name="fid"> 해당 페어리 종류</param>
    /// <returns>공격 타입(못찾으면 null)</returns>
    public AttackType? GetFairyAttackType(uint fid)
    {
        if (!statusTable.ContainsKey(fid))
        {
            Debug.LogError($"{fid}라는 페어리 아이디는 존재하지 않습니다.");
            return null;
        }

        return statusTable[fid].AttackType;
    }

    /// <summary>
    /// 페어리 Attack ID 반환 함수
    /// </summary>
    /// <param name="fid">해당 페어리 종류</param>
    /// <returns>Attack ID(못찾으면 null)</returns>
    public uint? GetFairyAttackId(uint fid)
    {
        if (!statusTable.ContainsKey(fid))
        {
            Debug.LogError($"{fid}라는 페어리 아이디는 존재하지 않습니다.");
            return null;
        }

        return statusTable[fid].AttackId;
    }
    #endregion

    #region AttributeData

    /// <summary>
    /// AttributeData(Csv파일 데이터 저장본)을 얻는 함수
    /// </summary>
    /// <param name="fid"> 페어리 아이디 </param>
    /// <param name="attributeData"> 속성 데이터 </param>
    /// <returns>성공 실패</returns>
    public bool TryGetSkillData(uint fid, out FairySkillData attributeData)
    {
        attributeData = null;
        if (!skillTable.ContainsKey(fid))
            return false;

        attributeData = skillTable[fid];
        return true;
    }

    #endregion

    #region Fairy Info
    /// <summary>
    /// 해당 페어리의 등급을 알려주는 함수
    /// </summary>
    /// <param name="fid">알고 싶은 페어리</param>
    /// <returns>해당 등급</returns>
    public FairyGrade? GetFairyGrade(uint fid)
    {
        if (!infoTable.ContainsKey(fid))
            return null;
        return infoTable[fid].Grade;
    }

    /// <summary>
    /// 페어리의 모든 fid를 List로 반환해주는 함수
    /// </summary>
    /// <returns>fid 리스트</returns>
    public List<uint> GetTotalFairyId()
    {
        return infoTable.Keys.ToList();
    }

    /// <summary>
    /// 페어리 이름을 알려주는 함수
    /// </summary>
    /// <param name="fid">페어리 종류</param>
    /// <returns>페어리 이름</returns>
    public string GetFairyName(uint fid)
    {
        if (!infoTable.ContainsKey(fid))
            return null;
        return infoTable[fid].Name;
    }
    
    /// <summary>
    /// 페어리 인게임 이미지 주소를 알려주는 함수
    /// </summary>
    /// <param name="fid"> 페어리 종류 </param>
    /// <returns>이미지 주소</returns>
    public string GetFairyInGameImageAddress(uint fid)
    {
        if (!infoTable.ContainsKey(fid))
            return null;
        return infoTable[fid].Image_1;
    }

    /// <summary>
    /// 페어리 프로필 이미지 주소를 알려주는 함수
    /// </summary>
    /// <param name="fid"> 페어리 종류 </param>
    /// <returns>이미지 주소</returns>
    public string GetFairyProfileImageAddress(uint fid)
    {
        if (!infoTable.ContainsKey(fid))
            return null;
        return infoTable[fid].Image_2;
    }

    /// <summary>
    /// 페어리 일러스트 이미지 주소를 알려주는 함수
    /// </summary>
    /// <param name="fid"> 페어리 종류 </param>
    /// <returns>이미지 주소</returns>
    public string GetFairyIllustImageAddress(uint fid)
    {
        if (!infoTable.ContainsKey(fid))
            return null;
        return infoTable[fid].Image_3;
    }

    #endregion
}