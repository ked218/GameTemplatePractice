using LTA.Condition;
using LTA.DesignPattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpQuests : BasePopUpAcheivementController<QuestController, QuestData, QuestJSONData>
{


    [SerializeField]
    RewardsResourceProcessing starRewardsResource;

    protected override QuestJSONData JSONArrayData => DataController.Instance.questDatas;


    // Start is called before the first frame update
    protected override void Start()
    {
        starRewardsResource.ResourceKey = "Star";
        starRewardsResource.Init(DataController.Instance.starProcessRewardsJSONData["Star"]);
        base.Start();
    }

}
