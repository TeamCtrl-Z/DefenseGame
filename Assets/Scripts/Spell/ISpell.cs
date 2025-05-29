using UnityEngine;

public interface ISpell
{
    /// <summary>
    /// 스킬 사용
    /// </summary>
    /// <param name="user"></param>
    public void DoSpell(FairyController user);
}