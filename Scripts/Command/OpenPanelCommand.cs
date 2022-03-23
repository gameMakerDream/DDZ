using PureMVC.Interfaces;
using PureMVC.Patterns.Command;
using PureMVC.Patterns.Mediator;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanelCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        PanelType _panelType = (PanelType)notification.Body;
        IPanel _panel=PanelMgr.instance.GetPanel(_panelType);
        if (_panel == null)
        {
            string _panelName = _panelType.ToString();
            GameObject _parent = GameObject.Find("Canvas/BG");
            string _path = PublicDefine.prefabPath + _panelName;
            GameObject _prefab = Resources.Load<GameObject>(_path);
            GameObject _instance = UnityEngine.Object.Instantiate(_prefab, _parent.transform);
            switch (_panelType)
            {
                case PanelType.WaitPanel:
                    _panel = new WaitPanelMediator(_instance);
                    Facade.RegisterMediator(_panel as WaitPanelMediator);
                    break;
                case PanelType.SettingPanel:
                    break;
                default:
                    break;
            }
            PanelMgr.instance.AddPanel(_panelType,_panel);
        }
        _panel.Show();
    }
}
