using System;

/// <summary>
/// 상태 이상 종류(이름 바꾸기)
/// </summary>
[Serializable]
public enum DebuffType { None = 0, Poison, Freeze, Frozen, Max}