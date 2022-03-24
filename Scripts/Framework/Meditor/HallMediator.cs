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
    private Button btnSetting;
    private Button btnShare;
    private Button btnDDZ;
    private Button btnMJ;
    private Button btnCreate;
    private Button btnJoin;
    public HallMediator(GameObject viewComponent) : base(NAME, viewComponent)
    {
        imgIcon = Util.FindDeepChildAndGetComponent<Image>(viewComponent.transform, "imgIcon");
        txtName = Util.FindDeepChildAndGetComponent<Text>(viewComponent.transform, "txtName");
        txtCoin = Util.FindDeepChildAndGetComponent<Text>(viewComponent.transform, "txtCoin");
        txtCurrency = Util.FindDeepChildAndGetComponent<Text>(viewComponent.transform, "txtCurrency");
        btnSetting = Util.FindDeepChildAndGetComponent<Button>(viewComponent.transform, "btnSetting");
        btnShare = Util.FindDeepChildAndGetComponent<Button>(viewComponent.transform, "btnShare");
        btnDDZ = Util.FindDeepChildAndGetComponent<Button>(viewComponent.transform, "btnDDZ");
        btnMJ = Util.FindDeepChildAndGetComponent<Button>(viewComponent.transform, "btnDDZ");
        btnCreate = Util.FindDeepChildAndGetComponent<Button>(viewComponent.transform, "btnDDZ");
        btnJoin = Util.FindDeepChildAndGetComponent<Button>(viewComponent.transform, "btnDDZ");
        btnSetting.onClick.AddListener(OnClickSetting);
        btnShare.onClick.AddListener(OnClickShare);
        btnDDZ.onClick.AddListener(OnClickDDZ);
        btnMJ.onClick.AddListener(OnClickMJ);
        btnCreate.onClick.AddListener(OnClickCreate);
        btnJoin.onClick.AddListener(OnClickJoin);
    }
    public override string[] ListNotificationInterests()
    {
        List<string> _list = new List<string>();
        _list.Add(PublicDefine.frameWorkMsg_UpdateUserData);
        return _list.ToArray();
    }
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case PublicDefine.frameWorkMsg_UpdateUserData:
                UserData _userData = (UserData)notification.Body;
                Update(_userData);
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
    private void OnClickSetting()
    {
        SendNotification(PublicDefine.frameWorkCmd_OpenPanel, PanelType.Setting);
    }
    private void OnClickShare()
    {

    }
    private void OnClickDDZ()
    {

    }
    private void OnClickMJ()
    {

    }
    private void OnClickCreate()
    {

    }
    private void OnClickJoin()
    {

    }
    private void Update(UserData userData)
    {
        imgIcon.sprite = Resources.Load<Sprite>("icon" + userData.iconIndex);
        txtName.text = userData.nickName;
        txtCoin.text = Util.Number2String(userData.coin);
        txtCurrency.text = Util.Number2String(userData.currency);
    }
}