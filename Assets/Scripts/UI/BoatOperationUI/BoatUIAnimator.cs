using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

/// <summary>
/// BoatUI 애니메이터 클래스
/// </summary>

public class BoatUIAnimator : MonoBehaviour
{
    /// <summary>
    /// 보트 이미지
    /// </summary>
    private Image targetImage;

    /// <summary>
    /// 주소 key
    /// </summary>
    private string addressKey = "Background/Boat";

    /// <summary>
    /// 애니메이션 개수
    /// </summary>
    private float frameRate = 17f;

    /// <summary>
    /// 애니메이션 스프라이트들
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
    /// 성공적으로 불러왔으면 true, 아니면 false
    /// </summary>
    private bool isReady = false;

    private void Start()
    {
        targetImage = GetComponent<Image>();
        Addressables.LoadAssetAsync<Sprite[]>(addressKey).Completed += OnSpritesLoaded;
    }

    /// <summary>
    /// Addressables를 이용해서 스프라이트들을 불러오는 함수
    /// </summary>
    /// <param name="handle">불러온 handle</param>
    private void OnSpritesLoaded(AsyncOperationHandle<Sprite[]> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            frames = handle.Result;
            if (frames.Length > 0)
            {
                currentFrame = 0;
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
