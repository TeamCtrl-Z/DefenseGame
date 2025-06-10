using UnityEngine;

/// <summary>
/// 몬스터가 피격당할 때 속성 발현
/// </summary>
public interface IOnHitEffect
{
    /// <summary>
    /// 몬스터 피격시 발동되는 함수
    /// </summary>
    /// <param name="damagable"> 피격체 </param>
    /// <param name="origin"> 피격당한 위치 </param>
    public void OnHit(IDamageableWithDebuff damagable, Vector3 origin);
}

/// <summary>
/// 페어리끼리 합성할 때 속성 발현
/// </summary>
public interface IOnMergeEffect
{
    // TODO : IMergable인터페이스 만든 후 다시 OnMerge 구현
    //void OnMerge()
}

/// <summary>
/// 일정시간 마다 속성 발현
/// </summary>
public interface IOnIntervalEffect
{
    /// <summary>
    /// Effect발동 간격
    /// </summary>
    public float Interval { get; }

    /// <summary>
    /// 일정 시간마다 실행될 함수
    /// </summary>
    public void OnInterval();
}