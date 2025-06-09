using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Boat의 HP UI
/// </summary>
public class BoatHPUI : MonoBehaviour
{
    /// <summary>
    /// 보트 HP 슬라이더
    /// </summary>
    [SerializeField]
    private Slider boatHPSlider;

    /// <summary>
    /// 보스 Text
    /// </summary>
    [SerializeField]
    private TextMeshProUGUI hpText;

    /// <summary>
    /// 보트 Status
    /// </summary>
    private BoatStatusComponent boatStatus;

    private void Start()
    {
        boatStatus = GameManager.Instance.ContainerManager.BoatNodeContainer.GetComponent<BoatStatusComponent>();
        boatStatus.OnHPChanged += RefreshBoatHPUI;

        RefreshBoatHPUI(1f);
    }

    /// <summary>
    /// 보트 HP UI를 업데이트하는 함수
    /// </summary>
    private void RefreshBoatHPUI(float amount)
    {
        boatHPSlider.value = amount;
        hpText.text = $"{boatStatus.CurrentHP} / {boatStatus.MaxHP}";
    }
}
