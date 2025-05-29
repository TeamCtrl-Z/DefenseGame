using UnityEngine;

public class AttackHandler2 : MonoBehaviour
{
    /// <summary>
    /// 페어리가 사용할 공격
    /// </summary>
    [SerializeReference] private IAttack attack;
    private TargetingComponent targetingComponent;

    private void Awake()
    {
        targetingComponent = GetComponent<TargetingComponent>();
    }

    
}