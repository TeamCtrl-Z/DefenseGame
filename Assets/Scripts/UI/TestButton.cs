using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    [SerializeField] private NodeObject nodeObject;
    [SerializeField] private Vector2 enemyTypeRange;
    private Dictionary<FairyType, Func<FairyController>> fairySelect = new();

    void Awake()
    {
        fairySelect[FairyType.Basic] = () => Factory.Instance.GetFairyBasic(Vector2.zero, 0.0f);
        fairySelect[FairyType.Fire] = () => Factory.Instance.GetFariyFire(Vector2.zero, 0.0f);
        fairySelect[FairyType.Poison] = () => Factory.Instance.GetFariyPoison(Vector2.zero, 0.0f);
        fairySelect[FairyType.Light] = () => Factory.Instance.GetFariyLight(Vector2.zero, 0.0f);
        fairySelect[FairyType.Freeze] = () => Factory.Instance.GetFariyFreeze(Vector2.zero, 0.0f);
        fairySelect[FairyType.Frozen] = () => Factory.Instance.GetFariyFrozen(Vector2.zero, 0.0f);
        // for (int i = 0; i < (int)FairyType.Max; i++)
        // {
        //     fairySelect[(FairyType)i] = () => Factory.Instance.GetFariyByType((FairyType)i, Vector2.zero, 0.0f);
        // }
    }

    public void OnPlaceClick()
    {
        int key = UnityEngine.Random.Range(Mathf.RoundToInt(enemyTypeRange.x), Mathf.RoundToInt(enemyTypeRange.y) + 1);
        Debug.Log(key);
        FairyController fairy = fairySelect[(FairyType)key]?.Invoke();
        PlaceableObject placeable = fairy.GetComponent<PlaceableObject>();
        nodeObject.PlaceNode(placeable);
    }

    public void OnStartClick()
    {
        GameManager.Instance.ChapterManager.StartStage();
    }
}
