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

public static class UIUtility
{
    public static IEnumerator OpenPopupUIWithCanvasGroup(CanvasGroup cg)
    {
        cg.gameObject.SetActive(true);
        float timeElapsed = 0.0f;

        while (timeElapsed < 0.2f)
        {
            timeElapsed += Time.deltaTime;
            cg.alpha = timeElapsed * 5;
            yield return null;
        }

        cg.alpha = 1f;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    public static IEnumerator ClosePopupUIWithCanvasGroup(CanvasGroup cg)
    {
        float timeElapsed = 0.2f;

        while (timeElapsed > 0f)
        {
            timeElapsed -= Time.deltaTime;
            cg.alpha = timeElapsed * 5;
            yield return null;
        }

        cg.alpha = 0f;
        cg.interactable = false;
        cg.blocksRaycasts = false;
        cg.gameObject.SetActive(false);
    }
}