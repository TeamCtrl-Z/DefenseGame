using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy 보상 컴포넌트
/// </summary>
public class EnemyRewardComponent : MonoBehaviour, IReward
{
    /// <summary>
    /// Gold 양을 반환하는 프로퍼티
    /// </summary>
    public ulong Gold { get; private set; }

    /// <summary>
    /// Gem 양을 반환하는 프로퍼티
    /// </summary>
    public ulong Gem { get; private set; }

    /// <summary>
    /// Exp 양을 반환하는 프로퍼티
    /// </summary>
    public ulong Exp { get; private set; }

    /// <summary>
    /// 캐릭터의 고유 ID를 가져오는 인터페이스
    /// </summary>
    private ICharacterIdentity characterIdentity;

    private void Awake()
    {
        characterIdentity = GetComponent<ICharacterIdentity>();
    }

    private void Start()
    {
        EnemyStatusComponent statusComponent = GetComponent<EnemyStatusComponent>();
        statusComponent.OnDie += SpawnRewardPickups;

        LoadRewardData();
    }

    /// <summary>
    /// Eenemy 보상 데이터를 로드하는 메소드
    /// </summary>
    public void LoadRewardData()
    {
        EnemyDataManager.Instance.TryGetRewardData(characterIdentity.ID, out EnemyRewardData rewardData);

        Gold = rewardData.gold;
        Gem = rewardData.gem;
        Exp = rewardData.exp;
    }

    /// <summary>
    /// Enemy가 죽으면 호출되는 메소드로, 보상 픽업을 생성합니다.
    /// </summary>
    public void SpawnRewardPickups()
    {
        Factory.Instance.GetGold(transform.position, 0, Gold);
        Factory.Instance.GetGem(transform.position, 0, Gem);
    }
}
