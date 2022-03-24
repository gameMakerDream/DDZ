using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
using UnityEngine;
using UnityEngine.UI;

public class WaitPanelMediator : Mediator, IPanel, IUpdater
{
    public new const string NAME = "WaitPanelMediator";

    public GameObject view
    {
        get { return (GameObject)ViewComponent; }
    }

    public GameObject animationRoot
    {
        get { return view.transform.Find("BG").gameObject; }
    }


    private Text txtHint;
    public WaitPanelMediator(object viewComponent) : base(NAME, viewComponent)
    {
        txtHint = Util.FindDeepChildAndGetComponent<Text>(view.transform, "TxTHint");
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

    public void Update(object data)
    {
        string _text = data.ToString();
        txtHint.text = _text;
    }



    public void Show(bool immediately = true)
    {
        view.SetActive(true);
    }

    public void Hide(bool immediately = true)
    {
        view.SetActive(false);
    }
}