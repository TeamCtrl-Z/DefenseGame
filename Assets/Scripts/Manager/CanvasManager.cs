using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class CanvasManager : Singleton<CanvasManager>
{
    /// <summary>
    /// Static HUD
    /// </summary>
    [SerializeField]
    private Canvas StaticHUD;

    /// <summary>
    /// Dynamic HUD
    /// </summary>
    [SerializeField]
    private Canvas DynamicHUD;

    /// <summary>
    /// Window Popups
    /// </summary>
    [SerializeField]
    private Canvas WindowPopups;

    /// <summary>
    /// 현재 Canvas
    /// </summary>
    private bool isWindowPopups = true;

    /// <summary>
    /// 현재 Canvas를 바꿔주는 프로퍼티
    /// </summary>
    public bool IsWindowPopups
    {
        get => isWindowPopups;
        set
        {
            if (isWindowPopups != value)
            {

                isWindowPopups = value;
                WindowPopups.gameObject.SetActive(isWindowPopups);
                StaticHUD.gameObject.SetActive(!isWindowPopups);
                DynamicHUD.gameObject.SetActive(!isWindowPopups);
            }
        }
    }

    private void Start()
    {
        IsWindowPopups = false;
    }
}
