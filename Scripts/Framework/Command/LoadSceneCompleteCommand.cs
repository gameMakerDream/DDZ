using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using UnityEngine;

public class LoadSceneCompleteCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        SceneName _sceneName = (SceneName)notification.Body;
        GameObject _root = GameObject.Find("Canvas");
        switch (_sceneName)
        {
            case SceneName.Login:
                Facade.RegisterMediator(new LoginMediator(_root));
                break;
            case SceneName.Hall:
                Facade.RegisterMediator(new HallMediator(_root));
                break;
            case SceneName.DDZ:
                break;
            case SceneName.MJ:
                break;
            default:
                break;
        }
        PanelMgr.instance.Clear();
    }
}