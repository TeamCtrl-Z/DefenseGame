using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleObject : MonoBehaviour
{
    /// <summary>
    /// ��Ȱ�� ������Ʈ�� ��Ȱ��ȭ �� �� ����Ǵ� ��������Ʈ
    /// </summary>
    public Action onDisable = null;

    protected virtual void OnEnable()
    {
        StopAllCoroutines();    // ������ ���� ���̴� �ڷ�ƾ ��� ����

        OnReset();              // �� Ŭ������ ���� ó��
    }

    protected virtual void OnDisable()
    {
        onDisable?.Invoke();    // onDisable�� null�� �ƴϸ� �����϶�
    }

    /// <summary>
    /// ��Ȱ�� �ɋ� ó���Ǵ� �Լ�(�� �Լ�)
    /// </summary>
    protected virtual void OnReset()
    {

    }

    /// <summary>
    /// ���� �ð� �Ŀ� ���ӿ�����Ʈ�� �ڵ����� ��Ȱ��ȭ��Ű�� �Լ�
    /// </summary>
    /// <param name="time">��ٸ� �ð�</param>
    protected void DisableTimer(float time = 0.0f)
    {
        StartCoroutine(LifeOver(time));
    }

    IEnumerator LifeOver(float time = 0.0f)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
