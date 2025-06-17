using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToastMessageUI : RecycleObject
{
    private TextMeshProUGUI messageText;
    private CanvasGroup canvasGroup;

    public void Initialize(string message, float duration)
    {
        messageText = GetComponent<TextMeshProUGUI>();
        canvasGroup = GetComponent<CanvasGroup>();

        messageText.text = message;
        StartCoroutine(FadeOut(duration));
    }

    private IEnumerator FadeOut(float duration)
    {
        yield return new WaitForSeconds(duration);
        // 점점 투명하게
        for (float t = 0; t < 0.5f; t += Time.deltaTime)
        {
            canvasGroup.alpha = 1 - (t / 0.5f);
            yield return null;
        }
        ReturnToPool();
        gameObject.SetActive(false);
    }
}
