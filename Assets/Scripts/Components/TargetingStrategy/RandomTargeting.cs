using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 무작위 타겟팅
/// </summary>
public class RandomTargeting : TargetingStrategyBase
{
    /// <summary>
    /// 적 후보군들 중 무작위로 한 명 선택하는 함수
    /// </summary>
    /// <param name="origin"> 페어리 위치 </param>
    /// <param name="enemies">적 후보군</param>
    /// <returns>선택된 적 Transform</returns>
    public override Transform SelectTarget(Transform origin, IEnumerable<ITargetable> enemies)
    {
        List<ITargetable> enemyList = new List<ITargetable>(enemies);
        if (enemyList.Count == 0) return null;

        int randomIndex = UnityEngine.Random.Range(0, enemyList.Count);
        return enemyList[randomIndex].Transform;
    }

    /// <summary>
    /// 무작위로 적들을 선택하는 함수
    /// </summary>
    /// <param name="origin">페어리 위치</param>
    /// <param name="enemies">적 후보군</param>
    /// <param name="count">몇 명</param>
    /// <returns>선택된 적 Transform List</returns>
    public override List<Transform> SelectTargets(Transform origin, IEnumerable<ITargetable> enemies, int count)
    {
        // 1) 후보 목록 생성
        List<ITargetable> enemyList = new List<ITargetable>(enemies);
        List<Transform> result = new List<Transform>();

        // 2) 적이 없는 경우 빈 리스트 반환
        if (enemyList.Count == 0 || count <= 0)
            return result;

        int n = enemyList.Count;

        // 3) 요청 개수가 전체 적 수 이상이면, 모든 적을 무작위 순으로 섞어서 반환
        if (count >= n)
        {
            // Fisher–Yates 방식으로 섞기
            for (int i = 0; i < n; i++)
            {
                int rand = UnityEngine.Random.Range(i, n);
                // swap enemyList[i]와 enemyList[rand]
                var tmp = enemyList[i];
                enemyList[i] = enemyList[rand];
                enemyList[rand] = tmp;
            }
            // 섞인 순서 그대로 Transform만 뽑기
            foreach (var e in enemyList)
                result.Add(e.Transform);

            return result;
        }

        // 4) 요청 개수가 적을 때: 부분 무작위 추출
        //    첫 count개를 뽑기 위해 Fisher–Yates의 앞부분만 수행
        for (int i = 0; i < count; i++)
        {
            int rand = UnityEngine.Random.Range(i, n);
            // swap enemyList[i]와 enemyList[rand]
            var tmp = enemyList[i];
            enemyList[i] = enemyList[rand];
            enemyList[rand] = tmp;

            result.Add(enemyList[i].Transform);
        }

        return result;
    }
}