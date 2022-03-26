using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    public static SceneMgr instance;
    private SceneName currentSceneName;

    public SceneName CurrentSceneName
    {
        get { return currentSceneName; }
    }

    void Awake()
    {
        instance = this;
    }

    public void LoadSceneAsync(SceneName sceneName)
    {
        StartCoroutine("OnLoad", sceneName);
    }

    private IEnumerator OnLoad(SceneName sceneName)
    {
        yield return SceneManager.LoadSceneAsync("Loading");
        AppFacade.Instance.RegisterMediator(new LoadingMediator(GameObject.Find("Canvas")));
        AsyncOperation _ao = SceneManager.LoadSceneAsync(sceneName.ToString());
        while (!_ao.isDone)
        {
            AppFacade.Instance.SendNotification(PublicDefine.frameWorkMsg_LoadSceneProgress, _ao.progress);
            yield return new WaitForEndOfFrame();
        }
        OnComplete(sceneName);
    }



    private void OnComplete(SceneName sceneName)
    {
        AppFacade.Instance.RemoveMediator(LoadingMediator.NAME);
        AppFacade.Instance.SendNotification(PublicDefine.frameWorkCmd_LoadSceneComplete, sceneName);
        currentSceneName = sceneName;
    }
}