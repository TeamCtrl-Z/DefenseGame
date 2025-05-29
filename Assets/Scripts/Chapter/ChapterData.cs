using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewChapter", menuName = "Game/ChapterData")]
public class ChapterData : ScriptableObject
{
    /// <summary>
    /// 한 챕터에 포함된 스테이지들의 데이터를 담은 배열
    /// </summary>
    public StageData[] stages = new StageData[20];
}