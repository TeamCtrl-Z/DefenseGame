using UnityEngine;

/// <summary>
/// 챕터 데이터를 담는 ScriptableObject 클래스
/// </summary>
[CreateAssetMenu(fileName = "NewChapter", menuName = "Game/ChapterData")]
public class ChapterData : ScriptableObject
{
    /// <summary>
    /// 챕터 고유 아이디
    /// </summary>
    public uint ChapterID;

    /// <summary>
    /// 챕터 이름
    /// </summary>
    public string chapterName;

    /// <summary>
    /// 챕터 클리어 여부
    /// </summary>
    public bool isClear = false;

    /// <summary>
    /// 챕터 클리어 보상(Gold)
    /// </summary>
    public ulong reward_Gold;

    /// <summary>
    /// 챕터 클리어 보상(Gem)
    /// </summary>
    public ulong reward_Gem;

    /// <summary>
    /// 한 챕터에 포함된 스테이지들의 데이터를 담은 배열
    /// </summary>
    public StageData[] stages = new StageData[20];
}