using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CSV테이블 파일 로드용 클래스
/// </summary>
public abstract class TableClass
{
    /// <summary>
    /// 테이블 로드(게임 시작 전에 모두 로드해야 함)
    /// </summary>
    public virtual void LoadTable()
    {
        Debug.Log("테이블 로드");
    }
}