/// <summary>
/// 공격 타입
/// </summary>
public enum AttackType
{
    /// <summary>
    /// 공격 없음(Fairy)
    /// </summary>
    None = 0,
    
    /// <summary>
    /// 근접 공격(Enemy)
    /// </summary>
    Melee,

    /// <summary>
    /// 원거리 공격(Enemy)
    /// </summary>
    Ranged,

    /// <summary>
    /// 투사체를 이용한 공격(Fairy)
    /// </summary>
    Projectile,

    /// <summary>
    /// 이펙트를 이용한 공격(Fairy)
    /// </summary>
    Effect,
}