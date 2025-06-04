using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 디버프 표식이 없는 적들을 고르기 위한 필터링 클래스
/// </summary>
[CreateAssetMenu(fileName = "NoMarkFilter", menuName = "Targeting/Filter/NoMarkFilter")]
public class NoDebuffFilter : TargetFilterData
{
    /// <summary>
    /// 어떤 디버프 표식인지
    /// </summary>
    public DebuffType DebuffType;


    /// <summary>
    /// 해당 디버프가 있는 적들을 필터링 해주는 함수
    /// </summary>
    /// <param name="enemies"> 적 후보군들 </param>
    /// <returns> 필터링 된 적 후보군 </returns>
    public override IEnumerable<ITargetable> Filter(IEnumerable<ITargetable> enemies) => enemies.Where(e =>
    {
        IStatusEffectProvider statusEf = e.GetStatusEffectProvider();
        if (statusEf == null)
        {
            Debug.LogError($"NoMarkFilter: 대상이 IStatusEffectProvider를 구현하지 않았습니다. 대상 타입: {e.GetType()}");
            return false;
        }
        return statusEf.GetStackCount(DebuffType) == 0;
    });
}