using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IntervalTool
{
    [MenuItem("tools/interval")]
    public static void SetInterval()
    {
        int interval = 50;
        Transform trans = Selection.activeGameObject.transform;
        for (int i = 0; i < trans.childCount; i++)
        {
            Transform item = trans.GetChild(i);
            item.GetComponent<RectTransform>().anchoredPosition = new Vector3(i * interval, 0, 0);
        }
    }
}
