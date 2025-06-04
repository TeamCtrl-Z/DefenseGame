/// <summary>
/// 상태 패턴을 구현하기 위한 인터페이스
/// </summary>
/// <typeparam name="T">상태를 가질 Class</typeparam>
public interface IState<T>
{
    /// <summary>
    /// 상태에 들어갔을 때 실행하는 함수
    /// </summary>
    public void Enter(T sender);

    /// <summary>
    /// 상태 중일 때 실행하는 함수
    /// </summary>
    public void UpdateState(T sender);

    /// <summary>
    /// 상태에서 다른 상태로 넘어갈 때 실행하는 함수
    /// </summary>
    public void Exit(T sender);
}
