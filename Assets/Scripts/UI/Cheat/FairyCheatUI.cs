using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FairyCheatUI : MonoBehaviour
{
    /// <summary>
    /// 페어리 셀 프리팹
    /// </summary>
    [SerializeField]
    private GameObject cellPrefab;

    /// <summary>
    /// 페어리 스크롤 컨텐트 트랜스폼
    /// </summary>
    [SerializeField]
    private Transform content;

    /// <summary>
    /// 닫기 버튼
    /// </summary>
    [SerializeField]
    private Button closeBtn;

    /// <summary>
    /// 얻기 버튼
    /// </summary>
    [SerializeField]
    private Button getBtn;

    [SerializeField]
    private TMP_InputField inputField;

    /// <summary>
    /// 모든 페어리 fid들
    /// </summary>
    private List<uint> fids;

    /// <summary>
    /// 선택된 fid
    /// </summary>
    private uint? selectFid = null;

    private void Awake()
    {
        fids = Table_Fairy.Instance.GetTotalFairyId();
    }

    private void Start()
    {
        closeBtn.onClick.AddListener(() => { gameObject.SetActive(false); });
        getBtn.onClick.AddListener(() => { ClickGetBtn(); });

        foreach (uint fid in fids)
        {
            AddItem(fid);
        }
    }

    private void AddItem(uint fid)
    {
        GameObject cell = Instantiate(cellPrefab, content);
        FairyCheatSlotUI slot = cell.GetComponent<FairyCheatSlotUI>();
        slot.RefreshFairySlot(fid);
        slot.onSlotTouch += (fid) => { selectFid = fid; };
    }

    private void ClickGetBtn()
    {
        if (inputField.text == "" || inputField.text == "0")
        {
            // TODO : 토스트 메세지 띄우기
            return;
        }

        if (selectFid == null)
            return;

        void success()
        {
            // TODO : 토스트 메세지 띄우기
            Debug.Log("페어리 치트 얻기 성공");
        }

        if (uint.TryParse(inputField.text, out uint count))
        {
            // TODO : 서버 요청
            if (count < 1000)
                StartCoroutine(ServerData_Fairys.RequestCheatGetFairy(selectFid ?? 0, count, success));
            else
            {
                // TODO : 토스트 메세지 띄우기
            }                
        }
        else
        {
            // TODO : 토스트 메세지 띄우기
        }
    }
}
