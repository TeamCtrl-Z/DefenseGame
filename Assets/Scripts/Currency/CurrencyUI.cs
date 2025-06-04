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
        if (UserDataManager.Instance != null)
        {
            UserDataManager.Instance.OnCurrencyGoldChanged += RefreshGoldText;
            UserDataManager.Instance.OnCurrencyGemChanged += RefreshGemText;
            UserDataManager.Instance.OnCurrencyDiamondChanged += RefreshDiamondText;
        }
    }

    private void OnDisable()
    {
        if (UserDataManager.Instance != null)
        {
            UserDataManager.Instance.OnCurrencyGoldChanged -= RefreshGoldText;
            UserDataManager.Instance.OnCurrencyGemChanged -= RefreshGemText;
            UserDataManager.Instance.OnCurrencyDiamondChanged -= RefreshDiamondText;
        }
    }

    private void Start()
    {
        // 초기값 세팅
        if (UserDataManager.Instance != null)
        {
            RefreshGoldText(UserDataManager.Instance.Currency_Gold);
            RefreshGemText(UserDataManager.Instance.Currency_Gem);
            RefreshDiamondText(UserDataManager.Instance.Currency_Diamond);
        }
    }

    /// <summary>
    /// Gold 양을 갱신하는 메소드
    /// </summary>
    /// <param name="newAmount">갱신하는 양</param>
    private void RefreshGoldText(uint newAmount)
    {
        goldText.text = $"{newAmount}";
    }

    /// <summary>
    /// Gem 양을 갱신하는 메소드
    /// </summary>
    /// <param name="newAmount">갱신하는 양</param>
    private void RefreshGemText(uint newAmount)
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
