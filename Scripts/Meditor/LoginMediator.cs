using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Mediator;
using PureMVC.Interfaces;
using UnityEngine.UI;

public class LoginMediator : Mediator
{

    public new const string NAME = "LoginMediator";


    private InputField ifAccount;
    private InputField ifPassword;
    private Button btnLoginAccount;
    private Button btnLoginWechat;
    private Button btnLoginGuest;
    private Toggle tgeAgreement;
    public LoginMediator(GameObject viewComponent) : base(NAME, viewComponent)
    {
        ifAccount = Util.FindDeepChildAndGetComponent<InputField>(viewComponent.transform, "ifAccount");
        ifPassword = Util.FindDeepChildAndGetComponent<InputField>(viewComponent.transform, "ifPassword");
        btnLoginAccount = Util.FindDeepChildAndGetComponent<Button>(viewComponent.transform, "btnLoginAccount");
        btnLoginWechat = Util.FindDeepChildAndGetComponent<Button>(viewComponent.transform, "btnLoginWechat");
        btnLoginGuest = Util.FindDeepChildAndGetComponent<Button>(viewComponent.transform, "btnLoginGuest");
        tgeAgreement = Util.FindDeepChildAndGetComponent<Toggle>(viewComponent.transform, "tgeAgreement");
        btnLoginAccount.onClick.AddListener(OnClickLoginAccount);
        btnLoginWechat.onClick.AddListener(OnClickLoginWechat);
        btnLoginGuest.onClick.AddListener(OnClickLoginGuest);
        tgeAgreement.onValueChanged.AddListener(OnClickAgreement);
    }
    public override string[] ListNotificationInterests()
    {
        List<string> list = new List<string>();
        return base.ListNotificationInterests();
    }
    public override void HandleNotification(INotification notification)
    {
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
    private void OnClickLoginAccount()
    {
        SendNotification(PublicDefine.frameWorkCmd_LoadScene, SceneName.Hall);
    }
    private void OnClickLoginWechat()
    {
        SendNotification(PublicDefine.frameWorkCmd_LoadScene, SceneName.Hall);
    }
    private void OnClickLoginGuest()
    {

    }
    private void OnClickAgreement(bool value)
    {
        
    }
}
