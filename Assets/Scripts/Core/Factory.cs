using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Singleton<Factory>
{
    /// <summary>
    /// Enemy 풀
    /// </summary>
    private EnemyPool enemy;

    /// <summary>
    /// Projectile 풀
    /// </summary>
    private ProjectilePool projectile;

    /// <summary>
    /// Fairy 풀
    /// </summary>
    private FairyPool fairy;

    /// <summary>
    /// 초기화 함수
    /// </summary>
    protected override void OnInitialize()
    {
        if (this.TryGetComponentInChildren<EnemyPool>(out enemy))
            enemy.Initialize();

        if (this.TryGetComponentInChildren<ProjectilePool>(out projectile))
            projectile.Initialize();

        if (this.TryGetComponentInChildren<FairyPool>(out fairy))
            fairy.Initialize();
    }

    /// <summary>
    /// 캐릭터를 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="eulerAngles">소환 각도</param>
    /// <returns>소환한 캐릭터</returns>
    public EnemyController GetEnemy(Vector2 position, float angle = 0.0f)
    {
        return enemy.GetObject(position, new Vector3(0, 0, angle));
    }

    /// <summary>
    /// Projectile을 소환하는 함수
    /// </summary>
    /// <param name="position">소환 위치</param>
    /// <param name="eulerAngles">소환 각도</param>
    /// <returns>소환한 Projectile</returns>
    public Projectile GetProjectile(Vector2 position, float angle = 0.0f)
    {
        Debug.Log($"GetProjectile {position}");
        return projectile.GetObject(position, new Vector3(0, 0, angle));
    }

    public FairyController GetFairy(Vector2 position, float angle = 0.0f)
    {
        return fairy.GetObject(position, new Vector3(0, 0, angle));
    }
}
