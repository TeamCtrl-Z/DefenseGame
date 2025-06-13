using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Test용
/// </summary>
public class ChapterUI : MonoBehaviour
{
    public TextMeshProUGUI stageText;
    public TextMeshProUGUI chapterText;
    public TextMeshProUGUI killMonsterText;
    public TextMeshProUGUI clearText;

    private void Start()
    {
        DataService.Instance.ContentsDataManager.onStageChange += RefreshStage;
        DataService.Instance.ContentsDataManager.onChapterChange += RefreshChapter;
        GameManager.Instance.ChapterManager.onKillCountChange += RefreshKillMonster;
        GameManager.Instance.ChapterManager.OnStageClear += (data) => StartCoroutine(AppendClearText(data.stageName));
        GameManager.Instance.ChapterManager.OnChapterClear += (data) => StartCoroutine(AppendClearText(data.chapterName));

        RefreshStage(DataService.Instance.ContentsDataManager.CurrentStage);
        RefreshChapter(DataService.Instance.ContentsDataManager.CurrentChapter);
    }

    private void RefreshStage(StageData currentStage)
    {
        stageText.text = $"현재 스테이지 : {currentStage.stageName}";
    }

    private void RefreshChapter(ChapterData currentChapter)
    {
        chapterText.text = $"현재 챕터 : {currentChapter.chapterName}";
    }

    private void RefreshKillMonster(int killCount, int totalCount)
    {
        killMonsterText.text = $"처치 몬스터 : {killCount} / {totalCount}";
    }

    /// <summary>
    /// 클리어 UI 등장 코루틴 함수
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private IEnumerator AppendClearText(string name)
    {
        clearText.gameObject.SetActive(true);
        clearText.text = $"{name} Clear";

        // 컬러 알파 0으로 조정
        Color color = clearText.color;
        color.a = 0.0f;
        clearText.color = color;

        // fade in
        while (clearText.color.a < 0.9f)
        {
            color.a += Time.deltaTime * 2f;
            clearText.color = color;
            yield return null;
        }

        color.a = 1f;
        clearText.color = color;
        yield return new WaitForSeconds(3.0f);

        // fade out
        while (clearText.color.a > 0.1f)
        {
            color.a -= Time.deltaTime * 2f;
            clearText.color = color;
            yield return null;
        }

        clearText.gameObject.SetActive(false);
    }
}
