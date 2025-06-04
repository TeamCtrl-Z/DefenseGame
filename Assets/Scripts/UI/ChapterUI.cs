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

    private void Start()
    {
        GameManager.Instance.ChapterManager.onStageChange += RefreshStage;
        GameManager.Instance.ChapterManager.onChapterChange += RefreshChapter;
        GameManager.Instance.ChapterManager.onKillCountChange += RefreshKillMonster;
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
}
