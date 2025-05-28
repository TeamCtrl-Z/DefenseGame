using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObject : MonoBehaviour, IPlaceable
{
    /// <summary>
    /// 페어리를 배치하는 함수
    /// </summary>
    /// <param name="placePosition"> 배치할 위치 </param>
    public void Place(Vector2 placePosition)
    {
        transform.position = placePosition;
    }
}
