using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Mediator;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanelMediator : Mediator, IPanel
{
    public new const string NAME = "SettingPanelMediator";

    public GameObject view
    {
        get { return (GameObject)ViewComponent; }
    }

    public GameObject animationRoot
    {
        get { return view.transform.Find("BG").gameObject; }
    }
    private Slider sldBackSound;
    private Slider sldEffectSound;
    private Button btnLogout;
    private Button btnQuit;
    private Button btnClose;

    public SettingPanelMediator(object viewComponent) : base(NAME, viewComponent)
    {
        sldBackSound = Util.FindDeepChildAndGetComponent<Slider>(view.transform, "sldBack");
        sldEffectSound = Util.FindDeepChildAndGetComponent<Slider>(view.transform, "sldEffect");
        btnLogout = Util.FindDeepChildAndGetComponent<Button>(view.transform, "btnLogout");
        btnQuit = Util.FindDeepChildAndGetComponent<Button>(view.transform, "btnQuit");
        btnClose = Util.FindDeepChildAndGetComponent<Button>(view.transform, "btnClose");
        sldBackSound.onValueChanged.AddListener(OnValueChangeBackSound);
        sldEffectSound.onValueChanged.AddListener(OnValueChangeEffectSound);
        btnLogout.onClick.AddListener(OnClickLogout);
        btnQuit.onClick.AddListener(OnClickQuit);
        btnClose.onClick.AddListener(OnClickClose);
    }

    public override string[] ListNotificationInterests()
    {
        List<string> _list = new List<string>();
        return _list.ToArray();
    }

    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            default:
                break;
        }
        Debug.Log(NAME + ":收到" + notification.Name + "消息");
    }

    public override void OnRegister()
    {
        LoadConfig();
        Debug.Log(NAME + ":注册成功");
    }

    public override void OnRemove()
    {
        Debug.Log(NAME + ":移除成功");
    }
    private void OnValueChangeBackSound(float value)
    {
        SendNotification(PublicDefine.frameWorkCmd_ChangeVolume, new object[] { SoundType.BackSound, value });
    }
    private void OnValueChangeEffectSound(float value)
    {
        SendNotification(PublicDefine.frameWorkCmd_ChangeVolume, new object[] { SoundType.EffectSound, value });
    }
    private void OnClickLogout()
    {

    }
    private void OnClickQuit()
    {

    }
    private void OnClickClose()
    {
        SendNotification(PublicDefine.frameWorkCmd_HidePanel, PanelType.Setting);
    }
    public void Show(bool immediately = false)
    {
        if (immediately)
        {
            animationRoot.transform.localScale = Vector3.one;
            view.SetActive(true);
        }
        else
        {
            animationRoot.transform.localScale = Vector3.one;
            view.SetActive(true);
        }
    }

    public void Hide(bool immediately = false)
    {
        if (immediately)
        {
            animationRoot.transform.localScale = Vector3.zero;
            view.SetActive(false);
        }
        else
        {
            animationRoot.transform.localScale = Vector3.zero;
            view.SetActive(false);
        }
    }
    private void LoadConfig()
    {
        ClientDataProxy _cdp = Facade.RetrieveProxy(ClientDataProxy.NAME) as ClientDataProxy;
        sldBackSound.value = (float)_cdp.VO.backSoundVolume;
        sldEffectSound.value = (float)_cdp.VO.effectSoundVolume;
    }
}