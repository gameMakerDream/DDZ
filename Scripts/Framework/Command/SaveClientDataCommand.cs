using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using UnityEngine;
using LitJson;

public class SaveClientDataCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        ClientDataProxy _cdp = Facade.RetrieveProxy(ClientDataProxy.NAME) as ClientDataProxy;
        string _json = JsonMapper.ToJson(_cdp.VO);
        PlayerPrefs.SetString(ClientDataProxy.NAME, _json);
    }
}