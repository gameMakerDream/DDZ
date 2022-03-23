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
        ifAccount = Util.FindDeepChildAndGetComponent<InputField>(viewComponent.transform, "InputFieldAccount");
        ifPassword = Util.FindDeepChildAndGetComponent<InputField>(viewComponent.transform, "InputFieldPassword");
        btnLoginAccount = Util.FindDeepChildAndGetComponent<Button>(viewComponent.transform, "BtnLoginAccount");
        btnLoginWechat = Util.FindDeepChildAndGetComponent<Button>(viewComponent.transform, "BtnLoginWechat");
        btnLoginGuest = Util.FindDeepChildAndGetComponent<Button>(viewComponent.transform, "BtnLoginGuest");
        tgeAgreement = Util.FindDeepChildAndGetComponent<Toggle>(viewComponent.transform, "TgeAgreement");
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
    private void OnClickLoginAccount()
    {
        SendNotification(PublicDefine.frameWorkCmd_LoadScene, "Hall");
    }
    private void OnClickLoginWechat()
    {

    }
    private void OnClickLoginGuest()
    {

    }
    private void OnClickAgreement(bool value)
    {
        
    }
}
