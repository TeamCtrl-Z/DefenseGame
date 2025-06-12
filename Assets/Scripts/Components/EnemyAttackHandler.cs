using System;
using UnityEngine;

/// <summary>
/// Enemy의 공격처리를 하는 Handler 클래스
/// </summary>
public class EnemyAttackHandler : MonoBehaviour
{
    /// <summary>
    /// 고유 공격 클래스
    /// </summary>
    private AttackBase attack;

    /// <summary>
    /// 장애물 감지 레이어
    /// </summary>
    [SerializeField] private LayerMask blockLayer;

    /// <summary>
    /// 공격 범위
    /// </summary>
    public float AttackRange { get; private set; }

    /// <summary>
    /// 공격이 가능한지 알리는 프로퍼티
    /// </summary>
    public bool CanAttack { get; private set; }

    /// <summary>
    /// 공격 Transform
    /// </summary>
    [field: SerializeField]
    public Transform Target { get; private set; }

    /// <summary>
    /// 공격을 시작할 때 알리기 위한 이벤트
    /// </summary>
    public event Action OnAttack;

    /// <summary>
    /// 공격속도와 공격력을 알아내기 위한 변수
    /// </summary>
    private EnemyStatusComponent status;

    private void Start()
    {
        status = GetComponentInParent<EnemyStatusComponent>();
        AttackRange = status.AttackRange;
        CircleCollider2D collider = GetComponent<CircleCollider2D>();
        collider.radius = AttackRange;
        BuildAttack();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Boat"))
        {
            CanAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == blockLayer)
        {
            CanAttack = false;
        }
    }

    /// <summary>
    /// 적 공격을 만드는 함수
    /// </summary>
    private void BuildAttack()
    {
        HittingData data = new HittingData();
        data.Damage = status.AttackPower;
        Debug.Log($"{transform.parent.name} : 어택 파워 {data.Damage}");

        attack = status.AttackType switch
        {
            AttackType.Melee => new MeleeAttack(data, GetComponentInParent<EnemyController>(), status.AttackId),
            AttackType.Ranged => new RangedAttack(data, GetComponentInParent<EnemyController>(), status.AttackId),
            _ => null
        };

        if (attack == null)
            Debug.LogError($"{transform.parent.name} : {status.AttackType}은 존재하지 않습니다.");
    }

    /// <summary>
    /// 공격 하는 함수
    /// </summary>
    public void DoAttack()
    {
        attack.DoAttack(Target);
        OnAttack?.Invoke();
    }
}
