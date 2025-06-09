using UnityEngine;

/// <summary>
/// 근접 공격 데이터
/// </summary>
[CreateAssetMenu(fileName = "MeleeAttack", menuName = "Attack/MeleeAttack")]
public class MeleeAttackData : EnemyAttackData
{
    /// <summary>
    /// 투사체 공격에 상요될 근접 공격 프리팹(TODO : 프리팹 ID로 바꿔야 할듯)
    /// </summary>
    public GameObject MeleePrefab;

    /// <summary>
    /// 근접 공격 클래스를 만들어주는 함수
    /// </summary>
    /// <param name="owner"></param>
    /// <returns></returns>
    public override EnemyAttack CreateAttack(EnemyController owner)
    {
        return new EnemyMeleeAttack(this, owner);
    }
}
