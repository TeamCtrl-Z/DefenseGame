using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 페어리를 제어하는 중앙 체계 클래스 
/// </summary>
[RequireComponent(typeof(FairyStatusComponent))]
public class FairyController : EntityController
{
    /// <summary>
    /// Fairy의 애니메이터
    /// </summary>
    private Animator animator;

    /// <summary>
    /// Fairy의 Status
    /// </summary>
    private FairyStatusComponent fairyStatusComponent;


    protected override void Awake()
    {
        animator = GetComponent<Animator>();
        fairyStatusComponent = GetComponent<FairyStatusComponent>();
    }
}
