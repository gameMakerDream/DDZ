using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using UnityEngine;
public class StartUpCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        GameObject _gameManager = GameObject.Find("GameManager");
        Facade.RegisterProxy(new ClientDataProxy());
        _gameManager.AddComponent<SceneMgr>();
        _gameManager.AddComponent<PanelMgr>();
        _gameManager.AddComponent<SoundMgr>();


        Facade.RegisterCommand(PublicDefine.frameWorkCmd_LoadScene, () => new LoadSceneCommand());
        Facade.RegisterCommand(PublicDefine.frameWorkCmd_LoadSceneComplete, () => new LoadSceneCompleteCommand());
        Facade.RegisterCommand(PublicDefine.frameWorkCmd_OpenPanel, () => new OpenPanelCommand());
        Facade.RegisterCommand(PublicDefine.frameWorkCmd_HidePanel, () => new HidePanelCommand());
        Facade.RegisterCommand(PublicDefine.frameWorkCmd_ChangeVolume, () => new ChangeVolumeCommand());
        Facade.RegisterCommand(PublicDefine.frameWorkCmd_SaveClientData, () => new SaveClientDataCommand());

        SendNotification(PublicDefine.frameWorkCmd_LoadScene, SceneName.Login);
    }
}