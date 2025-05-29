using System;
using System.Collections;
using System.Collections.Generic;
using AnimatorHash;
using UnityEngine;

/// <summary>
/// 페어리의 공격을 처리하는 컴포넌트
/// </summary>
public class AttackHandler : MonoBehaviour
{
    [SerializeField] private AttackBase attack;

    /// <summary>
    /// 캐릭터 ID를 가져오는 인터페이스
    /// </summary>
    private ICharacterIdentity characterIdentity;
    private void Awake()
    {
        characterIdentity = GetComponent<ICharacterIdentity>();
    }

    private void Start()
    {
        // if (FairyDataManager.Instance.TryGetValue(characterIdentity.ID, out FairyStatusData statData))
        // {
        //     basicAttack = new BasicAttack(transform, new HittingData(statData.AttackPower));
        //     //basicAttack.OnHitEnemy += splashAttack.Execute;
        // }
        if (attack != null)
            attack.Initialize(GetComponent<FairyController>());
    }

    public void DoAttack(Transform target)
    {
        attack.DoAttack(target);
    }
}
