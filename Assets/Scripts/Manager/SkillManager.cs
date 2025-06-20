using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour, IInitialize
{
    /// <summary>
    /// 스킬을 담은 큐
    /// </summary>
    private Queue<FairySkillData> skillQueue;

    /// <summary>
    /// 스킬을 실행하면 호출되는 이벤트
    /// </summary>
    public event Action<uint> OnSkillExecute;

    /// <summary>
    /// 초기화
    /// </summary>
    public void Initialize()
    {
        skillQueue = new Queue<FairySkillData>();
    }

    /// <summary>
    /// 스킬을 큐에서 뽑아내는 메서드
    /// </summary>
    private void ExtractSkillFromQueue()
    {
        if (skillQueue.Count <= 0)
            return;
        
        FairySkillData skillData = skillQueue.Dequeue();
        OnSkillExecute?.Invoke(skillData.FID);
    }
}