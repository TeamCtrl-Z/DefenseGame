using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 보트 운용창 UI
/// </summary>
public class BoatOperationUI : MonoBehaviour
{
    /// <summary>
    /// 페어리 정보창 버튼(누르면 닫힘)
    /// </summary>
    [field: SerializeField]
    public Button FairyInfoButton { get; private set; }

    /// <summary>
    /// 보트 운용창 버튼
    /// </summary>
    [field: SerializeField]
    public Button BoatOperationButton { get; private set; }

    /// <summary>
    /// 소환할 페어리 타입(fid)
    /// </summary>
    [SerializeField] private FairyType fairyType;

    /// <summary>
    /// 페어리 소환 버튼(임시)
    /// </summary>
    [SerializeField]
    private Button fairySummonButton;

    /// <summary>
    /// 페어리 배치 확정 버튼(임시)
    /// </summary>
    [field: SerializeField]
    public Button AssignButton { get; private set; }

    /// <summary>
    /// 보트 운용UI CG
    /// </summary>
    public CanvasGroup BoatOpertaionCG { get; private set; }

    private void Awake()
    {
        BoatOpertaionCG = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        FairyInfoButton.onClick.AddListener(() =>
        {
            UIManager.Instance.FadeUI.Fade(() =>
            {
                UIUtility.ClosePopupUIWithCanvasGroup(BoatOpertaionCG);
                UIUtility.OpenPopupUIWithCanvasGroup(UIManager.Instance.FairyInfo.FairyInfoCG);
            });
        });

        BoatOperationButton.onClick.AddListener(() =>
        {
            UIManager.Instance.FadeUI.Fade(() =>
            {
                UIUtility.ClosePopupUIWithCanvasGroup(BoatOpertaionCG);
            });
        });

        AssignButton.onClick.AddListener(() => { ClickAssginButton(); });
        fairySummonButton.onClick.AddListener(() => { ClickFairySummonButton(); });
    }

    private void ClickAssginButton()
    {
        Dictionary<uint, string> assignedfairys = new();

        for (uint i = 0; i < GameManager.Instance.ContainerManager.BoatNodeContainerUI.NodeCount; i++)
        {
            FairyUI fairy = GameManager.Instance.ContainerManager.BoatNodeContainerUI[i].Fairy as FairyUI;
            if (fairy != null)
                assignedfairys[i] = fairy.FOID;
        }

        void success()
        {
            ToastManager.Instance.ShowToast("페어리 배치 성공!");
        }

        ServerData_Ships.RequestAssignFairys(assignedfairys, success);
    }

    private void ClickFairySummonButton()
    {
        FairyUI fairy = DataService.Instance.FairyDataManager.SpawnFairyUIByFid((uint)fairyType, Vector2.zero);
        PlaceableObject placeable = fairy.GetComponent<PlaceableObject>();
        int nodeIdx;
        do
        {
            // 0~9 범위에서 랜덤 인덱스 생성
            nodeIdx = UnityEngine.Random.Range(0, 9);
        }
        // 비어 있는 노드(IsEmpty == true)를 찾을 때까지 반복
        while (!GameManager.Instance.ContainerManager.BoatNodeContainerUI[(uint)nodeIdx].IsEmpty);

        Debug.Log($"ClickFairySummonButton : {nodeIdx}, {GameManager.Instance.ContainerManager.BoatNodeContainerUI[(uint)nodeIdx]}");

        // 최종으로 뽑힌 인덱스의 노드에 PlaceNode 호출
        GameManager.Instance.ContainerManager.BoatNodeContainerUI[(uint)nodeIdx]
            .PlaceNode(placeable);
    }
}
