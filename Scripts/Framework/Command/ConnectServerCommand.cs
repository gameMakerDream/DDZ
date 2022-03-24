using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Command;
using PureMVC.Interfaces;



public class ConnectServerCommand : SimpleCommand
{
    INotification notification;
    public override void Execute(INotification notification)
    {
        ServerType _serverType = (ServerType)notification.Body;
        //调用socket连接方法 传入callBack
        this.notification = notification;
    }
    public void ConnectCallBack()
    {
        ServerType _serverType = (ServerType)notification.Body;
        switch (_serverType)
        {
            case ServerType.Hall:
                SendNotification(PublicDefine.frameWorkCmd_LoadScene, SceneName.Hall);
                break;
            case ServerType.DDZ:
                SendNotification(PublicDefine.frameWorkCmd_LoadScene, SceneName.DDZ);
                break;
            case ServerType.MJ:
                SendNotification(PublicDefine.frameWorkCmd_LoadScene, SceneName.MJ);
                break;
            default:
                break;
        }
    }
}
