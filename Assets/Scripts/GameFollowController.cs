using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.GameFollow;
using LTA.Handle;

public class GameFollowController : BaseGameController
{
    List<IHandle> winHandles = new List<IHandle>();
    private void Start()
    {
        if (GlobalVar.winHandles == null || GlobalVar.winHandles.Length == 0) return;
        foreach (ComponentInfo componentInfo in GlobalVar.winHandles)
        {
            ComponentHelper.AddComponent(gameObject, componentInfo, (component) =>
            {
                IHandle handle = (IHandle)component;
                winHandles.Add(handle);
            });
        }
    }
    protected override void OnContinue()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnDraw()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnLose()
    {
        SceneController.OpenScene(SceneName.Menu);
    }

    protected override void OnQuit()
    {
        SceneController.OpenScene(SceneName.Menu);
    }

    protected override void OnWin()
    {
        //if (GlobalVar.CurrentLevel > DataController.Instance.levelData.Count)
        //{
        //    SceneController.OpenScene(SceneName.Menu);
        //    return;
        //}
        //GlobalVar.CurrentLevel++;
        //if (!LevelHelper.CheckLevel(gameObject,GlobalVar.CurrentLevel))
        //    GlobalVar.CurrentLevel--;
        foreach (IHandle handle in winHandles)
        {
            handle.Handle();
        }
        SceneController.OpenScene(SceneName.Menu);
    }

}
