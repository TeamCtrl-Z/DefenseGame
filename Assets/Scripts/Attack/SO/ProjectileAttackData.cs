using UnityEngine;

/// <summary>
/// 투사체 공격에 필요한 데이터를 저장하기 위한 ScriptableObject
/// </summary>
[CreateAssetMenu(fileName = "ProjectileAttack", menuName = "Attack/ProjectileAttack")]
public class ProjectileAttackData : AttackData
{
    /// <summary>
    /// 투사체 공격에 상요될 투사체 프리팹(TODO : 프리팹 ID로 바꿔야 할듯)
    /// </summary>
    public GameObject ProjectilePrefab;

    /// <summary>
    /// 투사체 공격 클래스를 만들어주는 함수
    /// </summary>
    /// <param name="owner"></param>
    /// <returns></returns>
    public override AttackBase CreateAttack(FairyController owner)
    {
        return new ProjectileAttack(this, owner);
    }
}