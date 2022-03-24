using System.Collections;
using System.Collections.Generic;
using PureMVC.Patterns.Facade;
using UnityEngine;

public class AppFacade : Facade
{
    public AppFacade():base()
    {
        
    }
    public AppFacade(GameObject gameManager) : this()
    {
        RegisterCommand(PublicDefine.frameWorkCmd_StartUp, () => new StartUpCommand());
        SendNotification(PublicDefine.frameWorkCmd_StartUp, gameManager);
        RemoveCommand(PublicDefine.frameWorkCmd_StartUp);
    }
}
