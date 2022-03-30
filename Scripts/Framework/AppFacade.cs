using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Facade;
using UnityEngine;

public class AppFacade : Facade
{
    
    public static AppFacade Instance
    {
        get 
        { 
            if(instance==null)
                instance = new AppFacade();
            return instance as AppFacade;
        }
    }
    public void StartUp()
    {

        RegisterCommand(PublicDefine.frameWorkCmd_StartUp, () => new StartUpCommand());
        SendNotification(PublicDefine.frameWorkCmd_StartUp);
        RemoveCommand(PublicDefine.frameWorkCmd_StartUp);
    }
}