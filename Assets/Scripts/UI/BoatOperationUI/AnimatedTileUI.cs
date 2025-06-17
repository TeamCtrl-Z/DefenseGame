using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections;

/// <summary>
/// 타일에 애니메이션을 보여주는 UI
/// </summary>
public class AnimatedTileUI : MonoBehaviour
{
    /// <summary>
    /// Tile 이미지
    /// </summary>
    private Image targetImage;

    /// <summary>
    /// 타일 배경 주소
    /// </summary>
    private string addressKey = "Background/Tile";

    /// <summary>
    /// 타일 개수
    /// </summary>
    private float frameRate = 8f;

    /// <summary>
    /// 타일 스프라이트들
    /// </summary>
    private Sprite[] frames;

    /// <summary>
    /// 현재 프레임
    /// </summary>
    private int currentFrame = 0;

    /// <summary>
    /// 현재 시간
    /// </summary>
    private float timer = 0f;

    /// <summary>
    /// 스프라이트들을 성공적으로 불러왔는지 확인하는 변수
    /// (true면 성공적으로 불러옴, false면 불러오지 못함)
    /// </summary>
    private bool isReady = false;

    private void Awake()
    {
        targetImage = GetComponent<Image>();
    }

    private void Start()
    {
        Addressables.LoadAssetAsync<Sprite[]>(addressKey).Completed += OnSpritesLoaded;
    }

    /// <summary>
    /// 스프라이트를 주소로 불러오는 함수
    /// </summary>
    /// <param name="handle">스프라이트를 불러오는 함수</param>
    private void OnSpritesLoaded(AsyncOperationHandle<Sprite[]> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            frames = handle.Result;
            if (frames.Length > 0)
            {
                currentFrame = Random.Range(0, frames.Length);
                targetImage.sprite = frames[currentFrame];
                isReady = true;
            }
        }
    }

    private void Update()
    {
        if (!isReady || frames == null || frames.Length == 0) return;

        timer += Time.deltaTime;
        if (timer >= 1f / frameRate)
        {
            timer = 0f;
            currentFrame = (currentFrame + 1) % frames.Length;
            targetImage.sprite = frames[currentFrame];
        }
    }
}
