/// <summary>
/// 각종 매니저를 관리하는 게임 매니저
/// </summary>
public class GameManager : Singleton<GameManager>
{
    /// <summary>
    /// InputManager
    /// </summary>
    private InputManager inputManager;

    /// <summary>
    /// ContainerManager
    /// </summary>
    private ContainerManager containerManager;

    /// <summary>
    /// ChapterManager
    /// </summary>
    private ChapterManager chapterManager;

    /// <summary>
    /// InputManager를 반환하는 프로퍼티(읽기 전용)
    /// </summary>
    public InputManager InputManager
    {
        get 
        {
            if (inputManager == null)
                inputManager = GetComponent<InputManager>();
            return inputManager;
        }
    }

    /// <summary>
    /// ContainerManager를 반환하는 프로퍼티(읽기 전용)
    /// </summary>
    public ContainerManager ContainerManager
    {
        get
        {
            if (containerManager == null)
                containerManager = GetComponent<ContainerManager>();
            return containerManager;
        }
    }

    /// <summary>
    /// ChapterManager를 반환하는 프로퍼티(읽기 전용)
    /// </summary>
    public ChapterManager ChapterManager
    {
        get
        {
            if (chapterManager == null)
                chapterManager = GetComponent<ChapterManager>();
            return chapterManager;
        }
    }

    /// <summary>
    /// 씬이 로드될때마다 실행하는 함수(Additive 제외)
    /// </summary>
    protected override void OnInitialize()
    {
        base.OnInitialize();

        inputManager = GetComponent<InputManager>();
        inputManager.Initialize();

        containerManager = GetComponent<ContainerManager>();
        containerManager.Initialize();

        chapterManager = GetComponent<ChapterManager>();
        chapterManager.Initialize();
    }
}
