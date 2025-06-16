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
    private FairyStatusComponent statusComponent;
    private FairyEquipComponent equipComponent;

    protected override void Awake()
    {
        statusComponent = GetComponent<FairyStatusComponent>();
        equipComponent = GetComponent<FairyEquipComponent>();
    }

    public override float GetAttackPower() => statusComponent.RealAttackPower;

    public void Initialize(FairyInstanceData data)
    {
        statusComponent.Initialize(data);
        equipComponent.Initialize(data);
    }
}
