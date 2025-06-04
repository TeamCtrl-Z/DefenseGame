using System.Collections;
using UnityEngine;

/// <summary>
/// Attribute를 관리하는 컴포넌트 클래스
/// </summary>
public class AttributeManager : MonoBehaviour
{
    /// <summary>
    /// 현재 페어리 속성
    /// </summary>
    [SerializeField] private AttributeBase attribute;

    private void Awake()
    {
        attribute = Instantiate(attribute);
    }

    private void OnEnable()
    {
        attribute.Initialize(this.gameObject);

        if (attribute is IOnHitEffect hitAttribute)
        {
            AttackHandler attack = GetComponent<AttackHandler>();
            attack.OnHit -= hitAttribute.OnHit;
            attack.OnHit += hitAttribute.OnHit;
        }

        if (attribute is IOnIntervalEffect intervalAttribute)
        {
            StartCoroutine(IntervalRoutine(intervalAttribute, intervalAttribute.Interval));
        }

        if (attribute is IOnMergeEffect mergeAttribute)
        {

        }
    }

    /// <summary>
    /// 일정 시간마다 속성을 발현하기 위한 코루틴 함수
    /// </summary>
    /// <param name="attribute"> 속성 </param>
    /// <param name="interval"> 간격 </param>
    /// <returns></returns>
    private IEnumerator IntervalRoutine(IOnIntervalEffect attribute, float interval)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            attribute.OnInterval();
        }
    }
}