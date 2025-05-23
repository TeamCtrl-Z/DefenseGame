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
