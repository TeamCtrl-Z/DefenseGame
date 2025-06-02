using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FairyStatusComponent))]
public class FairyController : RecycleObject
{
    /// <summary>
    /// Fairy의 애니메이터
    /// </summary>
    private Animator animator;

    /// <summary>
    /// Fairy의 Status
    /// </summary>
    private FairyStatusComponent fairyStatusComponent;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        fairyStatusComponent = GetComponent<FairyStatusComponent>();
    }
}
