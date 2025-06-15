using UnityEngine;

/// <summary>
/// 페어리 전용 풀
/// </summary>
public abstract class FairyPool : ObjectPool<FairyController>
{
    /// <summary>
    /// 기존의 GetObject 함수 숨기기 용도
    /// </summary>
    private new FairyController GetObject(Vector3? position = null, Vector3? eulerAngle = null) => null;

    /// <summary>
    /// 페어리전용 GetObject : 인스턴스 데이터를 주입 시킨 후 페어리를 소환
    /// </summary>
    /// <param name="data"> 페어리 인스턴스 데이터 </param>
    /// <param name="position"> 소환 위치 </param>
    /// <param name="eulerAngle"> 소환 각도 </param>
    /// <returns></returns>
    public FairyController GetObject(FairyInstanceData data, Vector3? position = null, Vector3? eulerAngle = null)
    {
        if (readyQueue.Count > 0)
        {
            // 아직 비활성화 된 오브젝트가 남아있다.
            FairyController fairy = readyQueue.Dequeue();          // 큐에서 하나 꺼내고
            fairy.transform.position = position.GetValueOrDefault();                      // 위치와 회전 적용
            fairy.transform.rotation = Quaternion.Euler(eulerAngle.GetValueOrDefault());

            fairy.Initialize(data);     // 페어리 인스턴스 데이터 주입
            fairy.gameObject.SetActive(true);        // 활성화 시키기
            return fairy;    // 리턴
        }
        else
        {
            // 모든 오브젝트가 활성화되어 있다. => 남아있는 오브젝트가 없다.
            ExpandPool();                           // 풀을 두배로 늘리기
            return GetObject(data, position, eulerAngle); // 새롭게 꺼내기 요청
        }
    }
}