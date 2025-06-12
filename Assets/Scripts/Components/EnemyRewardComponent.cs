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
        DataService.Instance.EnemyDataManager.TryGetRewardData(characterIdentity.ID, out EnemyRewardData rewardData);

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
    
    /// <summary>
    /// 플레이어 데이터 매니저에 맞는 재화를 실제로 추가하는 함수
    /// </summary>
    private void ApplyCurrencyToPlayer(CurrencyType currencyType, ulong amount)
    {
        switch (currencyType)
        {
            case CurrencyType.Gold:
                DataService.Instance.UserDataManager.AddCurrency_Gold(amount);
                break;
            case CurrencyType.Gem:
                DataService.Instance.UserDataManager.AddCurrency_Gem(amount);
                break;
            case CurrencyType.Diamond:
                DataService.Instance.UserDataManager.AddCurrency_Diamond((uint)amount);
                break;
        }
    }
}
