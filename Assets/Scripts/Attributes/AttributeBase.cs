using UnityEngine;

/// <summary>
/// Attribute SO
/// </summary>
public abstract class AttributeBase
{
    /// <summary>
    /// csv파일 데이터와 연동 용 변수(참조 용도 사용X)
    /// </summary>
    [SerializeField] protected float value1;
    [SerializeField] protected float value2;
    [SerializeField] protected float value3;

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