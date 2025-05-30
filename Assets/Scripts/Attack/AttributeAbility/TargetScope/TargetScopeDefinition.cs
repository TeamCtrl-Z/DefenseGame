using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TargetScopeDefinition", menuName = "Abilities/TargetScopeDefinition")]
public class TargetScopeDefinition : ScriptableObject, ITargetScopeStrategy
{
    /// <summary>
    /// 대상을 지정할 범위
    /// </summary>
    public float Radius;

    /// <summary>
    /// 대상 레이어
    /// </summary>
    public LayerMask layerMask;

    /// <summary>
    /// 최대 몇명 까지
    /// </summary>
    public int MaxCount;

    /// <summary>
    /// 자신을 제외 시킬지
    /// </summary>
    public bool WithoutSelf;


    public IEnumerable<GameObject> SelectTargets(GameObject origin)
    {
        var cols = Physics2D.OverlapCircleAll(origin.transform.position, Radius, layerMask);

        foreach (var col in cols)
        {
            if (MaxCount <= 0)
                break;

            if (WithoutSelf == true && col.gameObject == origin)
                continue;

            yield return col.gameObject;
        }
    }
}