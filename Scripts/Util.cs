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

    public static string Number2String(float number)
    {
        if (number < 10000)
            return number.ToString("f2");
        int count = ((int)number).ToString().Length-5;
        if(count<4)
             return (number / 10000).ToString("f2")+"w";
        return (number / 100000000).ToString("f2") + "y";

    }
}
