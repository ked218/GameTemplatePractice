using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpEventsController : BasePopUp
{
    [SerializeField]
    RewardsResourceProcessing prefabRewardsResource;

    [SerializeField]
    Transform content;
    // Start is called before the first frame update

    public void Init(string resourceKey,ProcessRewardsJSONArrayData processRewardsDatas)
    {
        //ProcessRewardsJSONArrayData processRewardsDatas = DataController.Instance.eventProcessRewardsJSONArrayData;
        foreach (ProcessRewardsData processRewardsData in processRewardsDatas)
        {
            RewardsResourceProcessing rewardsResource = Instantiate(prefabRewardsResource, content);
            rewardsResource.ResourceKey = resourceKey;
            rewardsResource.Init(processRewardsData);
        }
    }
}
