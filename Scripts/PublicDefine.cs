using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneName
{
    Login,
    Hall,
    Game,
}
public enum PanelType
{
    WaitPanel,
    SettingPanel,
}
public enum SoundType
{
    BackSound,
    EffectSound
}
public enum GameType
{
    ddz,
    mj,
}
public class PublicDefine : MonoBehaviour
{
    public const string prefabPath = "prefab/";
    public const string soundPath = "sound/";

    #region frameworkNotes

    public const string frameWorkCmd_StartUp = "frameWorkCmd_StartUp";
    public const string frameWorkCmd_LoadScene = "frameWorkCmd_LoadScene";
    public const string frameWorkCmd_LoadSceneComplete = "frameWorkCmd_LoadSceneComplete";
    public const string frameWorkCmd_OpenPanel = "frameWorkCmd_OpenPanel";
    public const string frameWorkCmd_HidePanel = "frameWorkCmd_HidePanel";
    public const string frameWorkCmd_ChangeVolume = "frameWorkCmd_ChangeVolume";
    public const string frameWorkCmd_SaveClientData = "frameWorkCmd_SaveClientData";

    public const string frameWorkMsg_LoadSceneProgress = "frameWorkMsg_LoadSceneProgress";
    public const string frameWorkMsg_UpdateUserData = "frameWorkMsg_UpdateUserData";
    public const string frameWorkMsg_Wait = "frameWorkMsg_Wait";

    #endregion

}
