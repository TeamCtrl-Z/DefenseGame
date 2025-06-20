using System;

/// <summary>
/// 유저 정보 클래스
/// </summary>
[Serializable]
public class UserData
{
    public ulong uid;
    public string firebaseUID;
    public string provider;
    public string playerID;
    public string lastLoginAt;
    public Currency currency;
}

public class Currency
{
    public ulong Gold { get; set; }
    public ulong Gem { get; set; }
    public uint Diamond { get; set; }
}