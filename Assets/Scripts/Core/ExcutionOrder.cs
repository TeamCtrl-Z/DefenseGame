/// <summary>
/// Awake나 Start같이 생명 주기에서 같은 프레임에서 실행되야 하는것들 중 우선순위 정하기 위한 클래스
/// </summary>
public static class ExcutionOrder
{
    /// <summary>
    /// 데이터 로드용
    /// </summary>
    public const int Load = -100;

    /// <summary>
    /// 데이터 초기화
    /// </summary>
    public const int Init = -50;

    /// <summary>
    /// 데이터 로드, 초기화가 끝난 게임 메인
    /// </summary>
    public const int Main = 0;
}