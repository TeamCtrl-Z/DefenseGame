using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public static class AddressableUtility
{
    /// <summary>
    /// 주소 별 Sprite 캐싱
    /// </summary>
    private static Dictionary<string, Sprite> _spriteCache = new();

    /// <summary>
    /// 주소로 스프라이트를 불러오는 함수
    /// </summary>
    /// <param name="address">불러올 주소</param>
    /// <param name="targetImage">스프라이트를 저장할 이미지 컴포넌트</param>
    public static void LoadSpriteByAddress(string address, Image targetImage)
    {
        if (_spriteCache.TryGetValue(address, out var cachedSprite))
        {
            targetImage.sprite = cachedSprite;
            return;
        }

        Addressables.LoadAssetAsync<Sprite>(address).Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                Sprite loadedSprite = handle.Result;
                _spriteCache[address] = loadedSprite;
                targetImage.sprite = loadedSprite;
            }
            else
            {
                Debug.LogError($"[Addressables] Sprite 로드 실패: {address}");
            }
        };
    }
}

/// <summary>
/// UI를 켜고 끄는 메서드를 제공하는 클래스
/// </summary>
public static class UIUtility
{
    /// <summary>
    /// UI를 켜는 메서드
    /// </summary>
    /// <param name="cg">해당 UI의 CanvasGroup</param>
    public static void OpenPopupUIWithCanvasGroup(CanvasGroup cg)
    {
        CanvasManager.Instance.IsWindowPopups = true;
        cg.alpha = 1f;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    /// <summary>
    /// UI를 끄는 메서드
    /// </summary>
    /// <param name="cg">해당 UI의 CanvasGroup</param>
    public static void ClosePopupUIWithCanvasGroup(CanvasGroup cg)
    {
        cg.blocksRaycasts = false;
        cg.interactable = false;
        cg.alpha = 0f;
        CanvasManager.Instance.IsWindowPopups = false;
    }
}

/// <summary>
/// UI를 켜고 끄는 메서드를 제공하는 클래스
/// </summary>
public static class CheatUIUtility
{
    /// <summary>
    /// UI를 켜는 메서드
    /// </summary>
    /// <param name="cg">해당 UI의 CanvasGroup</param>
    public static void OpenPopupUIWithCanvasGroup(CanvasGroup cg)
    {
        cg.gameObject.SetActive(true);
        cg.alpha = 1f;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    /// <summary>
    /// UI를 끄는 메서드
    /// </summary>
    /// <param name="cg">해당 UI의 CanvasGroup</param>
    public static void ClosePopupUIWithCanvasGroup(CanvasGroup cg)
    {
        cg.blocksRaycasts = false;
        cg.interactable = false;
        cg.alpha = 0f;
        cg.gameObject.SetActive(false);
    }
}