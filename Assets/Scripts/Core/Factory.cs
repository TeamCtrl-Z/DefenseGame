using UnityEngine;

/// <summary>
/// ObjectPool에 있는 오브젝트들을 소환하는 팩토리 클래스
/// </summary>
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
    /// EnemyDieEffect 풀
    /// </summary>
    private EnemyDieEffectPool enemyDieEffect;

    /// <summary>
    /// Projectile 풀
    /// </summary>
    private ProjectilePool projectile;

    /// <summary>
    /// Fairy풀
    /// </summary>
    private FairyBasicPool fairyBasic;
    private FairyFirePool fairyFire;
    private FairyPoisonPool fairyPoison;
    private FairyLightPool fairyLight;
    private FairyFreezePool fairyFreeze;
    private FairyFrozenPool fairyFrozen;
    private FairyEletronicPool fairyEletronic;

    /// <summary>
    /// 눈보라 파티클 풀
    /// </summary>
    private SnowPool snow;

    /// <summary>
    /// 불 폭발 파티클 풀(Fire Splash 데미지 때 사용)
    /// </summary>
    private FireExplosionPool fireExp;

    /// <summary>
    /// 번개 파티클 풀(Eletronic 효과로 사용)
    /// </summary>
    private LightningPool lightning;

    /// <summary>
    /// 마크 풀
    /// </summary>
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

        if (this.TryGetComponentInChildren<EnemyDieEffectPool>(out enemyDieEffect))
            enemyDieEffect.Initialize();

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

        if (this.TryGetComponentInChildren<FairyFrozenPool>(out fairyFrozen))
            fairyFrozen.Initialize();

        if (this.TryGetComponentInChildren<FairyEletronicPool>(out fairyEletronic))
            fairyEletronic.Initialize();

        if (this.TryGetComponentInChildren<SnowPool>(out snow))
            snow.Initialize();

        if (this.TryGetComponentInChildren<FireExplosionPool>(out fireExp))
            fireExp.Initialize();

        if (this.TryGetComponentInChildren<LightningPool>(out lightning))
            lightning.Initialize();

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
    #region Enemy Pool
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
    #endregion

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

    #region Fairy Pool
    /// <summary>
    /// FairyType을 입력하여 Fairy를 받아오는 함수
    /// </summary>
    /// <param name="type"> Fairy 유형 </param>
    /// <param name="position"> 위치 </param>
    /// <param name="angle"> 각도 </param>
    /// <returns></returns>
    public FairyController GetFariyByType(FairyType type, Vector2 position, float angle = 0.0f)
    {
        switch (type)
        {
            case FairyType.Basic: return fairyBasic.GetObject(position, new Vector3(0, 0, angle));
            case FairyType.Fire: return fairyFire.GetObject(position, new Vector3(0, 0, angle));
            case FairyType.Poison: return fairyPoison.GetObject(position, new Vector3(0, 0, angle));
            case FairyType.Light: return fairyLight.GetObject(position, new Vector3(0, 0, angle));
            case FairyType.Freeze: return fairyFreeze.GetObject(position, new Vector3(0, 0, angle));
            case FairyType.Frozen: return fairyFrozen.GetObject(position, new Vector3(0, 0, angle));
            case FairyType.Electronic: return fairyEletronic.GetObject(position, new Vector3(0, 0, angle));
            default: return null;
        }
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

    public FairyController GetFariyFrozen(Vector2 position, float angle = 0.0f)
    {
        return fairyFrozen.GetObject(position, new Vector3(0, 0, angle));
    }

    public FairyController GetFariyEletronic(Vector2 position, float angle = 0.0f)
    {
        return fairyEletronic.GetObject(position, new Vector3(0, 0, angle));
    }
    #endregion

    #region Effect Pool

    /// <summary>
    /// 눈보라 이펙트 소환 함수
    /// </summary>
    /// <param name="position"></param>
    /// <param name="angle"></param>
    /// <returns></returns>
    public Effect GetSnow(Vector2 position, float angle = 0.0f)
    {
        return snow.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// 불 속성 스플래시 이펙트 소환 함수
    /// </summary>
    /// <param name="position"></param>
    /// <param name="angle"></param>
    /// <returns></returns>
    public Effect GetFireExplosion(Vector2 position, float angle = 0.0f)
    {
        return fireExp.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// 전기 속성 번개 이펙트 소환 함수
    /// </summary>
    /// <param name="position"></param>
    /// <param name="angle"></param>
    /// <returns></returns>
    public Effect GetLightning(Vector2 position, float angle = 0.0f)
    {
        return lightning.GetObject(position, new Vector3(0, 0, angle));
    }
    
    /// <summary>
    /// 적이 죽을 때 이펙트를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 이펙트</returns>
    public Effect GetEnemyDieEffect(Vector2 position, float angle = 0.0f)
    {
        return enemyDieEffect.GetObject(position, new Vector3(0, 0, angle));
    }

    public WireCircleMarker GetWireCircleMarker(Vector2 position, float angle = 0.0f)
    {
        return marker.GetObject(position, new Vector3(0, 0, angle));
    }
    #endregion
}
