using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 화면 전환하는 UI
/// </summary>
public class FadeUI : MonoBehaviour
{
    /// <summary>
    /// 화면이 전환되는 시간
    /// </summary>
    [SerializeField]
    private float fadeDuration = 0.2f;

    /// <summary>
    /// FadeUI의 Panel
    /// </summary>
    private Image fadePanel;

    private void Awake()
    {
        fadePanel = GetComponent<Image>();
    }

    /// <summary>
    /// Fade 효과 실행 후 콜백 함수 실행
    /// </summary>
    public void Fade(Action onFadeEarlyAction, Action onFadeMiddleAction, Action onFadeLastAction)
    {
        StartCoroutine(FadeCoroutine(onFadeEarlyAction, onFadeMiddleAction, onFadeLastAction));
    }

    /// <summary>
    /// 화면 전환 할때 실행되는 델리게이트
    /// </summary>
    /// <param name="midAction">전환중 실행되는 이벤트</param>
    private IEnumerator FadeCoroutine(Action earlyAction, Action midAction, Action lastAction)
    {
        earlyAction?.Invoke();
        float time = 0f;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Clamp01(time / fadeDuration);
            fadePanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        fadePanel.color = Color.black;

        midAction?.Invoke();
        yield return null;

        time = 0f;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = 1f - Mathf.Clamp01(time / fadeDuration);
            fadePanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        fadePanel.color = Color.clear;
        lastAction?.Invoke();
    }
}
