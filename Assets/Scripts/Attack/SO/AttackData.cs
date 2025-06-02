using UnityEngine;

public abstract class AttackData : ScriptableObject
{
    public HittingData data;
    public abstract AttackBase CreateAttack(FairyController owner);
}