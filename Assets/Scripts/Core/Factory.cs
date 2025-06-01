using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Factory : Singleton<Factory>
{
    /// <summary>
    /// Enemy 풀
    /// </summary>
    private Enemy_000Pool enemy_000;

    /// <summary>
    /// Enemy 풀
    /// </summary>
    private Enemy_001Pool enemy_001;

    /// <summary>
    /// Enemy 풀
    /// </summary>
    private Enemy_002Pool enemy_002;

    /// <summary>
    /// Enemy 풀
    /// </summary>
    private Enemy_100Pool enemy_100;

    /// <summary>
    /// Enemy 풀
    /// </summary>
    private Enemy_101Pool enemy_101;

    /// <summary>
    /// Enemy 풀
    /// </summary>
    private Enemy_102Pool enemy_102;

    /// <summary>
    /// Enemy 풀
    /// </summary>
    private Enemy_200Pool enemy_200;

    /// <summary>
    /// Enemy 풀
    /// </summary>
    private Enemy_201Pool enemy_201;

    /// <summary>
    /// Enemy 풀
    /// </summary>
    private Enemy_202Pool enemy_202;

    /// <summary>
    /// Projectile 풀
    /// </summary>
    private ProjectilePool projectile;

    /// <summary>
    /// Fairy 풀
    /// </summary>
    private FairyBasicPool fairyBasic;

    private FairyFirePool fairyFire;
    private FairyPoisonPool fairyPoison;
    private FairyLightPool fairyLight;
    private FairyFreezePool fairyFreeze;

    private MarkerPool marker;

    /// <summary>
    /// 초기화 함수
    /// </summary>
    protected override void OnInitialize()
    {
        if (this.TryGetComponentInChildren<Enemy_000Pool>(out enemy_000))
            enemy_000.Initialize();

        if (this.TryGetComponentInChildren<Enemy_001Pool>(out enemy_001))
            enemy_001.Initialize();

        if (this.TryGetComponentInChildren<Enemy_002Pool>(out enemy_002))
            enemy_002.Initialize();

        if (this.TryGetComponentInChildren<Enemy_100Pool>(out enemy_100))
            enemy_100.Initialize();

        if (this.TryGetComponentInChildren<Enemy_101Pool>(out enemy_101))
            enemy_101.Initialize();

        if (this.TryGetComponentInChildren<Enemy_102Pool>(out enemy_102))
            enemy_102.Initialize();

        if (this.TryGetComponentInChildren<Enemy_200Pool>(out enemy_200))
            enemy_200.Initialize();

        if (this.TryGetComponentInChildren<Enemy_201Pool>(out enemy_201))
            enemy_201.Initialize();

        if (this.TryGetComponentInChildren<Enemy_202Pool>(out enemy_202))
            enemy_202.Initialize();

        if (this.TryGetComponentInChildren<ProjectilePool>(out projectile))
            projectile.Initialize();

        if (this.TryGetComponentInChildren<FairyBasicPool>(out fairyBasic))
            fairyBasic.Initialize();

        if (this.TryGetComponentInChildren<FairyFirePool>(out fairyFire))
            fairyFire.Initialize();

        if (this.TryGetComponentInChildren<FairyPoisonPool>(out fairyPoison))
            fairyPoison.Initialize();

        if (this.TryGetComponentInChildren<FairyLightPool>(out fairyLight))
            fairyLight.Initialize();

        if (this.TryGetComponentInChildren<FairyFreezePool>(out fairyFreeze))
            fairyFreeze.Initialize();

        if (this.TryGetComponentInChildren<MarkerPool>(out marker))
            marker.Initialize();
    }

    /// <summary>
    /// 캐릭터를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="eulerAngles">소환 각도</param>
    /// <returns>소환한 캐릭터</returns>
    public EnemyController GetEnemy_000(Vector2 position, float angle = 0.0f)
    {
        return enemy_000.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// 캐릭터를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="eulerAngles">소환 각도</param>
    /// <returns>소환한 캐릭터</returns>
    public EnemyController GetEnemy_001(Vector2 position, float angle = 0.0f)
    {
        return enemy_001.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// 캐릭터를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="eulerAngles">소환 각도</param>
    /// <returns>소환한 캐릭터</returns>
    public EnemyController GetEnemy_002(Vector2 position, float angle = 0.0f)
    {
        return enemy_002.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// 캐릭터를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="eulerAngles">소환 각도</param>
    /// <returns>소환한 캐릭터</returns>
    public EnemyController GetEnemy_100(Vector2 position, float angle = 0.0f)
    {
        return enemy_100.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// 캐릭터를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="eulerAngles">소환 각도</param>
    /// <returns>소환한 캐릭터</returns>
    public EnemyController GetEnemy_101(Vector2 position, float angle = 0.0f)
    {
        return enemy_101.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// 캐릭터를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="eulerAngles">소환 각도</param>
    /// <returns>소환한 캐릭터</returns>
    public EnemyController GetEnemy_102(Vector2 position, float angle = 0.0f)
    {
        return enemy_102.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// 캐릭터를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="eulerAngles">소환 각도</param>
    /// <returns>소환한 캐릭터</returns>
    public EnemyController GetEnemy_200(Vector2 position, float angle = 0.0f)
    {
        return enemy_200.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// 캐릭터를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="eulerAngles">소환 각도</param>
    /// <returns>소환한 캐릭터</returns>
    public EnemyController GetEnemy_201(Vector2 position, float angle = 0.0f)
    {
        return enemy_201.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// 캐릭터를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="eulerAngles">소환 각도</param>
    /// <returns>소환한 캐릭터</returns>
    public EnemyController GetEnemy_202(Vector2 position, float angle = 0.0f)
    {
        return enemy_202.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Projectile을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="eulerAngles">소환 각도</param>
    /// <returns>소환한 Projectile</returns>
    public Projectile GetProjectile(Vector2 position, float angle = 0.0f)
    {
        return projectile.GetObject(position, new Vector3(0, 0, angle));
    }

    public FairyController GetFariyByType(FairyType type, Vector2 position, float angle = 0.0f)
    {
        // switch (type)
        // {
        //     ("fairy" + type.ToString()).GetObject
        //     case FairyType.Basic: return fairyBasic.GetObject(position, new Vector3(0, 0, angle));
        // case FairyType.Fire: return fairyFire.GetObject(position, new Vector3(0, 0, angle));
        // case FairyType.Poison: return fairyPoison.GetObject(position, new Vector3(0, 0, angle));
        // }
        string fieldName = "fairy" + type.ToString();
        FieldInfo fi = this.GetType().GetField(fieldName, BindingFlags.NonPublic);

        if (fi == null)
            return null;

        object target = fi.GetValue(this);

        if (target is ObjectPool<FairyController> ob)
        {
            return ob.GetObject(position, new Vector3(0, 0, angle));
        }

        return null;
    }

    public FairyController GetFairyBasic(Vector2 position, float angle = 0.0f)
    {
        return fairyBasic.GetObject(position, new Vector3(0, 0, angle));
    }

    public FairyController GetFariyFire(Vector2 position, float angle = 0.0f)
    {
        return fairyFire.GetObject(position, new Vector3(0, 0, angle));
    }

    public FairyController GetFariyPoison(Vector2 position, float angle = 0.0f)
    {
        return fairyPoison.GetObject(position, new Vector3(0, 0, angle));
    }

    public FairyController GetFariyLight(Vector2 position, float angle = 0.0f)
    {
        return fairyLight.GetObject(position, new Vector3(0, 0, angle));
    }

    public FairyController GetFariyFreeze(Vector2 position, float angle = 0.0f)
    {
        return fairyFreeze.GetObject(position, new Vector3(0, 0, angle));
    }

    public WireCircleMarker GetWireCircleMarker(Vector2 position, float angle = 0.0f)
    {
        return marker.GetObject(position, new Vector3(0, 0, angle));
    }
}
