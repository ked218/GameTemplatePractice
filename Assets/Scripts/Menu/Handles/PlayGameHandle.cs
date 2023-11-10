using UnityEngine;
using LTA.Handle;
using System;
using LTA.Condition;
using System.Collections.Generic;

[ComponentType(typeof(PlayGameHandle),"PlayGameHandle","handles")]
public class PlayGameHandle : MonoBehaviour,IHandle
{
    Action<IHandle> endHandle;

    public Action<IHandle> EndHandle { 
        set => endHandle = value;
    }

    List<ICondition> playConditions = new List<ICondition>();

    List<IHandle> playHandles = new List<IHandle>();

    public void Handle()
    {
        LevelData levelData = DataController.Instance.levelData[GlobalVar.GetCurrentLevel(LevelKey.MainLevel) - 1];

        foreach (ComponentInfo componentInfo in levelData.playConditions)
        {
            ComponentHelper.AddComponent(gameObject, componentInfo, (component) =>
            {
                ICondition condition = (ICondition)component;
                condition.SuitableCondition = OnPlaySuitableCondition;
                playConditions.Add(condition);
            });
        }

        foreach (ComponentInfo componentInfo in levelData.playHandles)
        {
            ComponentHelper.AddComponent(gameObject, componentInfo, (component) =>
            {
                IHandle handle = (IHandle)component;
                playHandles.Add(handle);
            });
        }
        if (LevelHelper.CheckCondition(playConditions))
        {
            foreach (IHandle handle in playHandles)
            {
                handle.Handle();
            }
            GlobalVar.winHandles = levelData.winHandles;
            SceneController.OpenScene("GamePlay");
        }
        else
        {
            PopUpText popUp = PopUp.Instance.ShowLocalPopUp<PopUpText>("PopUpText");
            popUp.Init("Error",levelData.playError);
        }
        OnEndHandle();
    }

    void OnPlaySuitableCondition(ICondition condition)
    {

    }

    void OnEndHandle() {
        if (endHandle != null)
        {
            endHandle(this);
        }
    }
}
