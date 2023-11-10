using LTA.Condition;
using LTA.Handle;
using LTA.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPlay : BaseButtonController
{
    List<ICondition> playConditions = new List<ICondition>();

    List<IHandle> playHandles = new List<IHandle>();

    protected override void OnClick()
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
            popUp.Init("Error", levelData.playError);
        }
        //LevelData levelData = DataController.Instance.levelData[GlobalVar.GetCurrentLevel(LevelKey.MainLevel) - 1];
        //GlobalVar.winHandles = levelData.winHandles;
        //SceneController.OpenScene("GamePlay");
    }
    void OnPlaySuitableCondition(ICondition condition)
    {

    }
}
