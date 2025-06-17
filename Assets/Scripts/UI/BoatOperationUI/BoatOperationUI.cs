using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 보트 운용창 UI
/// </summary>
public class BoatOperationUI : MonoBehaviour
{
    /// <summary>
    /// 보트 운용UI CG
    /// </summary>
    public CanvasGroup BoatOpertaionCG { get; private set; }

    private void Awake()
    {
        BoatOpertaionCG = GetComponent<CanvasGroup>();
    }
}
