using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnbiasedTimeManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoadingController : LoadingController,ISceneManager
{
    private void Start()
    {
        SceneHelper.SceneManager = this;
        DataController.Instance.LoadData();
        UnbiasedTime.Init();
        GlobalVar.AddRescoure("Energy", 100);
        //DateTime dateTime = UnbiasedTime.Instance.dateTime;
        Init();
    }

    protected override void EndFirstLoading()
    {
        SceneController.OpenScene(SceneName.Menu);
    }

    public void OpenScene(string sceneName, LoadSceneMode mode)
    {
        SceneManager.LoadScene(sceneName, mode);
    }

    public void CloseScene(string sceneName)
    {
        SceneManager.UnloadScene(sceneName);
    }
}
