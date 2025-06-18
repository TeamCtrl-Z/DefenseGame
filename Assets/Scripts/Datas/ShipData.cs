using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 배 관련 데이터
/// </summary>
public class ShipData
{
    /// <summary>
    /// 배 레벨
    /// </summary>
    public uint Level;

    /// <summary>
    /// 배에 배치된 페어리 정보 리스트
    /// </summary>
    private List<ShipFairyData> assignedFairys = new();

    /// <summary>
    /// 배에 배치된 페어리 정보 프로퍼티(서버에 내려온 값을 맵으로 바꾸는 용)
    /// </summary>
    public List<ShipFairyData> AssignedFairys
    {
        get => assignedFairys;
        set
        {
            assignedFairys = value;
            AssignedFairyMap = value.ToDictionary(f => f.SlotIndex, f => f.FOID);
            OnAssignedFairy?.Invoke();
        }
    }

    /// <summary>
    /// 배에 페어리가 배치가 되면 불리는 이벤트
    /// </summary>
    public event Action OnAssignedFairy;

    /// <summary>
    /// 배에 배치된 페어리 정보 맵 형식(k : slotIndex, v : foid)
    /// </summary>
    public Dictionary<uint, string> AssignedFairyMap = new();
}