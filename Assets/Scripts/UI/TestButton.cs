using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    [SerializeField] private NodeObject nodeObject;
    private Dictionary<int, Func<FairyController>> fairySelect = new();

    void Awake()
    {
        fairySelect[0] = () => Factory.Instance.GetFairyBasic(Vector2.zero, 0.0f);
        fairySelect[1] = () => Factory.Instance.GetFariyFire(Vector2.zero, 0.0f);
        fairySelect[2] = () => Factory.Instance.GetFariyPoison(Vector2.zero, 0.0f);
        fairySelect[3] = () => Factory.Instance.GetFariyLight(Vector2.zero, 0.0f);
    }

    public void OnPlaceClick()
    {
        int key = UnityEngine.Random.Range(0, 4);
        Debug.Log(key);
        FairyController fairy = fairySelect[key]?.Invoke();
        PlaceableObject placeable = fairy.GetComponent<PlaceableObject>();
        nodeObject.PlaceNode(placeable);
    }
}
