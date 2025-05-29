using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //Debug.DrawRay(transform.position, direction * distance, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, blockLayer);
        if (hit.collider != null)
        {
            //Debug.Log("block");
            IsBlocked = true;
        }
        else
        {
            //Debug.Log("not block");
            IsBlocked = false;
        }
    }
}
