using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using LTA.UI;
using LTA.Effect;
using LTA.Condition;

public class DailyRewardController : CaimQuestController
{
    [SerializeField]
    TextMeshProUGUI txtTitle,txtDescription;

    [SerializeField]
    Image imgIcon;

    [SerializeField]
    GameObject iconClear,iconFocus;

    [SerializeField]
    ButtonController btnCaim;



    bool isCaiming = false;

    public void Init(DailyRewardsData rewardsData)
    {
        //iconClear.gameObject.SetActive(false);
        
        base.Init(rewardsData);
        txtTitle.text = rewardsData.title;
        txtDescription.text = rewardsData.description;
        imgIcon.sprite = Resources.Load<Sprite>("Icons/"+rewardsData.icon);
        btnCaim.OnClick((btn) =>
        {
            isCaiming = true;   
            DoCaim();
        });
    }

    protected override void Lock()
    {
        btnCaim.enabled = false;
        if (isCaiming)
        {
            isCaiming = false;
            iconClear.GetComponent<EffectController>().ShowEffect(TypeEffect.Select,Lock);
            return;
        }
        iconFocus.gameObject.SetActive(false);
    }

    protected override void Unlock()
    {
        btnCaim.enabled = true;
        iconFocus.gameObject.SetActive(true);
    }

    protected override void ClearCaimQuest()
    {
        iconClear.gameObject.SetActive(true);
        iconClear.transform.localScale = Vector3.one;
    }

    protected override void UnClearCaimQuest()
    {
        iconClear.gameObject.SetActive(false);
    }
}
