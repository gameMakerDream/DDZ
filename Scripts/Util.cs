using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{

    public static Transform FindDeepChid(Transform parent,string childName)
    {
        Transform _child = parent.Find(childName);
        if (_child == null)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                _child = FindDeepChid(parent.GetChild(i), childName);
                if (_child != null)
                    break;
            }
        }
        return _child;
    }

    public static T FindDeepChildAndGetComponent<T>(Transform parent,string childName)where T:Component
    {
        return FindDeepChid(parent, childName).GetComponent<T>();
    }


}
