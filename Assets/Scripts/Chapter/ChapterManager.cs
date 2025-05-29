using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterManager : MonoBehaviour, IInitialize
{
    [Header("챕터 리스트")]
    [SerializeField] private ChapterData[] chapters;

    private Dictionary<SpawnType, Action<Vector2, float>> spawnMethod;

    private int currentChapter = 0;
    private int currentStage = 0;

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
    public void StartStage()
    {
        StartCoroutine(RunStage(chapters[currentChapter].stages[currentStage]));
    }

    /// <summary>
    /// 스테이지를 클리어해서 다음 스테이지로 넘어가는 함수
    /// </summary>
    public void ClearStage()
    {
        currentStage++;
    }

    /// <summary>
    /// 챕터를 클리어해서 다음 챕터로 넘어가는 함수
    /// </summary>
    public void ClearChapter()
    {
        currentChapter++;
        currentStage = 0;
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
        float elapsed = 0f;

        foreach (var info in stageData.spawnInfos)
        {
            float wait = info.spawnTime - elapsed;
            if (wait > 0f)
                yield return new WaitForSeconds(wait);

            SpawnEnemy(info);
            elapsed = info.spawnTime;
        }
    }
}
