using System.Collections.Generic;

/// <summary>
/// 아이템 관련 CSV 파일 로드 테이블 클래스
/// </summary>
public class Table_Items : TableClass
{
    /// <summary>
    /// 싱글톤용 instance 변수
    /// </summary>
    private static Table_Items instance;

    /// <summary>
    /// 참조하기 위한 instance 프로퍼티
    /// </summary>
    public static Table_Items Instance => instance ??= new Table_Items();

    private Dictionary<uint, ItemData> itemTable;

    public override void LoadTable()
    {
        base.LoadTable();

        itemTable = CsvLoader.LoadTable<ItemData>("table_item");
    }

    /// <summary>
    /// 아이템 아이디를 통하여 아이템 데이터 반환해주는 함수
    /// </summary>
    /// <param name="iid"> 아이템 아이디 </param>
    /// <param name="data"> 해당 아이템 데이터 </param>
    /// <returns> 성공 실패 </returns>
    public bool TryGetItemData(uint iid, out ItemData data)
    {
        data = null;

        if (itemTable == null)
            return false;

        if (itemTable.ContainsKey(iid) == false)
            return false;

        data = itemTable[iid];
        return true;
    }
}