using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

/// <summary>
/// 아이템 데이터들을 다루는 매니저 클래스
/// </summary>
public class ItemDataManager : MonoBehaviour, IServerData
{
    /// <summary>
    /// 아이템 오브젝트 데이터 테이블(서버에서 내려온 값)(key : ioid)
    /// </summary>
    private Dictionary<string, ItemObjectData> itemObjectTable;

    /// <summary>
    /// 초기화
    /// </summary>
    public void Initialize()
    {
        itemObjectTable = new();
    }

    /// <summary>
    /// 서버데이터 적용
    /// </summary>
    /// <param name="res">서버 응답(json파일)</param>
    public void ApplyServerData(JObject res)
    {
        if (res["items"] == null)
            return;

        var itemArray = res["items"] as JArray;

        foreach (var item in itemArray)
        {
            string ioid = item["ioid"].ToString();

            if (itemObjectTable.ContainsKey(ioid))
            {
                JsonConvert.PopulateObject(item.ToString(), itemObjectTable[ioid]);
            }
            else
            {
                itemObjectTable[ioid] = item.ToObject<ItemObjectData>();
            }
        }
    }

    /// <summary>
    /// 아이템 오브젝트 아이디를 통하여 아이템 오브젝트 데이터 반환해주는 함수
    /// </summary>
    /// <param name="ioid"> 아이템 오브젝트 아이디 </param>
    /// <param name="data"> 해당 아이템 오브젝트 데이터 </param>
    /// <returns> 성공 실패 </returns>
    public bool TryGetItemObjectData(string ioid, out ItemObjectData data)
    {
        data = null;

        if (itemObjectTable == null)
            return false;

        if (itemObjectTable.ContainsKey(ioid) == false)
            return false;

        data = itemObjectTable[ioid];
        return true;
    }

    /// <summary>
    /// 아이템 오브젝트 아이디를 통하여 아이템 데이터를 반환해주는 함수
    /// </summary>
    /// <param name="ioid">아이템 오브젝트 아이디</param>
    /// <param name="data">아이템 데이터</param>
    /// <returns></returns>
    public bool TryGetItemDataByIoid(string ioid, out ItemData data)
    {
        data = null;
        ItemObjectData itemObjectData = null;

        if (TryGetItemObjectData(ioid, out itemObjectData) == false)
            return false;

        return Table_Items.Instance.TryGetItemData(itemObjectData.IID, out data);
    }
}