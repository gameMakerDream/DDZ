using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using PureMVC.Patterns.Mediator;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePanelCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        PanelType _panelType = (PanelType)notification.Body;
        IPanel _panel = PanelMgr.instance.GetPanel(_panelType);
        if (_panel != null)
            _panel.Hide();
    }
}
