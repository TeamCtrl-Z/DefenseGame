using System.Collections;
using System.Collections.Generic;
using AnimatorHash;
using UnityEngine;

/// <summary>
/// 페어리의 공격을 처리하는 컴포넌트
/// </summary>
public class AttackHandler : MonoBehaviour
{
    private BasicAttack basicAttack;
    // TODO : AttributeAttack 추가하기

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
        if (FairyDataManager.Instance.TryGetValue(characterIdentity.ID, out FairyStatusData statData))
        {
            basicAttack = new BasicAttack(transform, new HittingData(statData.AttackPower));
        }
    }

    public void DoAttack(Transform target)
    {
        basicAttack.DoAttack(target);
    }
}
