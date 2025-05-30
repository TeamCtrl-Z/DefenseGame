using UnityEngine;

public class NodeHoverController : MonoBehaviour
{
    /// <summary>
    /// 메인 카메라
    /// </summary>
    [Header("메인 카메라")]
    public Camera mainCam;

    /// <summary>
    /// 노드 레이어
    /// </summary>
    [Header("노드 레이어")]
    public LayerMask cellLayerMask;

    /// <summary>
    /// 마지막으로 마우스가 올려진 Collider2D
    /// </summary>
    private Collider2D lastHit;

    private void Update()
    {
        Vector2 worldPos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Collider2D hit = Physics2D.OverlapPoint(worldPos, cellLayerMask);

        if (hit != lastHit)
        {
            if (lastHit != null)
                lastHit.GetComponent<HighlightOverlay>()?.ForceGlowOut();

            if (hit != null)
                hit.GetComponent<HighlightOverlay>()?.ForceGlowIn();

            lastHit = hit;
        }
    }
}
