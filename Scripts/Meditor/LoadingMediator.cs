using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Mediator;
using PureMVC.Interfaces;
using UnityEngine.UI;

public class LoadingMediator : Mediator
{

    public new const string NAME = "LoadingMediator";

    private Text txtProgress;
    public LoadingMediator(GameObject viewComponent) : base(NAME, viewComponent)
    {
        txtProgress = Util.FindDeepChildAndGetComponent<Text>(viewComponent.transform, "Text");
       
    }
    public override string[] ListNotificationInterests()
    {
        List<string> list = new List<string>();
        list.Add(PublicDefine.frameWorkMsg_LoadSceneProgress);
        return list.ToArray();
    }
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case PublicDefine.frameWorkMsg_LoadSceneProgress:
                float _progress = (float)notification.Body;
                txtProgress.text = (_progress * 100).ToString();
                break;
            default:
                break;
        }
        Debug.Log(NAME + ":收到" + notification.Name + "消息");
    }

    public override void OnRegister()
    {
        Debug.Log(NAME + ":注册成功");
    }

    public override void OnRemove()
    {
        Debug.Log(NAME + ":移除成功");
    }

}
