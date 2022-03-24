using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using UnityEngine;

public class ChangeVolumeCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        object[] _params = (object[])notification.Body;
        SoundType _soundType = (SoundType)_params[0];
        float _soundVolume = (float)_params[1];
        ClientDataProxy _cdp = Facade.RetrieveProxy(ClientDataProxy.NAME) as ClientDataProxy;
        _cdp.SetSoundVolume(_soundType, _soundVolume);
        SoundMgr.instance.SetSoundVolume(_soundType, _soundVolume);
        SendNotification(PublicDefine.frameWorkCmd_SaveClientData);
    }
}
