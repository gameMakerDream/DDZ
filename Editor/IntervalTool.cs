using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IntervalTool
{
    [MenuItem("tools/interval")]
    public static void SetInterval()
    {
        int interval = 40;
        Transform trans = Selection.activeGameObject.transform;
        for (int i = 0; i < trans.childCount; i++)
        {
            Transform item = trans.GetChild(i);
            item.GetComponent<RectTransform>().anchoredPosition = new Vector3(i * interval, 0, 0);
        }
    }
    [MenuItem("tools/interval111")]
    public static void SetInterval1()
    {
        int interval = 35;
        Transform trans = Selection.activeGameObject.transform;
        for (int i = 0; i < 10; i++)
        {
            Transform item = trans.GetChild(i);
            item.GetComponent<RectTransform>().anchoredPosition = new Vector3(i * interval, 0, 0);
        }
        for (int i = 10; i < trans.childCount; i++)
        {
            Transform item = trans.GetChild(i);
            item.GetComponent<RectTransform>().anchoredPosition = new Vector3((i-10) * interval, -45,0);
        }
    }
}
