using UnityEngine;

/// <summary>
/// ObjectPool에 있는 오브젝트들을 소환하는 팩토리 클래스
/// </summary>
public class Factory : Singleton<Factory>
{
    /// <summary>
    /// Enemy_000 풀
    /// </summary>
    private Enemy_000Pool enemy_000;

    /// <summary>
    /// Enemy_001 풀
    /// </summary>
    private Enemy_001Pool enemy_001;

    /// <summary>
    /// Enemy_002 풀
    /// </summary>
    private Enemy_002Pool enemy_002;

    /// <summary>
    /// Enemy_003 풀
    /// </summary>
    private Enemy_003Pool enemy_003;

    /// <summary>
    /// Enemy_004 풀
    /// </summary>
    private Enemy_004Pool enemy_004;

    /// <summary>
    /// Enemy_005 풀
    /// </summary>
    private Enemy_005Pool enemy_005;

    /// <summary>
    /// Enemy_006 풀
    /// </summary>
    private Enemy_006Pool enemy_006;

    /// <summary>
    /// Enemy_007 풀
    /// </summary>
    private Enemy_007Pool enemy_007;

    /// <summary>
    /// Enemy_008 풀
    /// </summary>
    private Enemy_008Pool enemy_008;

    /// <summary>
    /// Enemy_009 풀
    /// </summary>
    private Enemy_009Pool enemy_009;

    /// <summary>
    /// Enemy_010 풀
    /// </summary>
    private Enemy_010Pool enemy_010;

    /// <summary>
    /// Enemy_011 풀
    /// </summary>
    private Enemy_011Pool enemy_011;

    /// <summary>
    /// Enemy_012 풀
    /// </summary>
    private Enemy_012Pool enemy_012;

    /// <summary>
    /// Enemy _013 풀
    /// </summary>
    private Enemy_013Pool enemy_013;

    /// <summary>
    /// Enemy_014 풀
    /// </summary>
    private Enemy_014Pool enemy_014;

    /// <summary>
    /// Enemy_015 풀
    /// </summary>
    private Enemy_015Pool enemy_015;

    /// <summary>
    /// Enemy_016 풀
    /// </summary>
    private Enemy_016Pool enemy_016;

    /// <summary>
    /// Enemy_017 풀
    /// </summary>
    private Enemy_017Pool enemy_017;

    /// <summary>
    /// Enemy_018 풀
    /// </summary>
    private Enemy_018Pool enemy_018;

    /// <summary>
    /// Enemy_019 풀
    /// </summary>
    private Enemy_019Pool enemy_019;

    /// <summary>
    /// Enemy_020 풀
    /// </summary>
    private Enemy_020Pool enemy_020;

    /// <summary>
    /// Enemy_021 풀
    /// </summary>
    private Enemy_021Pool enemy_021;

    /// <summary>
    /// Enemy_022 풀
    /// </summary>
    private Enemy_022Pool enemy_022;

    /// <summary>
    /// Enemy_023 풀
    /// </summary>
    private Enemy_023Pool enemy_023;

    /// <summary>
    /// Enemy_024 풀
    /// </summary>
    private Enemy_024Pool enemy_024;

    /// <summary>
    /// Enemy_025 풀
    /// </summary>
    private Enemy_025Pool enemy_025;

    /// <summary>
    /// Enemy_026 풀
    /// </summary>
    private Enemy_026Pool enemy_026;

    /// <summary>
    /// Enemy_027 풀
    /// </summary>
    private Enemy_027Pool enemy_027;

    /// <summary>
    /// Enemy_028 풀
    /// </summary>
    private Enemy_028Pool enemy_028;

    /// <summary>
    /// Enemy_029 풀
    /// </summary>
    private Enemy_029Pool enemy_029;

    /// <summary>
    /// Enemy_030 풀
    /// </summary>
    private Enemy_030Pool enemy_030;

    /// <summary>
    /// Enemy_031 풀
    /// </summary>
    private Enemy_031Pool enemy_031;

    /// <summary>
    /// Enemy_100 풀
    /// </summary>
    private Enemy_100Pool enemy_100;

