using PureMVC.Patterns.Proxy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataProxy : Proxy
{
    public new const string NAME = "UserDataProxy";

    public UserData VO
    {
        get { return (UserData)Data; }
    }
    public UserDataProxy(object data) : base(NAME, data)
    {

    }

    public override void OnRegister()
    {
        Debug.Log(NAME + ":注册成功");

    }

    public override void OnRemove()
    {
        Debug.Log(NAME + ":移除成功");
    }
}