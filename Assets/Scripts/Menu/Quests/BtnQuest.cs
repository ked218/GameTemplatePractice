using LTA.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnQuest : BaseButtonController
{
    protected override void OnClick()
    {
        PopUp.Instance.ShowLocalPopUp<PopUpQuests>("PopUpQuests");

    }

}
