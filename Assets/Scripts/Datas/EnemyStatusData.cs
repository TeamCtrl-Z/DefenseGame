/// <summary>
/// 적 States 데이터 클래스
/// </summary>
public class EnemyStatusData
{
    /// <summary>
    /// 적 ID
    /// </summary>
    public int eid;

    /// <summary>
    /// 적 이동 속도
    /// </summary>
    public float MoveSpeed;

    /// <summary>
    /// 적 HP
    /// </summary>
    public float HP;

    /// <summary>
    /// 적 공격력
    /// </summary>
    public float AttackPower;

    /// <summary>
    /// 적 공격 속도
    /// </summary>
    public float AttackSpeed;

    /// <summary>
    /// 적 공격 범위
    /// </summary>
    public float AttackRange;

    /// <summary>
    /// 적 공격 유형
    /// </summary>
    public AttackType AttackType;

    /// <summary>
    /// 적 공격 아이디
    /// </summary>
    public uint AttackId;
}
