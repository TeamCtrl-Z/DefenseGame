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
    /// 페어리 데이터 메니저 참조용
    /// </summary>
    private FairyDataManager dataManager => DataService.Instance.FairyDataManager;

    /// <summary>
    /// 페어리 아이디 가져오기 위한 변수
    /// </summary>
    private ICharacterIdentity fid;

    /// <summary>
    /// 착용 정보 테이블
    /// </summary>
    private Dictionary<ItemType, uint> equipTable = new();

    private void Awake()
    {
        fid = GetComponent<ICharacterIdentity>();

        for (int i = 0; i < (int)ItemType.Max; i++)
        {
            equipTable[(ItemType)i] = 0;
        }

        if (dataManager.TryGetDetailStatData(fid.ID, out FairyDetailStatusData data))
        {
            foreach (string ioid in data.ItemList)
            {

            }
        }
    }

    public void DoEquip(ItemType type, uint iid)
    {

    }
}
