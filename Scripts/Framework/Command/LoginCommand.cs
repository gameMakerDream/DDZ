using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns.Command;
using PureMVC.Interfaces;
using LitJson;

public class LoginCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        //ClientDataProxy cdp = Facade.RetrieveProxy(ClientDataProxy.NAME) as ClientDataProxy;
        object[] _data=(object[])notification.Body;
        LoginType _lt = (LoginType)_data[0];
        string _account=(string)_data[1];
        string _password = (string)_data[2];
        string _response = string.Empty;
        switch (_lt)
        {
            case LoginType.Account:
                _response=HttpHall.Instance.LoginByAccount(_account, _password);
                break;
            case LoginType.Wechat:
                break;
            case LoginType.Guest:
                if (string.IsNullOrEmpty(_account))
                    _response = HttpHall.Instance.LoginByGuest();
                else
                    _response = HttpHall.Instance.LoginByGuest(_account);
                break;
            default:
                break;
        }
        HandleLoginResponse(_response);
    }
    private void HandleLoginResponse(string data)
    {
        HttpResponse _hr = JsonMapper.ToObject<HttpResponse>(data);
        if (_hr.errcode == "0")
        {
            ClientDataProxy _cdp = Facade.RetrieveProxy(ClientDataProxy.NAME) as ClientDataProxy;
            HttpUserData _hud = JsonMapper.ToObject<HttpUserData>(_hr.data);
            UserData _ud = new UserData();
            _ud.userId = _hud.userid;
            _ud.nickName = _hud.name;
            _ud.sex = _hud.sex;
            _ud.iconIndex = int.Parse(_hud.headimg);
            _ud.coin = _hud.coins;
            _ud.currency = _hud.gems;
        }
        else
            Debug.LogError(_hr.errmsg);

    }

}
