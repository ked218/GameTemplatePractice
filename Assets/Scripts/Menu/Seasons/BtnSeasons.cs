using LTA.Condition;
using LTA.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSeasons : BaseButtonController
{
    List<ICondition[]> list_conditions = new List<ICondition[]>();
    LeadBoardJSONData leaderBoardDatas;
    private void Start()
    {
        leaderBoardDatas = DataController.Instance.seaSonDatas;
        
        foreach(LeaderBoardData leaderBoardData in leaderBoardDatas)
        {
            List<ICondition> conditions = new List<ICondition>();
            foreach (ComponentInfo componentInfo in leaderBoardData.conditions)
            {
                ComponentHelper.AddComponent(gameObject, componentInfo, (component) =>
                {
                    ICondition condition = (ICondition)component;
                    conditions.Add(condition);
                });
            }
            list_conditions.Add(conditions.ToArray());
        }

    }

    protected override void OnClick()
    {
        for (int i = list_conditions.Count-1;i>= 0;i--)
        {
            if(LevelHelper.CheckCondition(list_conditions[i]))
            {
                PopUpSeasonsController popUp = PopUp.Instance.ShowLocalPopUp<PopUpSeasonsController>("PopUpSeasons");
                popUp.Init(leaderBoardDatas[i]);
                return;
            }
        }
    }
}
