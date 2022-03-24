using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using UnityEngine;

public class LoadSceneCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        SceneName _sceneName = (SceneName)notification.Body;
        switch (SceneMgr.instance.CurrentSceneName)
        {
            case SceneName.Login:
                Facade.RemoveMediator(LoginMediator.NAME);
                break;
            case SceneName.Hall:
                Facade.RemoveMediator(HallMediator.NAME);
                break;
            case SceneName.DDZ:
                break;
            case SceneName.MJ:
                break;
            default:
                break;
        }
        SceneMgr.instance.LoadSceneAsync(_sceneName);
    }
}
