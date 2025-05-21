using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T>
{
    /// <summary>
    /// ������Ʈ�� ������ �����ִ� ����
    /// </summary>
    private T sender;

    /// <summary>
    /// ������Ʈ�� ���� ���¸� �����ϴ� ������Ƽ
    /// </summary>
    public IState<T> Current { get; private set; }

    /// <summary>
    /// ������
    /// </summary>
    /// <param name="sender">������Ʈ</param>
    /// <param name="defaultState">�ʱ� ����</param>
    public StateMachine(T sender, IState<T> defaultState)
    {
        this.sender = sender;
        Current = defaultState;
        Current.Enter(sender);  // �ʱ� ������ Enter()�Լ� ����
    }

    /// <summary>
    /// ���°� ��ȯ�� �� ����Ǵ� �Լ�
    /// </summary>
    /// <param name="nextState">���� ����</param>
    public void TransitionTo(IState<T> nextState)
    {
        // ��ȯ�Ǳ� �� ������ Exit() ����
        Current.Exit(sender);

        // �ٲ� ���·� ��ȭ
        Current = nextState;

        // �ٲ� ������ Enter() ����
        Current.Enter(sender);
    }

    /// <summary>
    /// �� ���º� Update �Լ�
    /// </summary>
    public void Update()
    {
        if (Current != null)
        {
            Current.UpdateState(sender);
        }
    }
}
