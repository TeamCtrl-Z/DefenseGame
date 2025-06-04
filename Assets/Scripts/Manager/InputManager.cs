using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 인풋 매니저 클래스(Android에서의 드래그 및 터치 이벤트를 처리)
/// </summary>
public class InputManager : MonoBehaviour, IInitialize
{
    /// <summary>
    /// 드래그가 시작되면 실행되는 델리게이트
    /// </summary>
    public event Action<Vector2> onDragStart;

    /// <summary>
    /// 드래그가 끝나면 실행되는 델리게이트
    /// </summary>
    public event Action<Vector2> onDragEnd;

    /// <summary>
    /// 화면을 터치하면 실행되느 델리게이트
    /// </summary>
    public event Action<Vector3> onTouch;

    /// <summary>
    /// 인풋 액션
    /// </summary>
    private InputActions action;

    /// <summary>
    /// 초기화 하는 함수(씬이 로드 될때마다 실행될 예정)
    /// </summary>
    public void Initialize()
    {
        action = new InputActions();

        action.Enable();
        action.GameInput.Touch.performed += OnTouch;
        action.GameInput.Drag.started += OnDragStart;
        action.GameInput.Drag.canceled += OnDragEnd;
    }

    private void OnDisable()
    {
        action.GameInput.Drag.canceled -= OnDragEnd;
        action.GameInput.Drag.started -= OnDragStart;
        action.GameInput.Touch.performed -= OnTouch;
        action.Disable();
    }

    /// <summary>
    /// 화면 터치하면 실행되는 함수
    /// </summary>
    /// <param name="obj"></param>
    private void OnTouch(InputAction.CallbackContext obj)
    {
        onTouch?.Invoke(obj.ReadValue<Vector2>());
    }

    /// <summary>
    /// 드래그를 시작하면 실행되는 델리게이트
    /// </summary>
    /// <param name="obj"></param>
    private void OnDragStart(InputAction.CallbackContext obj)
    {
        onDragStart?.Invoke(obj.ReadValue<Vector2>());
    }

    /// <summary>
    /// 드래그가 끝날 때 실행되는 델리게이트
    /// </summary>
    /// <param name="obj"></param>
    private void OnDragEnd(InputAction.CallbackContext obj)
    {
        onDragEnd?.Invoke(obj.ReadValue<Vector2>());
    }
}
