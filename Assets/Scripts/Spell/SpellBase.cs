using UnityEngine;

public abstract class SpellBase : ScriptableObject, ISpell
{
    /// <summary>
    /// 얼만큼 간격으로 실행을 할 것인지
    /// </summary>
    public float Interval;
    protected FairyController user;
    public virtual void Initialize(FairyController user)
    {
        this.user = user;
    }

    public abstract void DoSpell(FairyController user);
}