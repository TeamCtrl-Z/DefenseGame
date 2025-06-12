using System.Collections;
using UnityEngine;

/// <summary>
/// Trail이 자연스럽게 꺼지게 하는 클래스
/// </summary>
public class TrailEffect : MonoBehaviour
{
    /// <summary>
    /// 부모 프로젝타일
    /// </summary>
    private Projectile parent;

    /// <summary>
    /// 트레일 파티클 시스템
    /// </summary>
    private ParticleSystem trail;

    /// <summary>
    /// 최대 생존 시간
    /// </summary>
    private float maxLifeTime;

    /// <summary>
    /// 초기화용 위치
    /// </summary>
    private Vector3 initialLocalPos;

    private void Awake()
    {
        parent = GetComponentInParent<Projectile>();
        trail = GetComponent<ParticleSystem>();
        maxLifeTime = trail.main.startLifetime.constantMax;

        initialLocalPos = transform.localPosition;
    }

    private void OnEnable()
    {
        StopAllCoroutines();
        trail.Clear();
        trail.Play();
    }

    /// <summary>
    /// Projectile 비활성화 직전에 호출하는 함수
    /// </summary>
    public void FadeOutAndDetach()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    /// <summary>
    /// 트레일이 없어지게 하는 코루틴
    /// </summary>
    private IEnumerator FadeOutCoroutine()
    {
        transform.SetParent(null, true);
        trail.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        yield return new WaitForSeconds(maxLifeTime);

        transform.SetParent(parent.transform, false);
        transform.localPosition = initialLocalPos;
        trail.Clear();
        trail.Play();
    }
}
