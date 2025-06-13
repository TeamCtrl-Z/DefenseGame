/// <summary>
/// 아이템 고유 정보(서버에서 관리)
/// </summary>
public class ItemObjectData
{
    /// <summary>
    /// 아이템 아이디
    /// </summary>
    public uint IID;

    /// <summary>
    /// 아이템 오브젝트 아이디
    /// </summary>
    public string IOID;

    /// <summary>
    /// 장착한 페어리 오브젝트 아이디(없으면 null)
    /// </summary>
    public string FOID;

    // TODO : 강화 정도

    // TODO : 실제 데이터
}