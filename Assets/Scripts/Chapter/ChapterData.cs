using UnityEngine;

/// <summary>
/// 챕터 데이터를 담는 ScriptableObject 클래스
/// </summary>
[CreateAssetMenu(fileName = "NewChapter", menuName = "Game/ChapterData")]
public class ChapterData : ScriptableObject
{
    /// <summary>
    /// 챕터 이름
    /// </summary>
    public string chapterName;

    /// <summary>
    /// 한 챕터에 포함된 스테이지들의 데이터를 담은 배열
    /// </summary>
    public StageData[] stages = new StageData[20];
}