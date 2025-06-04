using UnityEngine;

/// <summary>
/// Attribute SO
/// </summary>
public abstract class AttributeBase : ScriptableObject
{
    /// <summary>
    /// 속성을 시전하는 주체
    /// </summary>
    protected GameObject user;

    /// <summary>
    /// 초기화 작업
    /// </summary>
    /// <param name="user"></param>
    public virtual void Initialize(GameObject user)
    {
        this.user = user;
    }
}