using LTA.DesignPattern;
using LTA.UI;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AcheivementController : CaimQuestController,IOnDestoyPool
{
    [SerializeField]
    TextMeshProUGUI txtTitle, txtDescription;

    [SerializeField]
    Image imgIcon;


    [SerializeField]
    ButtonController btnCaim;

    public Action onClear;

    [SerializeField]
    RewardsController rewards;

    public void Init(AcheivementData data)
    {
        base.Init(data);
        txtTitle.text = data.title;
        txtDescription.text = data.messageError;
        imgIcon.sprite = Resources.Load<Sprite>("Icons/" + data.icon);
        rewards.Init(data.rewards);
        btnCaim.OnClick((btn) =>
        {
            DoCaim();
        });

    }

    protected override void Clear()
    {
        base.Clear();
        if (onClear != null)
        {
            onClear();
        }
    }

    protected override void ClearCaimQuest()
    {
        
    }

    protected override void Lock()
    {
        Debug.Log("Lock");
        btnCaim.gameObject.SetActive(false);
    }

    protected override void UnClearCaimQuest()
    {
        
    }

    protected override void Unlock()
    {
        btnCaim.gameObject.SetActive(true);
    }

    public void OnOnDestoyPool()
    {
        Clear();
    }
}
