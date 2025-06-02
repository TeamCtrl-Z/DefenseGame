using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 디버프/버프 관리하는 컴포넌트
/// </summary>
public class EnemyStatusEffectComponent : MonoBehaviour, IStatusEffectProvider
{
    /// <summary>
    /// K : 디버프, V : 표식 갯수
    /// </summary>
    private readonly Dictionary<DebuffType, int> stacks = new();
    public Dictionary<DebuffType, int> Stacks => stacks;

    private void Awake()
    {
        for (int i = 0; i < (int)DebuffType.Max; i++)
        {
            stacks[(DebuffType)i] = 0;
        }
    }

    /// <summary>
    /// 디버프 표식 추가하는 함수
    /// </summary>    
    public void AddStack(DebuffType type)
    {
        if (type == DebuffType.None) return;
        int current = GetStackCount(type);
        int next = current + 1;

        stacks[type] = next;
    }

    /// <summary>
    /// 해당 디버프의 표식 갯수를 확인하는 함수
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public int GetStackCount(DebuffType type)
    {
        return stacks.TryGetValue(type, out int count) ? count : 0;
    }

    /// <summary?
    /// 해당 디버프를 가지고 있는지 확인하는 함수
    /// </summary>    
    public bool HasMark(DebuffType type)
    {
        return stacks.ContainsKey(type) && stacks[type] != 0;
    }
}