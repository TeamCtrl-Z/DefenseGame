using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class ContentsDataManager : MonoBehaviour, IServerData
{
    /// <summary>
    /// Chapter가 변경되면 실행되는 이벤트 델리게이트
    /// </summary>
    public event Action<ChapterData> onChapterChange;

    /// <summary>
    /// Stage가 변경되면 실행되는 이벤트 델리게이트
    /// </summary>
    public event Action<StageData> onStageChange;

    /// <summary>
    /// 챕터 리스트
    /// </summary>
    [Header("챕터 리스트")]
    [SerializeField] private ChapterData[] chapters;

    /// <summary>
    /// 챕터 테이블
    /// </summary>
    private Dictionary<uint, ChapterData> chapterTable;

    /// <summary>
    /// 스테이지 테이블
    /// </summary>
    private Dictionary<uint, StageData> stageTable;

    /// <summary>
    /// 현재 진행중인 챕터
    /// </summary>
    private ChapterData currentChapter;

    /// <summary>
    /// 현재 진행중인 챕터 프로퍼티
    /// </summary>
    public ChapterData CurrentChapter
    {
        get => currentChapter;
        private set
        {
            if (value != currentChapter)
            {
                currentChapter = value;
                onChapterChange?.Invoke(currentChapter);
            }
        }
    }

    /// <summary>
    /// 현재 진행중인 스테이지
    /// </summary>
    private StageData currentStage;
    
    /// <summary>
    /// 현재 진행중인 스테이지 프로퍼티
    /// </summary>
    public StageData CurrentStage
    {
        get => currentStage;
        private set
        {
            if (value != currentStage)
            {
                currentStage = value;
                onStageChange?.Invoke(currentStage);
            }
        }
    }

    public void Initialize()
    {
        chapterTable = chapters.ToDictionary(c => c.ChapterID);
        stageTable = chapters.SelectMany(c => c.stages).ToDictionary(s => s.StageID);

        CurrentChapter = chapters.FirstOrDefault()
            ?? throw new InvalidOperationException("No ChapterData found.");
        CurrentStage = CurrentChapter.stages.FirstOrDefault()
            ?? throw new InvalidOperationException($"No StageData in Chapter {CurrentChapter.ChapterID}.");
    }

    public void ApplyServerData(JObject res)
    {
        if (res["contents"] == null)
            return;

        // 완료된 스테이지 아이디 추출
        uint completedChapterId = res["contents"]["chapterId"]?.Value<uint>() ?? CurrentChapter.ChapterID;
        uint completedStageId = res["contents"]["stageId"]?.Value<uint>() ?? CurrentStage.StageID;

        SetChapter(completedChapterId);
        SetStage(completedStageId);

        NextStage();
    }

    public void SetChapter(uint chapterId)
    {
        if (chapterTable.TryGetValue(chapterId, out var chapter))
        {
            Debug.Log("SetChapter : " + chapterId);
            CurrentChapter = chapter;
            // 새 챕터의 첫 스테이지로 초기화
            CurrentStage = chapter.stages.First();
        }
        else
        {
            Debug.Log("SetChapter : Strange");
            Debug.LogWarning($"[ContentsDataManager] ChapterID {chapterId} not found.");
        }
    }

    public void SetStage(uint stageId)
    {
        if (stageTable.TryGetValue(stageId, out var stage))
        {
            // 챕터와 다른 소속이면 챕터부터 변경
            if (stage.ParentChapterID != CurrentChapter.ChapterID)
                SetChapter(stage.ParentChapterID);

            CurrentStage = stage;
        }
        else
        {
            Debug.LogWarning($"[ContentsDataManager] StageID {stageId} not found.");
        }
    }

    /// <summary>
    /// 다음 스테이지로 올려주는 함수
    /// </summary>
    public void NextStage()
    {
        var stages = CurrentChapter.stages;
        int idx = Array.IndexOf(stages, CurrentStage);

        if (idx < stages.Length - 1)
            SetStage(stages[idx + 1].StageID);
        else
            NextChapter();
    }

    /// <summary>
    /// 다음 챕터로 올려주는 함수
    /// </summary>
    public void NextChapter()
    {
        int idx = Array.IndexOf(chapters, CurrentChapter);

        if (idx < chapters.Length - 1)
            SetChapter(chapters[idx + 1].ChapterID);
        else
            Debug.Log("[ContentsDataManager] Already at last chapter.");
    }
}
