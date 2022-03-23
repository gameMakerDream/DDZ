using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanelCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        PanelType _panelType = (PanelType)notification.Body;
        string _panelName=string.Empty;
        switch (_panelType)
        {
            case PanelType.WaitPanel:
                _panelName = "WaitPanel";
                break;
            case PanelType.SettingPanel:
                _panelName = "SettingPanel";
                break;
            default:
                break;
        }
        GameObject _parent = GameObject.Find("Canvas/BG");



    }
}
