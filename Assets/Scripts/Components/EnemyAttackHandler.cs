using System;
using UnityEngine;

/// <summary>
/// Enemy의 공격처리를 하는 Handler 클래스
/// </summary>
public class EnemyAttackHandler : MonoBehaviour
{
    /// <summary>
    /// Enemy가 사용할 공격
    /// </summary>
    [SerializeField] private EnemyAttackData attackSO;

    /// <summary>
    /// 장애물 감지 레이어
    /// </summary>
    [SerializeField] private LayerMask blockLayer;

    /// <summary>
    /// 공격 범위
    /// </summary>
    public float AttackRange { get; private set; }

    /// <summary>
    /// 고유 공격 클래스
    /// </summary>
    public EnemyAttack Attack { get; private set; }

    /// <summary>
    /// 공격이 가능한지 알리는 프로퍼티
    /// </summary>
    public bool CanAttack { get; private set; }

    /// <summary>
    /// 공격 Transform
    /// </summary>
    public Transform Target { get; private set; }

    /// <summary>
    /// 공격을 시작할 때 알리기 위한 이벤트
    /// </summary>
    public event Action OnAttack;

    /// <summary>
    /// Enemy Status 정보 모듈
    /// </summary>
    private EnemyStatusData statData;

    private void Start()
    {
        if (attackSO == null)
        {
            Debug.LogError("AttackHandler: attackSO가 에디터에 할당되지 않았습니다.");
        }

        Attack = attackSO.CreateAttack(GetComponentInParent<EnemyController>());
        EnemyStatusComponent status = GetComponentInParent<EnemyStatusComponent>();

        if (!DataService.Instance.EnemyDataManager.TryGetStatData(status.ID, out statData))
        {
            Debug.LogError("Not Found");
            return;
        }

        AttackRange = statData.AttackRange;

        CircleCollider2D col = GetComponent<CircleCollider2D>();
        col.isTrigger = true;
        col.radius = AttackRange;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Boat"))
        {
            CanAttack = true;
            Target = other.gameObject.transform;
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
    /// 공격 하는 함수
    /// </summary>
    public void EnemyAttack()
    {
        Attack.DoAttack(Target);
        OnAttack?.Invoke();
    }
}
