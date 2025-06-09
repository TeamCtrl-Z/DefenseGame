using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy가 벽을 뚫지 못하도록 막아주는 컴포넌트
/// </summary>
public class EnemyBlockComponent : MonoBehaviour
{
    /// <summary>
    /// 장애물 감지 거리
    /// </summary>
    [SerializeField] private float distance;

    /// <summary>
    /// 장애물 감지 레이어
    /// </summary>
    [SerializeField] private LayerMask blockLayer;

    /// <summary>
    /// 장애물에 막혔는지
    /// </summary>
    public bool IsBlocked { get; private set; }

    private void FixedUpdate()
    {
        Vector3 direction = Vector2.left;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, blockLayer);
        if (hit.collider != null)
        {
            IsBlocked = true;
        }
        else
        {
            IsBlocked = false;
        }
    }
}
