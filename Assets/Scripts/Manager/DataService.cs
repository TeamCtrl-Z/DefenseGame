using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using UnityEngine;

/// <summary>
/// 데이터 매니저들을 다루는 서비스 클래스
/// </summary>
[DefaultExecutionOrder(ExcutionOrder.Load)]
public class DataService : Singleton<DataService>
{
    /// <summary>
    /// 유저 데이터 관리자
    /// </summary>
    public UserDataManager UserDataManager { get; private set; }

    /// <summary>
    /// 페어리 데이터 관리자
    /// </summary>
    public FairyDataManager FairyDataManager { get; private set; }

    /// <summary>
    /// 적 데이터 관리자
    /// </summary>
    public EnemyDataManager EnemyDataManager { get; private set; }

    /// <summary>
    /// 방치형 컨텐츠(Chapter, Stage) 데이터 관리자
    /// </summary>
    public ContentsDataManager ContentsDataManager { get; private set; }

    /// <summary>
    /// Boat 데이터 관리자
    /// </summary>
    public BoatDataManager BoatDataManager { get; private set; }

    /// <summary>
    /// 서버 데이터를 받아서 관리해야하는 데이터 메니저 리스트
    /// </summary>
    private List<IServerData> serverDataMgrs;

    /// <summary>
    /// 각 데이터 매니저들 세팅
    /// </summary>
    protected override void OnPreInitialize()
    {
        base.OnPreInitialize();

        if (this.TryGetComponentInChildren<UserDataManager>(out UserDataManager userDataMgr))
            UserDataManager = userDataMgr;

        if (this.TryGetComponentInChildren<FairyDataManager>(out FairyDataManager fairyDataMgr))
            FairyDataManager = fairyDataMgr;

        if (this.TryGetComponentInChildren<EnemyDataManager>(out EnemyDataManager enemyDataMgr))
            EnemyDataManager = enemyDataMgr;

        if (this.TryGetComponentInChildren<ContentsDataManager>(out ContentsDataManager contentsDataMgr))
        {
            ContentsDataManager = contentsDataMgr;
            ContentsDataManager.Initialize();
        }

        if (this.TryGetComponentInChildren<BoatDataManager>(out BoatDataManager boatDataManager))
            BoatDataManager = boatDataManager;

        serverDataMgrs = GetComponentsInChildren<IServerData>().ToList();
    }

    /// <summary>
    /// 공통적으로 서버 데이터를 적용시키는 함수
    /// </summary>
    /// <param name="res"></param>
    public void ApplyCommonResponse(JObject res)
    {
        foreach (IServerData mgr in serverDataMgrs)
        {
            mgr.ApplyServerData(res);
        }
    }
}