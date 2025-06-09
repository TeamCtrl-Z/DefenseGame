using TMPro;
using UnityEngine;

/// <summary>
/// 재화 UI 클래스
/// </summary>
public class CurrencyUI : MonoBehaviour
{
    /// <summary>
    /// Gold 양을 표시하는 UI 텍스트
    /// </summary>
    [Header("Gold UI")]
    [SerializeField] private TextMeshProUGUI goldText;

    /// <summary>
    /// Gem 양을 표시하는 UI 텍스트
    /// </summary>
    [Header("Gem UI")]
    [SerializeField] private TextMeshProUGUI gemText;

    /// <summary>
    /// Diamond 양을 표시하는 UI 텍스트
    /// </summary>
    [Header("Diamond UI")]
    [SerializeField] private TextMeshProUGUI diamondText;

    private void OnEnable()
    {
        if (DataService.Instance != null)
        {
            DataService.Instance.UserDataManager.OnCurrencyGoldChanged += RefreshGoldText;
            DataService.Instance.UserDataManager.OnCurrencyGemChanged += RefreshGemText;
            DataService.Instance.UserDataManager.OnCurrencyDiamondChanged += RefreshDiamondText;
        }
    }

    private void OnDisable()
    {
        if (DataService.Instance != null)
        {
            DataService.Instance.UserDataManager.OnCurrencyGoldChanged -= RefreshGoldText;
            DataService.Instance.UserDataManager.OnCurrencyGemChanged -= RefreshGemText;
            DataService.Instance.UserDataManager.OnCurrencyDiamondChanged -= RefreshDiamondText;
        }
    }

    private void Start()
    {
        // 초기값 세팅
        if (DataService.Instance != null)
        {
            RefreshGoldText(DataService.Instance.UserDataManager.Currency_Gold);
            RefreshGemText(DataService.Instance.UserDataManager.Currency_Gem);
            RefreshDiamondText(DataService.Instance.UserDataManager.Currency_Diamond);
        }
    }

    /// <summary>
    /// Gold 양을 갱신하는 메소드
    /// </summary>
    /// <param name="newAmount">갱신하는 양</param>
    private void RefreshGoldText(ulong newAmount)
    {
        goldText.text = $"{newAmount}";
    }

    /// <summary>
    /// Gem 양을 갱신하는 메소드
    /// </summary>
    /// <param name="newAmount">갱신하는 양</param>
    private void RefreshGemText(ulong newAmount)
    {
        gemText.text = $"{newAmount}";
    }

    /// <summary>
    /// Diamond 양을 갱신하는 메소드
    /// </summary>
    /// <param name="newAmount">갱신하는 양</param>
    private void RefreshDiamondText(uint newAmount)
    {
        diamondText.text = $"{newAmount}";
    }
}
