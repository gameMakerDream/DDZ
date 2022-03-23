using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Mediator;
using PureMVC.Interfaces;
using UnityEngine.UI;

public class HallMediator : Mediator
{

    public new const string NAME = "HallMediator";

    private Image imgIcon;
    private Text txtName;
    private Text txtCoin;
    private Text txtCurrency;

    public HallMediator(GameObject viewComponent) : base(NAME, viewComponent)
    {
        imgIcon = Util.FindDeepChildAndGetComponent<Image>(viewComponent.transform, "imgIcon");
        txtName = Util.FindDeepChildAndGetComponent<Text>(viewComponent.transform, "txtName");
        txtCoin = Util.FindDeepChildAndGetComponent<Text>(viewComponent.transform, "txtCoin");
        txtCurrency = Util.FindDeepChildAndGetComponent<Text>(viewComponent.transform, "txtCurrency");
    }
    public override string[] ListNotificationInterests()
    {
        List<string> list = new List<string>();
        list.Add(PublicDefine.frameWorkMsg_UpdateUserData);
        return list.ToArray();
    }
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case PublicDefine.frameWorkMsg_UpdateUserData:
                UserData userData = (UserData)notification.Body;
                Update(userData);
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
    private void Update(UserData userData)
    {
        txtName.text = userData.nickName;
        txtCoin.text = Util.Number2String(userData.coin);
        txtCurrency.text = Util.Number2String(userData.currency);
    }
}
