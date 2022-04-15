using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientData
{
    public bool isFirstLogin;
    public double backSoundVolume;
    public double effectSoundVolume;
    public string account;
    public string password;
    public ClientData()
    {
        isFirstLogin = true;
        backSoundVolume = 0.8f;
        effectSoundVolume = 0.8f;
        account = string.Empty;
        password = string.Empty;
    }
}