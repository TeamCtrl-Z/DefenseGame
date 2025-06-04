using UnityEngine;

/// <summary>
/// 노드 컨테이너들을 관리하는 매니저
/// </summary>
public class ContainerManager : MonoBehaviour, IInitialize
{
    /// <summary>
    /// 배의 노드 컨테이너
    /// </summary>
    [SerializeField]
    private NodeContainerObject boatNodeContainer;

    /// <summary>
    /// 배의 노드 컨테이너를 가져오는 프로퍼티
    /// </summary>
    public NodeContainerObject BoatNodeContainer => boatNodeContainer;

    /// <summary>
    /// 초기화 하는 함수
    /// </summary>
    public void Initialize()
    {
        boatNodeContainer.InitializeNodeContainer();
    }
}
