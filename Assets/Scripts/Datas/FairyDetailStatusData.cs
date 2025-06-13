using System.Collections.Generic;

/// <summary>
/// 서버에서 가져온 유저의 고유 페어리 데이터
/// </summary>
public class FairyDetailStatusData
{
    /// <summary>
    /// 페어리 아이디(종류)
    /// </summary>
    public int FID;

    /// <summary>
    /// 페어리 고유 아이디(페어리 오브젝트 아이디)
    /// </summary>
    public string FOID;

    /// <summary>
    /// 페어리 레벨
    /// </summary>
    public uint Level;

    /// <summary>
    /// 페어리 합성 레벨(별 갯수)
    /// </summary>
    public uint CompoundLevel;

    /// <summary>
    /// 페어리가 착용한 아이템 리스트(ioid)
    /// </summary>
    public List<string> ItemList;
}