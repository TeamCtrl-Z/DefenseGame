using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerManager : MonoBehaviour, IInitialize
{
    /// <summary>
    /// 배의 노드 컨테이너
    /// </summary>
    [SerializeField]
    private NodeContainerObject boatNodeContainer;

    /// <summary>
    /// 초기화 하는 함수
    /// </summary>
    public void Initialize()
    {
        boatNodeContainer.InitializeNodeContainer();
    }
}
