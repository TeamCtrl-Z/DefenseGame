using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI관리 클래스
/// </summary>
public class UIManager : Singleton<UIManager>
{
    /// <summary>
    /// 페어리 상세 정보창
    /// </summary>
    [field : SerializeField]
    public FairyInfoUI FairyInfo {  get; private set; }

    /// <summary>
    /// 보트 운용창
    /// </summary>
    [field : SerializeField]
    public BoatOperationUI BoatOperation { get; private set; }

    /// <summary>
    /// Fade 창
    /// </summary>
    [field : SerializeField]
    public FadeUI FadeUI { get; private set; }
}
