using LTA.Condition;
using LTA.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSpecialLevelController : BaseButtonController
{
    [SerializeField]
    string typeLevel;

    protected List<ICondition> conditions = new List<ICondition>();
    SpecialLevelsData specialLevelsData;
    private void Start()
    {
        specialLevelsData = DataController.Instance.specialLevelsJSONData[typeLevel];
        foreach (ComponentInfo componentInfo in specialLevelsData.conditions)
        {
            ComponentHelper.AddComponent(gameObject, componentInfo, (component) =>
            {
                ICondition condition = (ICondition)component;
                conditions.Add(condition);
            });
        }
    }

    bool CheckButton()
    {
            foreach (ICondition condition1 in conditions)
            {
                if (!condition1.IsSuitable) return false;
            }
        return true;
    }

    protected override void OnClick()
    {
        
        if (CheckButton())
        {
            PopUpChallengeLevelsController popup = PopUp.Instance.ShowLocalPopUp<PopUpChallengeLevelsController>("PopUpSpecialLevels");
            popup.Init(specialLevelsData);
        }
        else
        {
            PopUpText popUp = PopUp.Instance.ShowLocalPopUp<PopUpText>("PopUpText");
            popUp.Init("Locked",specialLevelsData.messageError);
        }
    }
}
