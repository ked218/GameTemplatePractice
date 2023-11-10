using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpDailyRewardController : BasePopUp
{
    [SerializeField]
    DailyRewardController[] dailyRewardControllers;
    // Start is called before the first frame update
    void Start()
    {
        DailyRewardsJSONData dailyRewardsDatas = DataController.Instance.dailyRewardsDatas;
        int maxReward = dailyRewardControllers.Length + 1;
        int count = 0;

        foreach (DailyRewardsData dailyRewardsData in dailyRewardsDatas)
        {
            if (count > dailyRewardControllers.Length) break;
            dailyRewardControllers[count].Init(dailyRewardsData);
            count++;
        }
       

    }
}
