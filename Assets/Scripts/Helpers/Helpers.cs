using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ComponentExtensions
{
    public static bool TryGetComponentInChildren<T>(this Component self, out T component, bool includeInactive = false) where T : Component
    {
        component = self.GetComponentInChildren<T>(includeInactive);
        return component != null;
    }

    public static bool TryGetComponentInChildren<T>(this GameObject go, out T component, bool includeInactive = false) where T : Component
    {
        component = go.GetComponentInChildren<T>(includeInactive);
        return component != null;
    }
}

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