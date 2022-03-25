using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DDZ
{
    public class EventMgr
    {
        public static Dictionary<string, Action<object>> eventDic = new Dictionary<string, Action<object>>();
        
        public static void AddListener(string eventName, Action<object> callBack)
        {
            if (!eventDic.ContainsKey(eventName))
                eventDic.Add(eventName, callBack);
        }
        public static void RemoveListener(string eventName)
        {
            if (eventDic.ContainsKey(eventName))
                eventDic.Remove(eventName);
        }
        public static void Broadcast(string eventName,object args)
        {
            if (eventDic.ContainsKey(eventName))
                eventDic[eventName](args);
        }
    }
}
