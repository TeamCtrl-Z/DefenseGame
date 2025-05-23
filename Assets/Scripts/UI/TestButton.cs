using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    [SerializeField] private NodeObject nodeObject;

    public void OnPlaceClick()
    {
        FairyController fairy = Factory.Instance.GetFairy(Vector2.zero, 0.0f);
        nodeObject.PlaceNode(fairy);
    }
}
