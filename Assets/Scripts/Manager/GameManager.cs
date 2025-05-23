using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
    /// 씬이 로드될때마다 실행하는 함수(Additive 제외)
    /// </summary>
    protected override void OnInitialize()
    {
        base.OnInitialize();

        inputManager = GetComponent<InputManager>();
        inputManager.Initialize();

        containerManager = GetComponent<ContainerManager>();
        containerManager.Initialize();
    }
}
