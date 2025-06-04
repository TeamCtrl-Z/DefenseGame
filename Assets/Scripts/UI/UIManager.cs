using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI관리 클래스
/// </summary>
public class UIManager : Singleton<UIManager>
{
    /// <summary>
    /// 배경 테두리 로고를 위한 캔버스
    /// </summary>
    public Canvas StaticHUD;

    /// <summary>
    /// HP바, 테두리 같은 많이 바뀌는 UI를 위한 캔버스
    /// </summary>
    public Canvas DynamicHUD;

    /// <summary>
    /// 팝업창을 위한 캔버스
    /// </summary>
    public Canvas WindowPopups;

    /// <summary>
    /// 화면 전체를 덮을 이펙트 효과를 위한 캔버스
    /// </summary>
    public Canvas FullScreenEffects;

    protected override void OnPreInitialize()
    {
        base.OnPreInitialize();

        if (StaticHUD == null)
        {
            if (transform.TryFindByName("Canvas_StaticHUD", out Transform t))
            {
                StaticHUD = t.GetComponent<Canvas>();
            }
        }

        if (DynamicHUD == null)
        {
            if (transform.TryFindByName("Canvas_DynamicHUD", out Transform t))
            {
                DynamicHUD = t.GetComponent<Canvas>();
            }
        }

        if (WindowPopups == null)
        {
            if (transform.TryFindByName("Canvas_WindowPopups", out Transform t))
            {
                WindowPopups = t.GetComponent<Canvas>();
            }
        }

        if (FullScreenEffects == null)
        {
            if (transform.TryFindByName("Canvas_FullscreenEffects", out Transform t))
            {
                FullScreenEffects = t.GetComponent<Canvas>();
            }
        }
    }
}
