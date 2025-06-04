using System.Collections;
using UnityEngine;

public class AttributeManager : MonoBehaviour
{
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

    private IEnumerator IntervalRoutine(IOnIntervalEffect attribute, float interval)
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            attribute.OnInterval();   
        }
    }
}