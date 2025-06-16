using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// 페어리 정렬 드롭다운 클래스
/// </summary>
public class SortingFairyUI : MonoBehaviour
{
    /// <summary>
    /// 페어리 인포 드롭 다운
    /// </summary>
    private TMP_Dropdown dropDown;

    /// <summary>
    /// 드롭다운 인덱스가 바뀌면 실행되는 이벤트
    /// </summary>
    public event Action<FairySortCriteiria, bool> onSortingChanged;

    private void Awake()
    {
        dropDown = GetComponent<TMP_Dropdown>();
    }

    private void Start()
    {
        dropDown.onValueChanged.AddListener(OnDropdownChanged);
    }

    /// <summary>
    /// 드롭 다운에서 값을 변경하는 함수
    /// </summary>
    /// <param name="index">드롭 다운 인덱스</param>
    private void OnDropdownChanged(int index)
    {
        switch (index)
        {
            case 0:
                onSortingChanged?.Invoke(FairySortCriteiria.Number, true);
                break;

            case 1:
                onSortingChanged?.Invoke(FairySortCriteiria.Number, false);
                break;

            case 2:
                onSortingChanged?.Invoke(FairySortCriteiria.Grade, true);
                break;

            case 3:
                onSortingChanged?.Invoke(FairySortCriteiria.Grade, false);
                break;

            case 4:
                onSortingChanged?.Invoke(FairySortCriteiria.Level, true);
                break;

            case 5:
                onSortingChanged?.Invoke(FairySortCriteiria.Level, false);
                break;

            case 6:
                onSortingChanged?.Invoke(FairySortCriteiria.CompoundLevel, true);
                break;

            case 7:
                onSortingChanged?.Invoke(FairySortCriteiria.CompoundLevel, false);
                break;
        }
    }
}
