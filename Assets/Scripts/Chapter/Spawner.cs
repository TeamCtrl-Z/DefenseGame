using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    /// <summary>
    /// 챕터 매니저
    /// </summary>
    private ChapterManager chapterManager;

    private void Start()
    {
        chapterManager = GameManager.Instance.ChapterManager;
    }

    private void StartLobySpawn()
    {

    }
}