    /// <summary>
    /// Enemy_101 풀
    /// </summary>
    private Enemy_101Pool enemy_101;

    /// <summary>
    /// Enemy_102 풀
    /// </summary>
    private Enemy_102Pool enemy_102;

    /// <summary>
    /// Enemy_103 풀
    /// </summary>
    private Enemy_103Pool enemy_103;

    /// <summary>
    /// Enemy_104 풀
    /// </summary>
    private Enemy_104Pool enemy_104;

    /// <summary>
    /// Enemy_105 풀
    /// </summary>
    private Enemy_105Pool enemy_105;

    /// <summary>
    /// Enemy_200 풀
    /// </summary>
    private Enemy_200Pool enemy_200;

    /// <summary>
    /// Enemy_201 풀
    /// </summary>
    private Enemy_201Pool enemy_201;

    /// <summary>
    /// Enemy_202 풀
    /// </summary>
    private Enemy_202Pool enemy_202;

    /// <summary>
    /// Enemy_203 풀
    /// </summary>
    private Enemy_203Pool enemy_203;

    /// <summary>
    /// Enemy_204 풀
    /// </summary>
    private Enemy_204Pool enemy_204;

    /// <summary>
    /// Enemy_205 풀
    /// </summary>
    private Enemy_205Pool enemy_205;

    /// <summary>
    /// Enemy_206 풀
    /// </summary>
    private Enemy_206Pool enemy_206;

    /// <summary>
    /// Enemy_207 풀
    /// </summary>
    private Enemy_207Pool enemy_207;

    /// <summary>
    /// Enemy_208 풀
    /// </summary>
    private Enemy_208Pool enemy_208;

    /// <summary>
    /// Enemy_209 풀
    /// </summary>
    private Enemy_209Pool enemy_209;

    /// <summary>
    /// Enemy_210 풀
    /// </summary>
    private Enemy_210Pool enemy_210;

    /// <summary>
    /// Enemy_211 풀
    /// </summary>
    private Enemy_211Pool enemy_211;

    /// <summary>
    /// EnemyDieEffect 풀
    /// </summary>
    private EnemyDieEffectPool enemyDieEffect;

    /// <summary>
    /// EnemyHit 풀
    /// </summary>
    private EnemyHitPool enemyHit;

    /// <summary>
    /// BoatHit 풀
    /// </summary>
    private BoatHitPool boatHit;

    /// <summary>
    /// Projectile_Basic 풀
    /// </summary>
    private Projectile_BasicPool projectile_Basic;

    /// <summary>
    /// Projectile_Fire 풀
    /// </summary>
    private Projectile_FirePool projectile_Fire;

    /// <summary>
    /// Projectile_Poison 풀
    /// </summary>
    private Projectile_PoisonPool projectile_Poison;

    /// <summary>
    /// Projectile_Freeze 풀
    /// </summary>
    private Projectile_FreezePool projectile_Freeze;

    /// <summary>
    /// Projectile_Electronic 풀
    /// </summary>
    private Projectile_ElectronicPool projectile_Electronic;

    /// <summary>
    /// Projectile_Frozen 풀
    /// </summary>
    private Projectile_FrozenPool projectile_Frozen;

    /// <summary>
    /// Melee 풀
    /// </summary>
    private MeleePool melee;

    /// <summary>
    /// Arrow 풀
    /// </summary>
    private ArrowPool arrow;

    /// <summary>
    /// SlingShotStone 풀
    /// </summary>
    private SlingShotStonePool slingShotStone;

    /// <summary>
    /// Bullet 풀
    /// </summary>
    private BulletPool bullet;

    /// <summary>
    /// FairyBasic 풀
    /// </summary>
    private FairyBasicPool fairyBasic;

    /// <summary>
    /// FairyFire 풀
    /// </summary>
    private FairyFirePool fairyFire;

    /// <summary>
    /// FairyPosion 풀
    /// </summary>
    private FairyPoisonPool fairyPoison;

    /// <summary>
    /// FairyLight 풀
    /// </summary>
    private FairyLightPool fairyLight;

