using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 재화(골드/젬/다이아몬드) 드랍 클래스
/// </summary>
public class CurrencyDrop : RecycleObject
{
    /// <summary>
    /// 재화 종류
    /// </summary>
    [Header("재화 종류")]
    [SerializeField] private CurrencyType currencyType = CurrencyType.Gold;

    /// <summary>
    /// 드랍되는 재화 양
    /// </summary>
    private ulong amount = 1;

    /// <summary>
    /// 오브젝트가 사라지기까지 시간
    /// </summary>
    [SerializeField] private float disableTime = 3.5f;

    /// <summary>
    /// 오브젝트가 사라지는 시간
    /// </summary>
    [SerializeField] private float fadeTime = 1f;

    /// <summary>
    /// SpriteRenderer 컴포넌트 캐시
    /// </summary>
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// 재화 메소드 Dictionary
    /// </summary>
    private Dictionary<CurrencyType, Action<Vector2, float>> currencyMethod;

    protected override void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// RecycleObject 풀에서 활성화될 때 호출되는 메서드
    /// </summary>
    protected override void OnReset()
    {
        base.OnReset();

        currencyMethod = new Dictionary<CurrencyType, Action<Vector2, float>>
        {
            { CurrencyType.Gold, (pos, angle) => Factory.Instance.GetGoldSparkle(pos, angle) },
            { CurrencyType.Gem, (pos, angle) => Factory.Instance.GetGemSparkle(pos, angle) },
            { CurrencyType.Diamond, (pos, angle) => Factory.Instance.GetDiamondSparkle(pos, angle) }
        };

        if (spriteRenderer != null)
        {
            Color c = spriteRenderer.color;
            c.a = 1f;
            spriteRenderer.color = c;
        }

        StartCoroutine(FadeOutAndAutoCollect());
    }

    /// <summary>
    /// 외부(몬스터)에서 드랍 타입과 양을 세팅해 주는 메서드
    /// </summary>
    public void SetDropInfo(ulong dropAmount)
    {
        amount = dropAmount;
    }

    /// <summary>
    /// 일정 시간(waitTime) 동안 알파값을 서서히 0으로 만들고, 마지막에 플레이어에게 자동으로 흡수시킨 뒤 비활성화한다.
    /// </summary>
    private IEnumerator FadeOutAndAutoCollect()
    {
        float elapsed = 0f;

        yield return new WaitForSeconds(disableTime);

        while (elapsed < fadeTime)
        {
            elapsed += Time.deltaTime;
            float time = Mathf.Clamp01(elapsed / fadeTime);

            if (spriteRenderer != null)
            {
                Color color = spriteRenderer.color;
                color.a = Mathf.Lerp(1f, 0f, time);
                spriteRenderer.color = color;
            }

            yield return null;
        }

        //ApplyCurrencyToPlayer();
        ReturnToPool();
    }

    /// <summary>
    /// 플레이어 데이터 매니저에 맞는 재화를 실제로 추가하는 함수
    /// </summary>
    private void ApplyCurrencyToPlayer()
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

    /// <summary>
    /// RecycleObject가 제공하는, 오브젝트를 다시 풀로 반환하는 헬퍼 메서드
    /// </summary>
    public override void ReturnToPool()
    {
        currencyMethod[currencyType]?.Invoke(transform.position, 0f);
        gameObject.SetActive(false);
    }
}