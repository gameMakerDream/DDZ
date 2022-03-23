using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using UnityEngine;

public class LoadSceneCompleteCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        string _sceneName = (string) notification.Body;
        GameObject _root = GameObject.Find("Canvas");
        switch (_sceneName)
        {
            case "Login":
                Facade.RegisterMediator(new LoginMediator(_root));
                break;
            case "Hall":
                break;
            case "DDZ":
                break;
            case "MJ":
                break;
            default:
                break;
        }
    }
}
