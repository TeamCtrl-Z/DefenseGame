using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 장비 타입
/// </summary>
public enum ItemType
{
    None = 0, Accessory, Weapon, Compass, Max
}

/// <summary>
/// 페어리 장비 컴포넌트
/// </summary>
public class FairyEquipComponent : MonoBehaviour
{
    /// <summary>
    /// 아이템 데이터 매니저 참조용
    /// </summary>
    private ItemDataManager itemDataMgr => DataService.Instance.ItemDataManager;

    /// <summary>
    /// 착용 정보 테이블
    /// </summary>
    private Dictionary<ItemType, string> equipTable;

    /// <summary>
    /// 읽기전용 착용한 아이템 테이블 프로퍼티
    /// </summary>
    public IReadOnlyDictionary<ItemType, string> GetEquipTable => equipTable;

    /// <summary>
    /// 페어리 소환 전 장착된 아이템 세팅(초기화)
    /// </summary>
    /// <param name="data"></param>
    public void Initialize(FairyInstanceData data)
    {
        for (int i = 0; i < (int)ItemType.Max; i++)
        {
            equipTable[(ItemType)i] = null;
        }

        equipTable = data.EquipmentsBySlot;
    }

    /// <summary>
    /// 아이템 착용 최신화 함수
    /// </summary>
    public void RefreshEquipItems()
    {
        // TODO : 착용 로직
    }
}
