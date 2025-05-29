using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightOverlay : MonoBehaviour
{
    /// <summary>
    /// 페이드 시간
    /// </summary>
    public float duration = 0.2f;

    /// <summary>
    /// Collider2D 컴포넌트
    /// </summary>
    private Collider2D cellCollider;

    /// <summary>
    /// 배치칸 알파 제어용
    /// </summary>
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// Glow(Intensity) 제어용
    /// </summary>
    private MaterialPropertyBlock propertyBlock;

    // Property ID 캐싱
    private readonly int intensityId = Shader.PropertyToID("_Intensity");

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        propertyBlock = new MaterialPropertyBlock();
        cellCollider = GetComponent<Collider2D>();

        spriteRenderer.color = new Color(1, 1, 1, 0);
        spriteRenderer.GetPropertyBlock(propertyBlock);
        propertyBlock.SetFloat(intensityId, 0f);
        spriteRenderer.SetPropertyBlock(propertyBlock);
    }

    private void Start()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0f);
        GameManager.Instance.ContainerManager.BoatNodeContainer.onDragBegin += ShowPlacementNode;
        GameManager.Instance.ContainerManager.BoatNodeContainer.onDragEnd += HidePlacementNode;
    }

    /// <summary>
    /// 배치칸을 보여주는 함수
    /// </summary>
    public void ShowPlacementNode()
    {
        cellCollider.enabled = true;
        StopCoroutine(nameof(AnimateHidePlacementNode));
        StartCoroutine(AnimateShowPlacementNode());
    }

    /// <summary>
    /// 배치칸을 숨기는 함수
    /// </summary>
    public void HidePlacementNode()
    {
        cellCollider.enabled = false;
        StopCoroutine(nameof(AnimateShowPlacementNode));
        StartCoroutine(AnimateHidePlacementNode());
    }

    /// <summary>
    /// Glow 효과를 주는 함수
    /// </summary>
    public void ForceGlowIn()
    {
        StopCoroutine(nameof(AnimateGlow));
        StartCoroutine(AnimateGlow(0f, 1.5f));
    }

    /// <summary>
    /// Glow 효과를 제거하는 함수
    /// </summary>
    public void ForceGlowOut()
    {
        StopCoroutine(nameof(AnimateGlow));
        StartCoroutine(AnimateGlow(1.5f, 0f));
    }

    /// <summary>
    /// 배치칸에 보간 작업으로 Glow 효과를 주는 코루틴
    /// </summary>
    private IEnumerator AnimateGlow(float from, float to)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float val = Mathf.Lerp(from, to, elapsed / duration);

            spriteRenderer.GetPropertyBlock(propertyBlock);
            propertyBlock.SetFloat(intensityId, val);
            spriteRenderer.SetPropertyBlock(propertyBlock);

            yield return null;
        }

        spriteRenderer.GetPropertyBlock(propertyBlock);
        propertyBlock.SetFloat(intensityId, to);
        spriteRenderer.SetPropertyBlock(propertyBlock);
    }

    /// <summary>
    /// 배치칸을 보간 작업으로 보여주는 코루틴
    /// </summary>
    private IEnumerator AnimateShowPlacementNode()
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsed / duration);
            spriteRenderer.color = new Color(1, 1, 1, alpha);
            yield return null;
        }
        spriteRenderer.color = new Color(1, 1, 1, 1f);
    }

    /// <summary>
    /// 배치칸을 보간 작업으로 숨기는 코루틴
    /// </summary>
    private IEnumerator AnimateHidePlacementNode()
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / duration);
            spriteRenderer.color = new Color(1, 1, 1, alpha);
            yield return null;
        }
        spriteRenderer.color = new Color(1, 1, 1, 0f);
    }
}