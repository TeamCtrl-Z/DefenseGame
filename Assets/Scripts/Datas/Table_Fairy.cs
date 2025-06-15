using System.Collections.Generic;
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

    public float? GetFairyAttackPower(uint fid)
    {
        if (!statusTable.ContainsKey(fid))
        {
            Debug.LogError($"{fid}라는 페어리 아이디는 존재하지 않습니다.");
            return null;
        }

        return statusTable[fid].AttackPower;
    }

    public float? GetFairyAttackSpeed(uint fid)
    {
        if (!statusTable.ContainsKey(fid))
        {
            Debug.LogError($"{fid}라는 페어리 아이디는 존재하지 않습니다.");
            return null;
        }

        return statusTable[fid].AttackSpeed;
    }

    public AttackType? GetFairyAttackType(uint fid)
    {
        if (!statusTable.ContainsKey(fid))
        {
            Debug.LogError($"{fid}라는 페어리 아이디는 존재하지 않습니다.");
            return null;
        }

        return statusTable[fid].AttackType;
    }

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
}