    /// <summary>
    /// FairyFreeze 풀
    /// </summary>
    private FairyFreezePool fairyFreeze;

    /// <summary>
    /// FairyFrozen 풀
    /// </summary>
    private FairyFrozenPool fairyFrozen;

    /// <summary>
    /// FairyEletronic 풀
    /// </summary>
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
    /// Gold 재화 풀
    /// </summary>
    private GoldPool gold;

    /// <summary>
    /// Gem 재화 풀
    /// </summary>
    private GemPool gem;

    /// <summary>
    /// Diamond 재화 풀
    /// </summary>
    private DiamondPool diamond;

    /// <summary>
    /// GoldSparkle 풀
    /// </summary>
    private GoldSparklePool goldSparkle;

    /// <summary>
    /// GemSparkle 풀
    /// </summary>
    private GemSparklePool gemSparkle;

    /// <summary>
    /// DiamondSparkle 풀
    /// </summary>
    private DiamondSparklePool diamondSparkle;

    /// <summary>
    /// Factory 초기화 함수
    /// </summary>
    protected override void OnInitialize()
    {
        if (this.TryGetComponentInChildren<Enemy_000Pool>(out enemy_000))
            enemy_000.Initialize();

        if (this.TryGetComponentInChildren<Enemy_001Pool>(out enemy_001))
            enemy_001.Initialize();

        if (this.TryGetComponentInChildren<Enemy_002Pool>(out enemy_002))
            enemy_002.Initialize();

        if (this.TryGetComponentInChildren<Enemy_003Pool>(out enemy_003))
            enemy_003.Initialize();

        if (this.TryGetComponentInChildren<Enemy_004Pool>(out enemy_004))
            enemy_004.Initialize();

        if (this.TryGetComponentInChildren<Enemy_005Pool>(out enemy_005))
            enemy_005.Initialize();

        if (this.TryGetComponentInChildren<Enemy_006Pool>(out enemy_006))
            enemy_006.Initialize();

        if (this.TryGetComponentInChildren<Enemy_007Pool>(out enemy_007))
            enemy_007.Initialize();

        if (this.TryGetComponentInChildren<Enemy_008Pool>(out enemy_008))
            enemy_008.Initialize();

        if (this.TryGetComponentInChildren<Enemy_009Pool>(out enemy_009))
            enemy_009.Initialize();

        if (this.TryGetComponentInChildren<Enemy_010Pool>(out enemy_010))
            enemy_010.Initialize();

        if (this.TryGetComponentInChildren<Enemy_011Pool>(out enemy_011))
            enemy_011.Initialize();

        if (this.TryGetComponentInChildren<Enemy_012Pool>(out enemy_012))
            enemy_012.Initialize();

        if (this.TryGetComponentInChildren<Enemy_013Pool>(out enemy_013))
            enemy_013.Initialize();

        if (this.TryGetComponentInChildren<Enemy_014Pool>(out enemy_014))
            enemy_014.Initialize();

        if (this.TryGetComponentInChildren<Enemy_015Pool>(out enemy_015))
            enemy_015.Initialize();

        if (this.TryGetComponentInChildren<Enemy_016Pool>(out enemy_016))
            enemy_016.Initialize();

        if (this.TryGetComponentInChildren<Enemy_017Pool>(out enemy_017))
            enemy_017.Initialize();

        if (this.TryGetComponentInChildren<Enemy_018Pool>(out enemy_018))
            enemy_018.Initialize();

        if (this.TryGetComponentInChildren<Enemy_019Pool>(out enemy_019))
            enemy_019.Initialize();

        if (this.TryGetComponentInChildren<Enemy_020Pool>(out enemy_020))
            enemy_020.Initialize();

        if (this.TryGetComponentInChildren<Enemy_021Pool>(out enemy_021))
            enemy_021.Initialize();

        if (this.TryGetComponentInChildren<Enemy_022Pool>(out enemy_022))
            enemy_022.Initialize();

        if (this.TryGetComponentInChildren<Enemy_023Pool>(out enemy_023))
            enemy_023.Initialize();

        if (this.TryGetComponentInChildren<Enemy_024Pool>(out enemy_024))
            enemy_024.Initialize();

        if (this.TryGetComponentInChildren<Enemy_025Pool>(out enemy_025))
            enemy_025.Initialize();

        if (this.TryGetComponentInChildren<Enemy_026Pool>(out enemy_026))
            enemy_026.Initialize();

        if (this.TryGetComponentInChildren<Enemy_027Pool>(out enemy_027))
            enemy_027.Initialize();

        if (this.TryGetComponentInChildren<Enemy_028Pool>(out enemy_028))
            enemy_028.Initialize();

        if (this.TryGetComponentInChildren<Enemy_029Pool>(out enemy_029))
            enemy_029.Initialize();

        if (this.TryGetComponentInChildren<Enemy_030Pool>(out enemy_030))
            enemy_030.Initialize();

        if (this.TryGetComponentInChildren<Enemy_031Pool>(out enemy_031))
            enemy_031.Initialize();

        if (this.TryGetComponentInChildren<Enemy_100Pool>(out enemy_100))
            enemy_100.Initialize();

        if (this.TryGetComponentInChildren<Enemy_101Pool>(out enemy_101))
            enemy_101.Initialize();

        if (this.TryGetComponentInChildren<Enemy_102Pool>(out enemy_102))
            enemy_102.Initialize();

        if (this.TryGetComponentInChildren<Enemy_103Pool>(out enemy_103))
            enemy_103.Initialize();

        if (this.TryGetComponentInChildren<Enemy_104Pool>(out enemy_104))
            enemy_104.Initialize();

        if (this.TryGetComponentInChildren<Enemy_105Pool>(out enemy_105))
            enemy_105.Initialize();

        if (this.TryGetComponentInChildren<Enemy_200Pool>(out enemy_200))
            enemy_200.Initialize();

        if (this.TryGetComponentInChildren<Enemy_201Pool>(out enemy_201))
            enemy_201.Initialize();

        if (this.TryGetComponentInChildren<Enemy_202Pool>(out enemy_202))
            enemy_202.Initialize();

        if (this.TryGetComponentInChildren<Enemy_203Pool>(out enemy_203))
            enemy_203.Initialize();

        if (this.TryGetComponentInChildren<Enemy_204Pool>(out enemy_204))
            enemy_204.Initialize();

        if (this.TryGetComponentInChildren<Enemy_205Pool>(out enemy_205))
            enemy_205.Initialize();

        if (this.TryGetComponentInChildren<Enemy_206Pool>(out enemy_206))
            enemy_206.Initialize();

        if (this.TryGetComponentInChildren<Enemy_207Pool>(out enemy_207))
            enemy_207.Initialize();

        if (this.TryGetComponentInChildren<Enemy_208Pool>(out enemy_208))
            enemy_208.Initialize();

        if (this.TryGetComponentInChildren<Enemy_209Pool>(out enemy_209))
            enemy_209.Initialize();

        if (this.TryGetComponentInChildren<Enemy_210Pool>(out enemy_210))
            enemy_210.Initialize();

        if (this.TryGetComponentInChildren<Enemy_211Pool>(out enemy_211))
            enemy_211.Initialize();

        if (this.TryGetComponentInChildren<EnemyDieEffectPool>(out enemyDieEffect))
            enemyDieEffect.Initialize();

        if (this.TryGetComponentInChildren<EnemyHitPool>(out enemyHit))
            enemyHit.Initialize();

        if (this.TryGetComponentInChildren<BoatHitPool>(out boatHit))
            boatHit.Initialize();

        if (this.TryGetComponentInChildren<Projectile_BasicPool>(out projectile_Basic))
            projectile_Basic.Initialize();

        if (this.TryGetComponentInChildren<Projectile_FirePool>(out projectile_Fire))
            projectile_Fire.Initialize();

        if (this.TryGetComponentInChildren<Projectile_PoisonPool>(out projectile_Poison))
            projectile_Poison.Initialize();

        if (this.TryGetComponentInChildren<Projectile_FreezePool>(out projectile_Freeze))
            projectile_Freeze.Initialize();

        if (this.TryGetComponentInChildren<Projectile_ElectronicPool>(out projectile_Electronic))
            projectile_Electronic.Initialize();

        if (this.TryGetComponentInChildren<Projectile_FrozenPool>(out projectile_Frozen))
            projectile_Frozen.Initialize();

        if (this.TryGetComponentInChildren<MeleePool>(out melee))
            melee.Initialize();

        if (this.TryGetComponentInChildren<ArrowPool>(out arrow))
            arrow.Initialize();

        if (this.TryGetComponentInChildren<SlingShotStonePool>(out slingShotStone))
            slingShotStone.Initialize();

        if (this.TryGetComponentInChildren<BulletPool>(out bullet))
            bullet.Initialize();

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

        if (this.TryGetComponentInChildren<GoldPool>(out gold))
            gold.Initialize();

        if (this.TryGetComponentInChildren<GemPool>(out gem))
            gem.Initialize();

        if (this.TryGetComponentInChildren<DiamondPool>(out diamond))
            diamond.Initialize();

        if (this.TryGetComponentInChildren<GoldSparklePool>(out goldSparkle))
            goldSparkle.Initialize();

        if (this.TryGetComponentInChildren<GemSparklePool>(out gemSparkle))
            gemSparkle.Initialize();

        if (this.TryGetComponentInChildren<DiamondSparklePool>(out diamondSparkle))
            diamondSparkle.Initialize();
    }

