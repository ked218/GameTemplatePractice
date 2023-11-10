using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PopUpChallengeLevelsController : BasePopUp
{
    [SerializeField]
    TextMeshProUGUI txtTitle;

    [SerializeField]
    TabsSpecialLevelController tabsSpecialLevelController;

    public void Init(SpecialLevelsData specialLevelsData)
    {
        //SpecialLevelsData specialLevelsData = DataController.Instance.specialLevelsJSONData[typeLevel];
        txtTitle.text = specialLevelsData.levelName;
        tabsSpecialLevelController.Init(specialLevelsData.typeLevels);
    }

    //public void Init(string typeLevel)
    //{
        
    //    txtTitle.text = specialLevelsData.levelName;
    //    tabsSpecialLevelController.Init(specialLevelsData.typeLevels);
    //}
}
