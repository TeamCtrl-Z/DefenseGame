using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
    /// 토글들을 생성할 그룹
    /// </summary>
    [SerializeField]
    private ToggleGroup toggleGroup;

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

    /// <summary>
    /// 갯수를 적을 input 필드
    /// </summary>
    [SerializeField]
    private TMP_InputField inputField;

    /// <summary>
    /// 모든 페어리 fid들
    /// </summary>
    private List<uint> fids;

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

        Toggle toggle = cell.GetComponent<Toggle>();
        toggle.group = toggleGroup;

        FairyCheatSlotUI slot = cell.GetComponent<FairyCheatSlotUI>();
        slot.RefreshFairySlot(fid);
    }

    private void ClickGetBtn()
    {
        var selected = toggleGroup.ActiveToggles().FirstOrDefault();
        var slot = selected.GetComponent<FairyCheatSlotUI>();
    
        if (inputField.text == "" || inputField.text == "0")
        {
            // TODO : 토스트 메세지 띄우기
            return;
        }

        if (slot == null)
            return;

        void success()
        {
            // TODO : 토스트 메세지 띄우기
            ToastManager.Instance.ShowToast($"{Table_Fairy.Instance.GetFairyName(slot.FID)} 페어리를 얻었습니다.");
        }

        if (uint.TryParse(inputField.text, out uint count))
        {
            // TODO : 서버 요청
            if (count < 1000)
                StartCoroutine(ServerData_Fairys.RequestCheatGetFairy(slot.FID, count, success));
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
