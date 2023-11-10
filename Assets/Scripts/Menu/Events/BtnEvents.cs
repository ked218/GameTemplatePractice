using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.UI;
public class BtnEvents : BaseButtonController
{
    protected override void OnClick()
    {
        PopUpEventsController popUp = PopUp.Instance.ShowLocalPopUp<PopUpEventsController>("PopUpEvent");
        popUp.Init("EventPoint",DataController.Instance.eventProcessRewardsJSONArrayData);
    }

}
