using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 토스트 메세지 관리자
/// </summary>
public class ToastManager : Singleton<ToastManager>
{
    /// <summary>
    /// 토스트 메세지 띄울 부모 트랜스폼
    /// </summary>
    [SerializeField]
    private Transform toastParent;

    public void ShowToast(string message, float duration = 2f)
    {
        ToastMessageUI toast = Factory.Instance.GetToastMessage();
        toast.transform.SetParent(toastParent.transform);

        toast.Initialize(message, duration);
    }
}
