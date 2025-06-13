using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class ItemDataManager : MonoBehaviour, IServerData
{
    /// <summary>
    /// 아이템 데이터 테이블(CSV파일)
    /// </summary>
    private Dictionary<int, ItemData> itemTable;

    public void Initialize()
    {
        
    }

    public void ApplyServerData(JObject res)
    {
        if (res["item"] == null)
            return;
    
        
    }
}