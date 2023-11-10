using LTA.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChestController : CaimQuestController
{
    [SerializeField]
    Image imgChest,imgIconResource;

    [SerializeField]
    TextMeshProUGUI txtResource;

    ChestData chestData;

    bool isUnlock = false;

    [SerializeField]
    ButtonController btnCaim;

    public void Init(ChestData chestData)
    {
        this.chestData = chestData;
        base.Init(chestData);
        //imgChest.sprite = Resources.Load<Sprite>("Icons/" + chestData.iconChest);

        imgIconResource.sprite = Resources.Load<Sprite>("Icons/" + chestData.iconResource);
        txtResource.text = chestData.value.ToString();
        btnCaim.OnClick((btn) =>
        {
            if (!isUnlock) return;
            DoCaim();
        });
    }

    protected override void ClearCaimQuest()
    {
        
    }

    protected override void Lock()
    {
        imgChest.sprite = Resources.Load<Sprite>("Icons/" + chestData.iconChest);
    }

    protected override void UnClearCaimQuest()
    {
        
    }

    protected override void Unlock()
    {
        isUnlock = true;
        imgChest.sprite = Resources.Load<Sprite>("Icons/" + chestData.unLockChest);
    }
}
