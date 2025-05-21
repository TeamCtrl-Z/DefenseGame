public interface IState<T>
{
    /// <summary>
    /// ���¿� ���� �� �����ϴ� �Լ�
    /// </summary>
    public void Enter(T sender);

    /// <summary>
    /// ���� ���� �� �����ϴ� �Լ�
    /// </summary>
    public void UpdateState(T sender);

    /// <summary>
    /// ���¿��� �ٸ� ���·� �Ѿ �� �����ϴ� �Լ�
    /// </summary>
    public void Exit(T sender);
}
