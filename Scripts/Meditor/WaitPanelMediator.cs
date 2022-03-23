using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
using UnityEngine;
using UnityEngine.UI;

public class WaitPanelMediator : Mediator
{
    public new const string NAME = "WaitPanelMediator";

    private Text txtHint;
    public WaitPanelMediator(GameObject viewComponent) : base(NAME, viewComponent)
    {
        txtHint = Util.FindDeepChildAndGetComponent<Text>(viewComponent.transform, "TxTHint");
    }

    public override string[] ListNotificationInterests()
    {
        List<string> _list = new List<string>();
        _list.Add(PublicDefine.frameWorkMsg_Wait);
        return _list.ToArray();
    }

    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case PublicDefine.frameWorkMsg_Wait:
                string _text = (string)notification.Body;
                txtHint.text = _text;
                break;
            default:
                break;
        }
    }

    public override void OnRegister()
    {
        base.OnRegister();
    }

    public override void OnRemove()
    {
        base.OnRemove();
    }

}
