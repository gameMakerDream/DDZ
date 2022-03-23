using System.Collections;
using System.Collections.Generic;
using PureMVC.Patterns.Facade;
using UnityEngine;

public class AppFacade : Facade
{
    public AppFacade() : base()
    {

    }

    protected override void InitializeFacade()
    {
        base.InitializeFacade();
        RegisterCommand(PublicDefine.frameWorkCmd_StartUp,()=>new StartUpCommand());
        RegisterCommand(PublicDefine.frameWorkCmd_LoadScene, () => new LoadSceneCommand());
        RegisterCommand(PublicDefine.frameWorkCmd_LoadSceneComplete, () => new LoadSceneCompleteCommand());
        RegisterCommand(PublicDefine.frameWorkCmd_OpenPanel, () => new OpenPanelCommand());
        SendNotification(PublicDefine.frameWorkCmd_StartUp);
        RemoveCommand(PublicDefine.frameWorkCmd_StartUp);
    }
}
