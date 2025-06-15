using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 버튼 UI 클래스
/// </summary>
public class ButtonUI : MonoBehaviour
{
    /// <summary>
    /// 페어리 정보 버튼
    /// </summary>
    [SerializeField]
    private Button fairyInfoButton;

    /// <summary>
    /// 페어리 정보UI(나중에 UI컴포넌트로 바꾸기)
    /// </summary>
    [SerializeField]
    private CanvasGroup fairyInfoCG;

    private void Start()
    {
        fairyInfoButton.onClick.AddListener(() => { OpenFairyInfoUI(); });
    }

    /// <summary>
    /// 페어리 정보창을 여는 함수
    /// </summary>
    private void OpenFairyInfoUI()
    {
        StartCoroutine(OpenFairyInfoUICoroutine());
    }

    /// <summary>
    /// 페어리 정보창을 끄는 코루틴
    /// </summary>
    private IEnumerator OpenFairyInfoUICoroutine()
    {
        float timeElapsed = 0.0f;

        while (timeElapsed < 0.2f)
        {
            timeElapsed += Time.deltaTime;
            fairyInfoCG.alpha = timeElapsed * 5;
            yield return null;
        }

        fairyInfoCG.alpha = 1f;
        fairyInfoCG.interactable = true;
        fairyInfoCG.blocksRaycasts = true;
    }
}
