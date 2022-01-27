using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class Error
{
    public static void MissingComponent(MonoBehaviour owner, Type componentType)
    {
        Debug.LogWarning(string.Format("[{0}] game object has no [{1}] component.",
            owner.gameObject.name, componentType.ToString()), owner);
    }

    public static void MissingPropertyValue(MonoBehaviour owner, string propertyName)
    {
        propertyName = propertyName.Substring(0, 1).ToUpper() +
            propertyName.Substring(1).ToLower();
        Debug.LogWarning(string.Format("[{0}] game object's [{1}] component has no value for [{2}] property.",
            owner.gameObject.name, owner.GetType(), propertyName), owner);
    }
}