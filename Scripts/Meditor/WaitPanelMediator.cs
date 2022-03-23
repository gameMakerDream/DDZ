using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
using UnityEngine;
using UnityEngine.UI;

public class WaitPanelMediator : Mediator,IPanel
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
                Update(notification.Body);
                break;
            default:
                break;
        }
        Debug.Log(NAME + ":�յ�" + notification.Name + "��Ϣ");
    }

    public override void OnRegister()
    {
        Debug.Log(NAME + ":ע��ɹ�");
    }

    public override void OnRemove()
    {
        Debug.Log(NAME + ":�Ƴ��ɹ�");
    }

    public void Update(object data)
    {
        string _text = (string)data;
        txtHint.text = _text;
    }



    public void Show(bool immediately=false)
    {
        if (immediately)
        {

        }
        else
        {
            
        }
    }

    public void Hide(bool immediately=false)
    {
        if (immediately)
        {

        }
        else
        {

        }
    }
}
