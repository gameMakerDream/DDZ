using LitJson;
using PureMVC.Patterns.Proxy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientDataProxy : Proxy
{
    public new const string NAME = "ClientDataProxy";

    public ClientData VO
    {
        get { return (ClientData)Data; }
    }
    public ClientDataProxy() : base(NAME)
    {
        Data = LoadData();
    }

    public override void OnRegister()
    {
        Debug.Log(NAME + ":注册成功");

    }

    public override void OnRemove()
    {
        Debug.Log(NAME + ":移除成功");
    }


    public void SetSoundVolume(SoundType soundType,double soundVolume)
    {
        switch (soundType)
        {
            case SoundType.BackSound:
                VO.backSoundVolume= soundVolume;
                break;
            case SoundType.EffectSound:
                VO.effectSoundVolume = soundVolume;
                break;
            default:
                break;
        }
    }
    private ClientData LoadData()
    {
        string _data=PlayerPrefs.GetString(NAME);
        if (string.IsNullOrEmpty(_data))
            return new ClientData();
        return JsonMapper.ToObject<ClientData>(_data);
    }
}
