using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI 배경 타일 3개를 무한 스크롤링하는 클래스
/// </summary>
public class UIBackgroundScroller : MonoBehaviour
{
    /// <summary>
    /// Tilemap 이동 속도
    /// </summary>
    [SerializeField]
    private float scrollingSpeed = 100f;

    /// <summary>
    /// 배경 슬롯들
    /// </summary>
    [SerializeField]
    private RectTransform[] bgSlots;

    /// <summary>
    /// 슬롯 넓이
    /// </summary>
    private float slotWidth;

    /// <summary>
    /// 기본 X 길이
    /// </summary>
    private float baseLineX;

    private void Start()
    {
        slotWidth = bgSlots[0].rect.width;
        baseLineX = -slotWidth;
    }

    private void Update()
    {
        for (int i = 0; i < bgSlots.Length; i++)
        {
            Vector2 pos = bgSlots[i].anchoredPosition;
            pos.x -= scrollingSpeed * Time.deltaTime;
            bgSlots[i].anchoredPosition = pos;

            if (pos.x < baseLineX)
            {
                MoveToRightEnd(i);
            }
        }
    }

    /// <summary>
    /// 뢴쪽 끝에 다다르면 오른쪽 끝으로 옮기는 함수
    /// </summary>
    /// <param name="index">옮기는 슬롯 번호</param>
    private void MoveToRightEnd(int index)
    {
        float rightMostX = GetRightmostSlotX();
        Vector2 pos = bgSlots[index].anchoredPosition;
        pos.x = rightMostX + slotWidth;
        bgSlots[index].anchoredPosition = pos;
    }

    /// <summary>
    /// 맨 오른쪽 슬롯 번호를 반환하는 함수
    /// </summary>
    /// <returns>오른쪽 슬롯 번호</returns>
    private float GetRightmostSlotX()
    {
        float maxX = float.MinValue;
        for (int i = 0; i < bgSlots.Length; i++)
        {
            float x = bgSlots[i].anchoredPosition.x;
            if (x > maxX)
                maxX = x;
        }
        return maxX;
    }
}
