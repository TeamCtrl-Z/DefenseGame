using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 컴포넌트 확장 클래스
/// </summary>
public static class ComponentExtensions
{
    /// <summary>
    /// 현재 트렌스폼의 자식 트랜스폼에서 컴포넌트를 가져오는 Safety한 함수
    /// </summary>
    /// <typeparam name="T"> Component </typeparam>
    /// <param name="self"></param>
    /// <param name="component"></param>
    /// <param name="includeInactive"></param>
    /// <returns> 성공 실패 </returns>
    public static bool TryGetComponentInChildren<T>(this Component self, out T component, bool includeInactive = false) where T : Component
    {
        component = self.GetComponentInChildren<T>(includeInactive);
        return component != null;
    }

    /// <summary>
    /// 현재 게임오브젝트의 자식 트랜스폼에서 컴포넌트를 가져오는 Safety한 함수
    /// </summary>
    /// <typeparam name="T"> Component </typeparam>
    /// <param name="self"></param>
    /// <param name="component"></param>
    /// <param name="includeInactive"></param>
    /// <returns> 성공 실패 </returns>
    public static bool TryGetComponentInChildren<T>(this GameObject go, out T component, bool includeInactive = false) where T : Component
    {
        component = go.GetComponentInChildren<T>(includeInactive);
        return component != null;
    }
}

/// <summary>
/// 트랜스폼 확장 클래스
/// </summary>
public static class TransformExtensions
{
    /// <summary>
    /// 이름을 통해 자식 Transform 찾기
    /// </summary>
    /// <param name="transform"> 현재 Transform </param>
    /// <param name="name"> 찾을 Transform 이름 </param>
    /// <param name="result"> 결과로 받을 Transform </param>
    /// <returns> 성공 실패 </returns>
    public static bool TryFindByName(this Transform transform, string name, out Transform result)
    {
        Transform[] transforms = transform.GetComponentsInChildren<Transform>();

        result = null;
        foreach (Transform t in transforms)
        {
            if (t.name.Equals(name))
            {
                result = t;
                return true;
            }
        }
        return false;
    }
}