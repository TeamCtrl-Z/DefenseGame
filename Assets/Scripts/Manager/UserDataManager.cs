using Newtonsoft.Json;
using System;
using UnityEngine;

/// <summary>
/// 유저 데이터 관리 클래스
/// </summary>
public class UserDataManager : Singleton<UserDataManager>
{
    /// <summary>
    /// 유저 데이터
    /// </summary>
    public UserData User { get; private set; }

    /// <summary>
    /// Gold가 변경되었을 때 구독자가 받는 이벤트 델리게이트
    /// </summary>
    public event Action<ulong> OnCurrencyGoldChanged;

    /// <summary>
    /// Gem가 변경되었을 때 구독자가 받는 이벤트 델리게이트
    /// </summary>
    public event Action<ulong> OnCurrencyGemChanged;

    /// <summary>
    /// Diamond가 변경되었을 때 구독자가 받는 이벤트 델리게이트
    /// </summary>
    public event Action<uint> OnCurrencyDiamondChanged;

    /// <summary>
    /// 플레이어가 가지고 있는 Gold
    /// </summary>
    private ulong currency_Gold;

    /// <summary>
    /// 플레이어가 가지고 있는 Gold의 프로퍼티(get은 public, set은 private)
    /// </summary>
    public ulong Currency_Gold
    {
        get => currency_Gold;
        private set
        {
            currency_Gold = value;
            OnCurrencyGoldChanged?.Invoke(currency_Gold);
        }
    }

    /// <summary>
    /// 플레이어가 가지고 있는 Gem
    /// </summary>
    private ulong currency_Gem;

    /// <summary>
    /// 플레이어가 가지고 있는 Gem의 프로퍼티(get은 public, set은 private)
    /// </summary>
    public ulong Currency_Gem
    {
        get => currency_Gem;
        private set
        {
            currency_Gem = value;
            OnCurrencyGemChanged?.Invoke(currency_Gem);
        }
    }

    /// <summary>
    /// 플레이어가 가지고 있는 Diamond
    /// </summary>
    private uint currency_Diamond;

    /// <summary>
    /// 플레이어가 가지고 있는 Diamond의 프로퍼티(get은 public, set은 private)
    /// </summary>
    public uint Currency_Diamond
    {
        get => currency_Diamond;
        private set
        {
            currency_Diamond = value;
            OnCurrencyDiamondChanged?.Invoke(currency_Diamond);
        }
    }

    private void OnDisable()
    {
        SaveToDB(); 
    }

    /// <summary>
    /// 재화 초기화 작업(싱글톤이 만들어질 때 단 한번만 호출)
    /// </summary>
    protected override void OnPreInitialize()
    {
        base.OnPreInitialize();
        InitializeData();
    }

    /// <summary>
    /// 재화 초기화 작업(씬이 로드 될때마다 호출, Addive제외)
    /// </summary>
    protected override void OnInitialize()
    {
        base.OnInitialize();

        // 씬 전환 시 반복해서 실행할 초기화 로직이 있으면 여기에 작성
    }

    /// <summary>
    /// 재화 초기값 세팅 (추후 DB 연동 시 이 부분을 확장하거나 교체)
    /// </summary>
    private void InitializeData()
    {
        Currency_Gold = 0;
        Currency_Gem = 0;
        Currency_Diamond = 0;

        LoadFromDB();
    }

    /// <summary>
    /// Gold 추가 함수
    /// </summary>
    public void AddCurrency_Gold(uint amount)
    {
        if (amount <= 0) return;
        Currency_Gold += amount;

        SaveToDB();
    }

    /// <summary>
    /// Gold 사용(차감) 함수
    /// </summary>
    public bool ConsumeCurrency_Gold(uint amount)
    {
        if (amount <= 0 || amount > Currency_Gold)
            return false;

        Currency_Gold -= amount;

        SaveToDB();

        return true;
    }

    /// <summary>
    /// Gold 추가 함수
    /// </summary>
    public void AddCurrency_Gem(uint amount)
    {
        if (amount <= 0) return;
        Currency_Gem += amount;

        SaveToDB();
    }

    /// <summary>
    /// Gold 사용(차감) 함수
    /// </summary>
    public bool ConsumeCurrency_Gem(uint amount)
    {
        if (amount <= 0 || amount > Currency_Gem)
            return false;

        Currency_Gem -= amount;

        SaveToDB();

        return true;
    }

    /// <summary>
    /// Gold 추가 함수
    /// </summary>
    public void AddCurrency_Diamond(uint amount)
    {
        if (amount <= 0) return;
        Currency_Diamond += amount;

        SaveToDB();
    }

    /// <summary>
    /// Gold 사용(차감) 함수
    /// </summary>
    public bool ConsumeCurrency_Diamond(uint amount)
    {
        if (amount <= 0 || amount > Currency_Diamond)
            return false;

        Currency_Diamond -= amount;

        SaveToDB();

        return true;
    }

    
    public void LoadUserData(string jsonData)
    {
        User = JsonConvert.DeserializeObject<UserData>(jsonData);
        Currency_Gold = User.gold;
        Currency_Gem = User.gem;
        Currency_Diamond = User.diamond;
    }

    public void LoadFromJson(string json)
    {
        User = JsonUtility.FromJson<UserData>(json);
    }

    /// <summary>
    /// DB에서 재화 정보를 불러오는 함수
    /// </summary>
    private void LoadFromDB()
    {
        // DB에서 불러온 값을 Currency에 할당
    }

    /// <summary>
    /// DB에 현재 재화 정보를 저장하는 함수
    /// </summary>
    private void SaveToDB()
    {
    }
}
