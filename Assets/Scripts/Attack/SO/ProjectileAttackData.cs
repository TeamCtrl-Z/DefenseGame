using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileAttack", menuName = "Attack/ProjectileAttack")]
public class ProjectileAttackData : AttackData
{
    public GameObject ProjectilePrefab;
    public override AttackBase CreateAttack(FairyController owner)
    {
        return new ProjectileAttack(this, owner);
    }
}