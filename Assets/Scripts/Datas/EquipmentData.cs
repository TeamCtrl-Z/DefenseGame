using System;

/// <summary>
/// 아이템 착용 정보
/// </summary>
public class EquipmentData
{
    /// <summary>
    /// 어떤 슬롯
    /// </summary>
    public uint SlotType { get; set; }

    /// <summary>
    /// 어떤 아이템
    /// </summary>
    public string IOID { get; set; } = "";

    /// <summary>
    /// 착용한 시간
    /// </summary>
    public DateTime EquippedAt { get; set; }
}