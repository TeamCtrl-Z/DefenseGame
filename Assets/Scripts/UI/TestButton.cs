using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TestButton : MonoBehaviour
{
    [SerializeField] private NodeObject nodeObject;
    [SerializeField] private Vector2 enemyTypeRange;
    private int count = 0;

    public void OnPlaceClick()
    {
        if (count >= 8) return;
        int key = UnityEngine.Random.Range(Mathf.RoundToInt(enemyTypeRange.x), Mathf.RoundToInt(enemyTypeRange.y) + 1);
        Debug.Log(key);
        FairyController fairy = Factory.Instance.GetFariyByType((FairyType)key, Vector2.zero);
        PlaceableObject placeable = fairy.GetComponent<PlaceableObject>();
        int nodeIdx;
        do
        {
            // 0~9 범위에서 랜덤 인덱스 생성
            nodeIdx = UnityEngine.Random.Range(0, 9);
        }
        // 비어 있는 노드(IsEmpty == true)를 찾을 때까지 반복
        while (!GameManager.Instance.ContainerManager.BoatNodeContainer[(uint)nodeIdx].IsEmpty);

        // 최종으로 뽑힌 인덱스의 노드에 PlaceNode 호출
        GameManager.Instance.ContainerManager.BoatNodeContainer[(uint)nodeIdx]
            .PlaceNode(placeable);
        count++;
    }

    public void OnStartClick()
    {
        GameManager.Instance.ChapterManager.StartStage(currentChapterIndex, currentStageIndex);
    }
}