    #region Enemy Pool
    /// <summary>
    /// Enemy_000을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_000</returns>
    public EnemyController GetEnemy_000(Vector2 position, float angle = 0.0f)
    {
        return enemy_000.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_001을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_001</returns>
    public EnemyController GetEnemy_001(Vector2 position, float angle = 0.0f)
    {
        return enemy_001.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_002를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_002</returns>
    public EnemyController GetEnemy_002(Vector2 position, float angle = 0.0f)
    {
        return enemy_002.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_003을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_003</returns>
    public EnemyController GetEnemy_003(Vector2 position, float angle = 0.0f)
    {
        return enemy_003.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_004를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_004</returns>
    public EnemyController GetEnemy_004(Vector2 position, float angle = 0.0f)
    {
        return enemy_004.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_005를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_005</returns>
    public EnemyController GetEnemy_005(Vector2 position, float angle = 0.0f)
    {
        return enemy_005.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_006을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_006</returns>
    public EnemyController GetEnemy_006(Vector2 position, float angle = 0.0f)
    {
        return enemy_006.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_007을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_007</returns>
    public EnemyController GetEnemy_007(Vector2 position, float angle = 0.0f)
    {
        return enemy_007.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_008을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_008</returns>
    public EnemyController GetEnemy_008(Vector2 position, float angle = 0.0f)
    {
        return enemy_008.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_009를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_009</returns>
    public EnemyController GetEnemy_009(Vector2 position, float angle = 0.0f)
    {
        return enemy_009.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_010을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_010</returns>
    public EnemyController GetEnemy_010(Vector2 position, float angle = 0.0f)
    {
        return enemy_010.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_011을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_011</returns>
    public EnemyController GetEnemy_011(Vector2 position, float angle = 0.0f)
    {
        return enemy_011.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_012를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_012</returns>
    public EnemyController GetEnemy_012(Vector2 position, float angle = 0.0f)
    {
        return enemy_012.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_013을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_013</returns>
    public EnemyController GetEnemy_013(Vector2 position, float angle = 0.0f)
    {
        return enemy_013.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_014를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_014</returns>
    public EnemyController GetEnemy_014(Vector2 position, float angle = 0.0f)
    {
        return enemy_014.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_015를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_015</returns>
    public EnemyController GetEnemy_015(Vector2 position, float angle = 0.0f)
    {
        return enemy_015.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_016을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_016</returns>
    public EnemyController GetEnemy_016(Vector2 position, float angle = 0.0f)
    {
        return enemy_016.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_017을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_017</returns>
    public EnemyController GetEnemy_017(Vector2 position, float angle = 0.0f)
    {
        return enemy_017.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_018을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_018</returns>
    public EnemyController GetEnemy_018(Vector2 position, float angle = 0.0f)
    {
        return enemy_018.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_019를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_019</returns>
    public EnemyController GetEnemy_019(Vector2 position, float angle = 0.0f)
    {
        return enemy_019.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_020을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_020</returns>
    public EnemyController GetEnemy_020(Vector2 position, float angle = 0.0f)
    {
        return enemy_020.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_021을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_021</returns>
    public EnemyController GetEnemy_021(Vector2 position, float angle = 0.0f)
    {
        return enemy_021.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_022를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_022</returns>
    public EnemyController GetEnemy_022(Vector2 position, float angle = 0.0f)
    {
        return enemy_022.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_023을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_023</returns>
    public EnemyController GetEnemy_023(Vector2 position, float angle = 0.0f)
    {
        return enemy_023.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_024를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_024</returns>
    public EnemyController GetEnemy_024(Vector2 position, float angle = 0.0f)
    {
        return enemy_024.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_025를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_025</returns>
    public EnemyController GetEnemy_025(Vector2 position, float angle = 0.0f)
    {
        return enemy_025.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_026을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_026</returns>
    public EnemyController GetEnemy_026(Vector2 position, float angle = 0.0f)
    {
        return enemy_026.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_027을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_027</returns>
    public EnemyController GetEnemy_027(Vector2 position, float angle = 0.0f)
    {
        return enemy_027.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_028을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_028</returns>
    public EnemyController GetEnemy_028(Vector2 position, float angle = 0.0f)
    {
        return enemy_028.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_029를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_029</returns>
    public EnemyController GetEnemy_029(Vector2 position, float angle = 0.0f)
    {
        return enemy_029.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_030을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_030</returns>
    public EnemyController GetEnemy_030(Vector2 position, float angle = 0.0f)
    {
        return enemy_030.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_031을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_031</returns>
    public EnemyController GetEnemy_031(Vector2 position, float angle = 0.0f)
    {
        return enemy_031.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_100을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_100</returns>
    public EnemyController GetEnemy_100(Vector2 position, float angle = 0.0f)
    {
        return enemy_100.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_101을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_101</returns>
    public EnemyController GetEnemy_101(Vector2 position, float angle = 0.0f)
    {
        return enemy_101.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_102를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_102</returns>
    public EnemyController GetEnemy_102(Vector2 position, float angle = 0.0f)
    {
        return enemy_102.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_103을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_103</returns>
    public EnemyController GetEnemy_103(Vector2 position, float angle = 0.0f)
    {
        return enemy_103.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_104를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_104</returns>
    public EnemyController GetEnemy_104(Vector2 position, float angle = 0.0f)
    {
        return enemy_104.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_105를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_105</returns>
    public EnemyController GetEnemy_105(Vector2 position, float angle = 0.0f)
    {
        return enemy_105.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_200을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_200</returns>
    public EnemyController GetEnemy_200(Vector2 position, float angle = 0.0f)
    {
        return enemy_200.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_201을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_201</returns>
    public EnemyController GetEnemy_201(Vector2 position, float angle = 0.0f)
    {
        return enemy_201.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_202를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_202</returns>
    public EnemyController GetEnemy_202(Vector2 position, float angle = 0.0f)
    {
        return enemy_202.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_203을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_203</returns>
    public EnemyController GetEnemy_203(Vector2 position, float angle = 0.0f)
    {
        return enemy_203.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_204를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_204</returns>
    public EnemyController GetEnemy_204(Vector2 position, float angle = 0.0f)
    {
        return enemy_204.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_205를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_205</returns>
    public EnemyController GetEnemy_205(Vector2 position, float angle = 0.0f)
    {
        return enemy_205.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_206을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_206</returns>
    public EnemyController GetEnemy_206(Vector2 position, float angle = 0.0f)
    {
        return enemy_206.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_207을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_207</returns>
    public EnemyController GetEnemy_207(Vector2 position, float angle = 0.0f)
    {
        return enemy_207.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_208을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_208</returns>
    public EnemyController GetEnemy_208(Vector2 position, float angle = 0.0f)
    {
        return enemy_208.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_209를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_209</returns>
    public EnemyController GetEnemy_209(Vector2 position, float angle = 0.0f)
    {
        return enemy_209.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_210을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_210</returns>
    public EnemyController GetEnemy_210(Vector2 position, float angle = 0.0f)
    {
        return enemy_210.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Enemy_211을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Enemy_211</returns>
    public EnemyController GetEnemy_211(Vector2 position, float angle = 0.0f)
    {
        return enemy_211.GetObject(position, new Vector3(0, 0, angle));
    }
    #endregion

    /// <summary>
    /// Projectile 공격체를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="rangedId">Projectile 아이디</param>
    /// <returns>소환된 Projectile</returns>
    public Projectile GetProjectile(Vector2 position, uint rangedId)
    {
        Projectile projectile = null;

        switch (rangedId)
        {
            case 0:
                projectile = GetProjectile_Basic(position);
                break;

            case 1:
                projectile = GetProjectile_Fire(position);
                break;

            case 2:
                projectile = GetProjectile_Poison(position);
                break;

            case 3:
                projectile = GetProjectile_Freeze(position);
                break;

            case 4:
                projectile = GetProjectile_Electronic(position);
                break;

            case 5:
                projectile = GetProjectile_Frozen(position);
                break;
        }

        return projectile;
    }

    /// <summary>
    /// Projectile_Basic을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Projectile_Basic</returns>
    public Projectile GetProjectile_Basic(Vector2 position, float angle = 0.0f)
    {
        return projectile_Basic.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Projectile_Fire를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Projectile_Fire</returns>
    public Projectile GetProjectile_Fire(Vector2 position, float angle = 0.0f)
    {
        return projectile_Fire.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Projectile_Poison을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Projectile_Poison</returns>
    public Projectile GetProjectile_Poison(Vector2 position, float angle = 0.0f)
    {
        return projectile_Poison.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Projectile_Freeze를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Projectile_Freeze</returns>
    public Projectile GetProjectile_Freeze(Vector2 position, float angle = 0.0f)
    {
        return projectile_Freeze.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Projectile_Electronic을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Projectile_Electronic</returns>
    public Projectile GetProjectile_Electronic(Vector2 position, float angle = 0.0f)
    {
        return projectile_Electronic.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Projectile_Frozen을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환한 Projectile_Frozen</returns>
    public Projectile GetProjectile_Frozen(Vector2 position, float angle = 0.0f)
    {
        return projectile_Frozen.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Melee를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환된 Melee</returns>
    public Melee GetMelee(Vector2 position, float angle = 0.0f)
    {
        return melee.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Ranged 공격체를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="rangedId">Ranged 아이디</param>
    /// <returns>소환된 Ranged</returns>
    public Ranged GetRanged(Vector2 position, uint rangedId)
    {
        Ranged ranged = null;

        switch (rangedId)
        {
            case 0:
                ranged = GetArrow(position);
                break;
            case 1:
                ranged = GetSlingShotStone(position);
                break;
            case 2:
                ranged = GetBullet(position);
                break;
        }

        return ranged;
    }

    /// <summary>
    /// Arrow를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환된 Arrow</returns>
    public Ranged GetArrow(Vector2 position, float angle = 0.0f)
    {
        return arrow.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// SlingShowStone을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환된 SlingShotStone</returns>
    public Ranged GetSlingShotStone(Vector2 position, float angle = 0.0f)
    {
        return slingShotStone.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Bullet을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환된 Bullet</returns>
    public Ranged GetBullet(Vector2 position, float angle = 0.0f)
    {
        return bullet.GetObject(position, new Vector3(0, 0, angle));
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

    /// <summary>
    /// 페어리 소환 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각</param>
    /// <returns></returns>
    public FairyController GetFairyBasic(Vector2 position, float angle = 0.0f)
    {
        return fairyBasic.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// 페어리 소환 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각</param>
    /// <returns></returns>
    public FairyController GetFariyFire(Vector2 position, float angle = 0.0f)
    {
        return fairyFire.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// 페어리 소환 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각</param>
    /// <returns></returns>
    public FairyController GetFariyPoison(Vector2 position, float angle = 0.0f)
    {
        return fairyPoison.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// 페어리 소환 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각</param>
    /// <returns></returns> 
    public FairyController GetFariyLight(Vector2 position, float angle = 0.0f)
    {
        return fairyLight.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// 페어리 소환 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각</param>
    /// <returns></returns>
    public FairyController GetFariyFreeze(Vector2 position, float angle = 0.0f)
    {
        return fairyFreeze.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// 페어리 소환 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각</param>
    /// <returns></returns>
    public FairyController GetFariyFrozen(Vector2 position, float angle = 0.0f)
    {
        return fairyFrozen.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// 페어리 소환 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각</param>
    /// <returns></returns>
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

    /// <summary>
    /// 적이 맞을 떄 이펙트를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환된 이펙트</returns>
    public Effect GetEnemyHit(Vector2 position, float angle = 0.0f)
    {
        Vector2 rand = Random.insideUnitCircle * 0.1f;
        position += rand;
        return enemyHit.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// 보트가 맞을 때 이펙트를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 함수</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환된 이펙트</returns>
    public Effect GetBoatHit(Vector2 position, float angle = 0.0f)
    {
        Vector2 rand = Random.insideUnitCircle * 0.1f;
        position += rand;
        return boatHit.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// WireCircleMarker를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환된 WireCircleMaker</returns>
    public WireCircleMarker GetWireCircleMarker(Vector2 position, float angle = 0.0f)
    {
        return marker.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// GoldSparkle 이펙트를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환된 GoldSparkle</returns>
    public Effect GetGoldSparkle(Vector2 position, float angle = 0.0f)
    {
        return goldSparkle.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// GemSparkle 이펙트를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환된 GemSparkle</returns>
    public Effect GetGemSparkle(Vector2 position, float angle = 0.0f)
    {
        return gemSparkle.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// DiamondSparkle 이펙트를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <returns>소환된 DiamondSparkle</returns>
    public Effect GetDiamondSparkle(Vector2 position, float angle = 0.0f)
    {
        return diamondSparkle.GetObject(position, new Vector3(0, 0, angle));
    }
    #endregion

    #region Currency Pool
    /// <summary>
    /// Gold 재화를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <param name="goldAmount">Gold 양</param>
    /// <returns>소환된 Gold</returns>
    public CurrencyDrop GetGold(Vector2 position, float angle = 0.0f, ulong goldAmount = 0)
    {
        Vector2 rand = Random.insideUnitCircle * 0.5f;
        position += rand;
        CurrencyDrop Gold = gold.GetObject(position, new Vector3(0, 0, angle));
        Gold.SetDropInfo(goldAmount);
        return Gold;
    }

    /// <summary>
    /// Gem 재화를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <param name="gemAmount">Gem 양</param>
    /// <returns>소환된 Gem</returns>
    public CurrencyDrop GetGem(Vector2 position, float angle = 0.0f, ulong gemAmount = 0)
    {
        Vector2 rand = Random.insideUnitCircle * 0.5f;
        position += rand;
        CurrencyDrop Gem = gem.GetObject(position, new Vector3(0, 0, angle));
        Gem.SetDropInfo(gemAmount);
        return Gem;
    }

    /// <summary>
    /// Diamond 재화를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="angle">소환 각도</param>
    /// <param name="diamondAmount">Diamond 양</param>
    /// <returns>소환된 Diamond</returns>
    public CurrencyDrop GetDiamond(Vector2 position, float angle = 0.0f, uint diamondAmount = 0)
    {
        Vector2 rand = Random.insideUnitCircle * 0.5f;
        position += rand;
        CurrencyDrop Diamond = diamond.GetObject(position, new Vector3(0, 0, angle));
        Diamond.SetDropInfo(diamondAmount);
        return Diamond;
    }
    #endregion
}
