using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Networking;



public class HttpHall
{
    private static HttpHall instance;

    private const string baseAddress = "http://192.168.1.17:19008";
    private const string guestLogin = baseAddress+"/guest";
    private const string AccountLogin = baseAddress + "/auth?";
    public static HttpHall Instance
    {
        get 
        {
            if(instance==null)
                instance = new HttpHall();
            return instance;
        }
    }









    public string LoginByGuest()
    {
        return Get(guestLogin);
    }
    public string LoginByGuest(string account)
    {
        string _url = AppendParams(guestLogin, "account", account);
        return Get(_url);
    }
    public string LoginByAccount(string account,string password)
    {
        string _url = AppendParams(AccountLogin, "account", account, "password", password);
        return Get(_url);
    }
    private string Get(string url)
    {
        UnityWebRequest _uwr=UnityWebRequest.Get(url);
        _uwr.SendWebRequest();
        if (_uwr.error != null)
            Debug.Log(_uwr.error);
        else
            return _uwr.downloadHandler.text;
        return null;
    }
    private string AppendParams(string baseStr,params object[] args)
    {
        for (int i = 1; i < args.Length; i+=2)
        {
            string _argName = args[i - 1].ToString();
            string _argBody = args[i].ToString();
            if(i==args.Length-1)
                baseStr += _argName + "=" + _argBody;
            else
                baseStr += _argName + "=" + _argBody+"&";
        }
        return baseStr;
    }

}
