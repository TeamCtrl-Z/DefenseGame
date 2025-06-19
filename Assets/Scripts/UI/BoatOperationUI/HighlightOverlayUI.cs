using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

/// <summary>
/// 노드를 빛나게 만드는 클래스
/// </summary>
public class HighlightOverlayUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    /// <summary>
    /// Fade 시간
    /// </summary>
    [SerializeField] private float duration = 0.2f;

    /// <summary>
    /// 노드의 Material
    /// </summary>
    private Material matInstance;

    /// <summary>
    /// Material Intensity 아이디
    /// </summary>
    private static readonly int intensityId = Shader.PropertyToID("_Intensity");

    private void Awake()
    {
        matInstance = GetComponent<Image>().material;
        matInstance.SetFloat(intensityId, 0f);
    }

    /// <summary>
    /// 포인터 진입 시 글로우 인
    /// </summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (GameManager.Instance.ContainerManager.BoatNodeContainerUI.TempNode.Fairy != null)
        {
            StopCoroutine(nameof(AnimateGlow));
            StartCoroutine(AnimateGlow(0f, 1.5f));
        }
    }

    /// <summary>
    /// 포인터 이탈 시 글로우 아웃
    /// </summary>
    public void OnPointerExit(PointerEventData eventData)
    {
        if (GameManager.Instance.ContainerManager.BoatNodeContainerUI.TempNode.Fairy != null)
        {
            StopCoroutine(nameof(AnimateGlow));
            StartCoroutine(AnimateGlow(1.5f, 0f));
        }
    }

    /// <summary>
    /// 비어있는 노드에 빛을 주는 함수
    /// </summary>
    public void StartGlow()
    {
        StopCoroutine(nameof(AnimateGlow));
        StartCoroutine(AnimateGlow(0f, 1.5f));
    }

    /// <summary>
    /// 노드에 빛을 끄는 함수
    /// </summary>
    public void EndGlow()
    {
        StopCoroutine(nameof(AnimateGlow));
        StartCoroutine(AnimateGlow(1.5f, 0f));
    }

    /// <summary>
    /// 빛나게 만드는 코루틴
    /// </summary>
    /// <param name="from">시작 Intensity</param>
    /// <param name="to">끝 Intensity</param>
    private IEnumerator AnimateGlow(float from, float to)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float val = Mathf.Lerp(from, to, elapsed / duration);
            matInstance.SetFloat(intensityId, val);
            yield return null;
        }
        matInstance.SetFloat(intensityId, to);
    }
}
