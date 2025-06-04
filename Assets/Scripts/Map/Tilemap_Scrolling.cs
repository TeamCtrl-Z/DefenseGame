using UnityEngine;

/// <summary>
/// 배경(타일맵)을 스크롤링하는 클래스
/// </summary>
public class Tilemap_Scrolling : MonoBehaviour
{
    /// <summary>
    /// 슬롯들의 이동 속도
    /// </summary>
    public float scrollingSpeed = 3.0f;

    /// <summary>
    /// 슬롯하나의 가로 길이
    /// </summary>
    public float slotWidth;

    /// <summary>
    /// 배경 슬롯
    /// </summary>
    public Transform[] bgSlots;

    /// <summary>
    /// 오른쪽으로 넘어가기 전 기준점
    /// </summary>
    protected float baseLineX;

    private void Awake()
    {
        baseLineX = transform.position.x - slotWidth;
    }

    private void Update()
    {
        for (int i = 0; i < bgSlots.Length; i++)
        {
            bgSlots[i].Translate(Time.deltaTime * scrollingSpeed * -transform.right);
            if (bgSlots[i].position.x < baseLineX)
            {
                MoveRightEnd(i);
            }
        }
    }

    /// <summary>
    /// 오른쪽 끝으로 슬롯을 이동시키는 함수
    /// </summary>
    /// <param name="index">이동시킬 슬롯의 인덱스</param>
    private void MoveRightEnd(int index)
    {
        bgSlots[index].Translate(slotWidth * bgSlots.Length * transform.right);
    }
}
