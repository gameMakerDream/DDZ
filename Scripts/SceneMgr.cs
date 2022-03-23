using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    public static SceneMgr instance;
    private string currentSceneName;

    public string CurrentSceneName
    {
        get { return currentSceneName; }
    }

    void Awake()
    {
        instance = this;
    }

    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine("OnLoad",sceneName);
    }

    private IEnumerator OnLoad(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync("Loading");
        AppFacade.GetInstance(() => new AppFacade()).RegisterMediator(new LoadingMediator(GameObject.Find("Canvas")));
        AsyncOperation _ao = SceneManager.LoadSceneAsync(sceneName);
        while (!_ao.isDone)
        {
            AppFacade.GetInstance(()=>new AppFacade()).SendNotification(PublicDefine.frameWorkMsg_LoadSceneProgress,_ao.progress);
            yield return new WaitForEndOfFrame();
        }
        OnComplete(sceneName);
    }



    private void OnComplete(string sceneName)
    {
        AppFacade.GetInstance(() => new AppFacade()).RemoveMediator(LoadingMediator.NAME);
        AppFacade.GetInstance(() => new AppFacade()).SendNotification(PublicDefine.frameWorkCmd_LoadSceneComplete,sceneName);
        currentSceneName = sceneName;
    }
}
