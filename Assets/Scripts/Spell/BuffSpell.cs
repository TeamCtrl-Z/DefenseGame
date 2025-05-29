using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum BuffType
{
    AttackSpeed = 0, AttackPower, 
}
/// <summary>
/// 주변의 아군을 버프 시켜주는 스펠
/// </summary>
[CreateAssetMenu(fileName = "BuffSpell", menuName = "Spell/BuffSpell")]
public class BuffSpell : SpellBase
{
    /// <summary>
    /// 무엇을 버프 시켜줄 것인지
    /// </summary>
    public BuffType BuffType;

    /// <summary>
    /// 얼만큼 버프 시켜줄 것인지(배수)
    /// </summary>
    public float Amount;

    /// <summary>
    /// 버프를 주고 있는 페어리 리스트
    /// </summary>
    private List<IPlaceable> buffList;

    public override void Initialize(FairyController user)
    {
        base.Initialize(user);

        buffList = new();
    }

    /// <summary>
    /// 버프 받을 Fairy들 고르기
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerable<IPlaceable> GetAllNeighbors()
    {
        PlaceableObject placable = user.GetComponent<PlaceableObject>();
        List<uint> neighbors = GameManager.Instance.ContainerManager.BoatNodeContainer.GetVerticalNeighbors(placable.CurrentNodeIndex);
        foreach (var idx in neighbors)
        {
            if (GameManager.Instance.ContainerManager
                               .BoatNodeContainer
                               .TryGetFairyAt(idx, out var p))
            {
                yield return p;
            }
        }
    }
    
    public override void DoSpell(FairyController user)
    {
        List<IPlaceable> fairys = GetAllNeighbors().ToList();

        foreach (var old in buffList.Except(fairys))
        {
            if (old is MonoBehaviour mono && mono.TryGetComponent<IBuffStatus>(out IBuffStatus status))
            {
                status.BuffStop(BuffType);
            }
        }

        foreach (IPlaceable fairy in fairys.Except(buffList))
        {
            if (fairy is MonoBehaviour mono && mono.TryGetComponent<IBuffStatus>(out IBuffStatus status))
            {
                status.BuffStatus(BuffType, Amount);
            }
        }

        buffList = fairys;
    }
}