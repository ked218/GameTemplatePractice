using LTA.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnDailyRewards : BaseButtonController
{
    protected override void OnClick()
    {
        PopUp.Instance.ShowLocalPopUp<PopUpDailyRewardController>("PopUpDailyReward");
    }
}
