using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 아이템 데이터 저장 클래스
/// </summary>
public class ItemData
{
    /// <summary>
    /// 아이템 아이디
    /// </summary>
    public uint IID;

    /// <summary>
    /// 아이템 타입(나침반, 악세사리, 무기)
    /// </summary>
    public ItemType ItemType;

    /// <summary>
    /// 아이템 이름
    /// </summary>
    public string Name;

    /// <summary>
    /// 아이템 설명
    /// </summary>
    public string Desc;

    /// <summary>
    /// 이미지 에셋 주소
    /// </summary>
    public string ImageAddress;

    /// <summary>
    /// 추가 공격 속도(공격 속도 빨라지게)
    /// </summary>
    public float AttackSpeedBonus;

    /// <summary>
    /// 추가 공격력
    /// </summary>
    public float AttackPowerBonus;
}
