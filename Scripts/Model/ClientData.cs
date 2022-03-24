using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientData
{
    public bool isFirstLogin;
    public double backSoundVolume;
    public double effectSoundVolume;
    public ClientData()
    {
        isFirstLogin = true;
        backSoundVolume = 0.8f;
        effectSoundVolume = 0.8f;
    }
}
