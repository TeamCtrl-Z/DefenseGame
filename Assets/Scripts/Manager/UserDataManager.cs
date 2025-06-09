using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using UnityEngine;

/// <summary>
/// 유저 데이터 관리 클래스
/// </summary>
public class UserDataManager : MonoBehaviour, IServerData
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
    /// 플레이어가 가지고 있는 Gold의 프로퍼티(get은 public, set은 private)
    /// </summary>
    public ulong Currency_Gold
    {
        get => User.gold;
        private set
        {
            User.gold = value;
            OnCurrencyGoldChanged?.Invoke(User.gold);
        }
    }

    /// <summary>
    /// 플레이어가 가지고 있는 Gem의 프로퍼티(get은 public, set은 private)
    /// </summary>
    public ulong Currency_Gem
    {
        get => User.gem;
        private set
        {
            User.gem = value;
            OnCurrencyGemChanged?.Invoke(User.gem);
        }
    }

    /// <summary>
    /// 플레이어가 가지고 있는 Diamond의 프로퍼티(get은 public, set은 private)
    /// </summary>
    public uint Currency_Diamond
    {
        get => User.diamond;
        private set
        {
            User.diamond = value;
            OnCurrencyDiamondChanged?.Invoke(User.diamond);
        }
    }

    private void OnDisable()
    {
        SaveToDB();
    }

    /// <summary>
    /// Gold 추가 함수
    /// </summary>
    public void AddCurrency_Gold(ulong amount)
    {
        if (amount <= 0) return;
        Currency_Gold += amount;

        SaveToDB();
    }

    /// <summary>
    /// Gold 사용(차감) 함수
    /// </summary>
    public bool ConsumeCurrency_Gold(ulong amount)
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
    public void AddCurrency_Gem(ulong amount)
    {
        if (amount <= 0) return;
        Currency_Gem += amount;

        SaveToDB();
    }

    /// <summary>
    /// Gold 사용(차감) 함수
    /// </summary>
    public bool ConsumeCurrency_Gem(ulong amount)
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

    /// <summary>
    /// 서베에서 내려온 값을 적용
    /// </summary>
    /// <param name="res"></param>
    public void ApplyServerData(JObject res)
    {
        if (res["user"] == null)
            return;

        // 처음 서버에서 데이터를 내려받았을 때
        if (User == null)
        {
            User = res["user"].ToObject<UserData>();
        }
        else
        {
            JsonConvert.PopulateObject(res["user"].ToString(), User);
        }

        Debug.Log("유저 데이터 받음");
    }

    public void LoadFromJson(string json)
    {
        User = JsonUtility.FromJson<UserData>(json);
    }

    /// <summary>
    /// DB에 현재 재화 정보를 저장하는 함수
    /// </summary>
    private void SaveToDB()
    {
    }
}
