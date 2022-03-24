using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using UnityEngine;

public class LoadSceneCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        SceneName _sceneName = (SceneName) notification.Body;
        switch (SceneMgr.instance.CurrentSceneName)
        {
            case SceneName.Login:
                break;
            case SceneName.Hall:
                break;
            case SceneName.Game:
                break;
            default:
                break;
        }
        SceneMgr.instance.LoadSceneAsync(_sceneName);
    }
}
