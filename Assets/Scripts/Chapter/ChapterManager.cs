using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 챕터들을 관리하는 매니저 클래스
/// </summary>
public class ChapterManager : MonoBehaviour, IInitialize
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
    /// Kill Count가 변경되면 실행되는 이벤트 델리게이트
    /// </summary>
    public event Action<int, int> onKillCountChange;

    /// <summary>
    /// Chapter 리스트
    /// </summary>
    [Header("챕터 리스트")]
    [SerializeField] private ChapterData[] chapters;

    /// <summary>
    /// 스폰 메소드 Dictionary
    /// </summary>
    private Dictionary<SpawnType, Action<Vector2, float>> spawnMethod;

    /// <summary>
    /// 현재 Stage의 킬 카운트
    /// </summary>
    private int killCount;

    /// <summary>
    /// 현재 Stage의 킬 카운트 프로퍼티
    /// </summary>
    public int KillCount
    {
        get => killCount;
        set
        {
            killCount = value;
            onKillCountChange?.Invoke(killCount, CurrentStage.stageSpawnCount);
            if (killCount == CurrentStage.stageSpawnCount)
            {
                ClearStage();
            }
        }
    }

    /// <summary>
    /// 현재 ChapterData
    /// </summary>
    private ChapterData currentChapter;

    /// <summary>
    /// 현재 ChpaterData 프로퍼티
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
    /// 현재 StageData
    /// </summary>
    private StageData currentStage;

    /// <summary>
    /// 현재 StageData 프로퍼티
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

    /// <summary>
    /// ChapterManager를 초기화 하는 함수
    /// </summary>
    public void Initialize()
    {
        spawnMethod = new Dictionary<SpawnType, Action<Vector2, float>>
        {
            { SpawnType.Enemy000, (pos, angle) => Factory.Instance.GetEnemy_000(pos, angle) },
            { SpawnType.Enemy001, (pos, angle) => Factory.Instance.GetEnemy_001(pos, angle) },
            { SpawnType.Enemy002, (pos, angle) => Factory.Instance.GetEnemy_002(pos, angle) },
            { SpawnType.Enemy100, (pos, angle) => Factory.Instance.GetEnemy_100(pos, angle) },
            { SpawnType.Enemy101, (pos, angle) => Factory.Instance.GetEnemy_101(pos, angle) },
            { SpawnType.Enemy102, (pos, angle) => Factory.Instance.GetEnemy_102(pos, angle) },
            { SpawnType.Enemy200, (pos, angle) => Factory.Instance.GetEnemy_200(pos, angle) },
            { SpawnType.Enemy201, (pos, angle) => Factory.Instance.GetEnemy_201(pos, angle) },
            { SpawnType.Enemy202, (pos, angle) => Factory.Instance.GetEnemy_202(pos, angle) },
        };
    }

    /// <summary>
    /// 현재 스테이지를 시작하는 함수
    /// </summary>
    public void StartStage(int currentChapter, int currentStage)
    {
        CurrentChapter = chapters[currentChapter];
        CurrentStage = CurrentChapter.stages[currentStage];
        KillCount = 0;
        StartCoroutine(RunStage(chapters[currentChapter].stages[currentStage]));
    }

    /// <summary>
    /// 스테이지를 클리어하면 실행되는 함수
    /// </summary>
    public void ClearStage()
    {
        KillCount = 0;
    }

    /// <summary>
    /// 챕터를 클리어하면 실행되는 함수
    /// </summary>
    public void ClearChapter()
    {
        
    }

    /// <summary>
    /// 적을 스폰하는 함수
    /// </summary>
    /// <param name="info">스폰 정보</param>
    private void SpawnEnemy(SpawnInfo info)
    {
        spawnMethod[info.spawnType]?.Invoke(info.spawnPosition, 0);
    }

    /// <summary>
    /// 한 스테이지에서 적들을 스폰하는 코루틴
    /// </summary>
    /// <param name="stageData">스테이지 데이터</param>
    private IEnumerator RunStage(StageData stageData)
    {
        float elapsed = 0.0f;

        foreach (var info in stageData.spawnInfos)
        {
            float wait = info.spawnTime - elapsed;
            if (wait > 0.0f)
                yield return new WaitForSeconds(wait);

            SpawnEnemy(info);
            elapsed = info.spawnTime;
        }
    }
}
