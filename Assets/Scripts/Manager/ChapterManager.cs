using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 챕터들을 관리하는 매니저 클래스
/// </summary>
public class ChapterManager : MonoBehaviour, IInitialize
{
    /// <summary>
    /// Kill Count가 변경되면 실행되는 이벤트 델리게이트
    /// </summary>
    public event Action<int, int> onKillCountChange;

    /// <summary>
    /// 스폰 메소드 Dictionary
    /// </summary>
    private Dictionary<SpawnType, Action<Vector2, float>> spawnMethod;

    /// <summary>
    /// 스테이지가 클리어되면 실행되는 이벤트
    /// </summary>
    public event Action<StageData> OnStageClear;

    /// <summary>
    /// 챕터가 클리어되면 실행되는 이벤트
    /// </summary>
    public event Action<ChapterData> OnChapterClear;

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
            onKillCountChange?.Invoke(killCount, currentStage.stageSpawnCount);
            if (killCount == currentStage.stageSpawnCount)
            {
                StartCoroutine(ClearStage());
            }
        }
    }

    /// <summary>
    /// 현재 챕터 getter
    /// </summary>
    private ChapterData currentChapter => dataManager.CurrentChapter;

    /// <summary>
    /// 현재 스테이지 getter
    /// </summary>
    private StageData currentStage => dataManager.CurrentStage;

    /// <summary>
    /// 컨텐츠 데이터 매니저(ChapterData, StageData 참조용)
    /// </summary>
    private ContentsDataManager dataManager => DataService.Instance.ContentsDataManager;
    
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
            { SpawnType.Enemy003, (pos, angle) => Factory.Instance.GetEnemy_003(pos, angle) },
            { SpawnType.Enemy004, (pos, angle) => Factory.Instance.GetEnemy_004(pos, angle) },
            { SpawnType.Enemy005, (pos, angle) => Factory.Instance.GetEnemy_005(pos, angle) },
            { SpawnType.Enemy006, (pos, angle) => Factory.Instance.GetEnemy_006(pos, angle) },
            { SpawnType.Enemy007, (pos, angle) => Factory.Instance.GetEnemy_007(pos, angle) },
            { SpawnType.Enemy008, (pos, angle) => Factory.Instance.GetEnemy_008(pos, angle) },
            { SpawnType.Enemy009, (pos, angle) => Factory.Instance.GetEnemy_009(pos, angle) },
            { SpawnType.Enemy010, (pos, angle) => Factory.Instance.GetEnemy_010(pos, angle) },
            { SpawnType.Enemy011, (pos, angle) => Factory.Instance.GetEnemy_011(pos, angle) },
            { SpawnType.Enemy012, (pos, angle) => Factory.Instance.GetEnemy_012(pos, angle) },
            { SpawnType.Enemy013, (pos, angle) => Factory.Instance.GetEnemy_013(pos, angle) },
            { SpawnType.Enemy014, (pos, angle) => Factory.Instance.GetEnemy_014(pos, angle) },
            { SpawnType.Enemy015, (pos, angle) => Factory.Instance.GetEnemy_015(pos, angle) },
            { SpawnType.Enemy016, (pos, angle) => Factory.Instance.GetEnemy_016(pos, angle) },
            { SpawnType.Enemy017, (pos, angle) => Factory.Instance.GetEnemy_017(pos, angle) },
            { SpawnType.Enemy018, (pos, angle) => Factory.Instance.GetEnemy_018(pos, angle) },
            { SpawnType.Enemy019, (pos, angle) => Factory.Instance.GetEnemy_019(pos, angle) },
            { SpawnType.Enemy020, (pos, angle) => Factory.Instance.GetEnemy_020(pos, angle) },
            { SpawnType.Enemy021, (pos, angle) => Factory.Instance.GetEnemy_021(pos, angle) },
            { SpawnType.Enemy022, (pos, angle) => Factory.Instance.GetEnemy_022(pos, angle) },
            { SpawnType.Enemy023, (pos, angle) => Factory.Instance.GetEnemy_023(pos, angle) },
            { SpawnType.Enemy024, (pos, angle) => Factory.Instance.GetEnemy_024(pos, angle) },
            { SpawnType.Enemy025, (pos, angle) => Factory.Instance.GetEnemy_025(pos, angle) },
            { SpawnType.Enemy026, (pos, angle) => Factory.Instance.GetEnemy_026(pos, angle) },
            { SpawnType.Enemy027, (pos, angle) => Factory.Instance.GetEnemy_027(pos, angle) },
            { SpawnType.Enemy028, (pos, angle) => Factory.Instance.GetEnemy_028(pos, angle) },
            { SpawnType.Enemy029, (pos, angle) => Factory.Instance.GetEnemy_029(pos, angle) },
            { SpawnType.Enemy030, (pos, angle) => Factory.Instance.GetEnemy_030(pos, angle) },
            { SpawnType.Enemy031, (pos, angle) => Factory.Instance.GetEnemy_031(pos, angle) },
            { SpawnType.Enemy100, (pos, angle) => Factory.Instance.GetEnemy_100(pos, angle) },
            { SpawnType.Enemy101, (pos, angle) => Factory.Instance.GetEnemy_101(pos, angle) },
            { SpawnType.Enemy102, (pos, angle) => Factory.Instance.GetEnemy_102(pos, angle) },
            { SpawnType.Enemy103, (pos, angle) => Factory.Instance.GetEnemy_103(pos, angle) },
            { SpawnType.Enemy104, (pos, angle) => Factory.Instance.GetEnemy_104(pos, angle) },
            { SpawnType.Enemy105, (pos, angle) => Factory.Instance.GetEnemy_105(pos, angle) },
            { SpawnType.Enemy200, (pos, angle) => Factory.Instance.GetEnemy_200(pos, angle) },
            { SpawnType.Enemy201, (pos, angle) => Factory.Instance.GetEnemy_201(pos, angle) },
            { SpawnType.Enemy202, (pos, angle) => Factory.Instance.GetEnemy_202(pos, angle) },
            { SpawnType.Enemy203, (pos, angle) => Factory.Instance.GetEnemy_203(pos, angle) },
            { SpawnType.Enemy204, (pos, angle) => Factory.Instance.GetEnemy_204(pos, angle) },
            { SpawnType.Enemy205, (pos, angle) => Factory.Instance.GetEnemy_205(pos, angle) },
            { SpawnType.Enemy206, (pos, angle) => Factory.Instance.GetEnemy_206(pos, angle) },
            { SpawnType.Enemy207, (pos, angle) => Factory.Instance.GetEnemy_207(pos, angle) },
            { SpawnType.Enemy208, (pos, angle) => Factory.Instance.GetEnemy_208(pos, angle) },
            { SpawnType.Enemy209, (pos, angle) => Factory.Instance.GetEnemy_209(pos, angle) },
            { SpawnType.Enemy210, (pos, angle) => Factory.Instance.GetEnemy_210(pos, angle) },
            { SpawnType.Enemy211, (pos, angle) => Factory.Instance.GetEnemy_211(pos, angle) },
        };
    }

    /// <summary>
    /// 원하는 스테이지를 시작하는 함수
    /// </summary>
    public void StartStage(uint chapterId, uint stageId)
    {
        dataManager.SetChapter(chapterId);
        dataManager.SetStage(stageId);
        KillCount = 0;
        StartCoroutine(RunStage(dataManager.CurrentStage));
    }

    /// <summary>
    /// 현재 스테이지를 시작하는 함수
    /// </summary>
    public void StartCurrentStage()
    {
        KillCount = 0;
        StartCoroutine(RunStage(dataManager.CurrentStage));
    }

    /// <summary>
    /// 스테이지를 클리어하면 실행되는 함수
    /// </summary>
    public IEnumerator ClearStage()
    {
        if (!currentStage.isClear)
        {
            Debug.Log("StageClear요청 준비");

            DataService.Instance.UserDataManager.AddCurrency_Gold(currentStage.reward_Gold);
            DataService.Instance.UserDataManager.AddCurrency_Gem(currentStage.reward_Gem);

            yield return new WaitForSeconds(0.5f);

            void fail()
            {
                Debug.LogWarning("스테이지 보상 받기 실패");
            }

            void success()
            {
                Debug.Log("스테이지 보상 받기 성공");
                currentStage.isClear = true;
                OnStageClear?.Invoke(currentStage);
                DataService.Instance.ContentsDataManager.NextStage();
            }

            yield return ServerData_Contents.Instance.RequestStageClear(success, fail);

            if (currentChapter.stages[currentChapter.stages.Length - 1] == currentStage)
            {
                yield return ClearChapter();
            }
        }
    }

    /// <summary>
    /// 챕터를 클리어하면 실행되는 함수
    /// </summary>
    public IEnumerator ClearChapter()
    {
        if (!currentChapter.isClear)
        {
            DataService.Instance.UserDataManager.AddCurrency_Gold(currentChapter.reward_Gold);
            DataService.Instance.UserDataManager.AddCurrency_Gem(currentChapter.reward_Gem);            

            void fail()
            {
                Debug.LogWarning("챕터 보상 받기 실패");
            }

            void success()
            {
                Debug.Log("챕터 보상 받기 성공");
                currentChapter.isClear = true;
                OnChapterClear?.Invoke(currentChapter);
                DataService.Instance.ContentsDataManager.NextStage();
            }

            yield return ServerData_Contents.Instance.RequestChapterClear(success, fail);
        }

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
