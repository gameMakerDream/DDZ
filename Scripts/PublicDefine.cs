using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneName
{
    Login,
    Hall,
    DDZ,
    MJ
}

public class PublicDefine : MonoBehaviour
{
    #region frameworkNotes

    public const string frameWorkCmd_StartUp = "frameWorkCmd_StartUp";
    public const string frameWorkCmd_LoadScene = "frameWorkCmd_LoadScene";
    public const string frameWorkCmd_LoadSceneComplete = "frameWorkCmd_LoadSceneComplete";


    public const string frameWorkMsg_LoadSceneProgress = "frameWorkMsg_LoadSceneProgress";

    #endregion

}
