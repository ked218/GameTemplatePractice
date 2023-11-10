using LTA.Condition;
using LTA.Handle;
using LTA.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using LTA.DesignPattern;
public class QuestController : AcheivementController,IOnDestoyPool
{
    protected List<IHandle> goHandles = new List<IHandle>();

    [SerializeField]
    ButtonController btnGo;

    public void Init(QuestData questData)
    {
        

        base.Init(questData);
        
        foreach (ComponentInfo componentInfo in questData.goHandles)
        {
            ComponentHelper.AddComponent(gameObject, componentInfo, (component) =>
            {
                IHandle handle = (IHandle)component;
                
                if (component is IOwn)
                {
                    IOwn own = (IOwn)component;
                    own.Own = this;
                    own.OwnType = GetType();
                }
                goHandles.Add(handle);
            });
        }

        btnGo.OnClick((btn) =>
        {
            foreach(IHandle handle in goHandles)
            {
                handle.Handle();
            }
        });
    }


    protected override void Lock()
    {
        btnGo.gameObject.SetActive(true);
        base.Lock();
    }

    protected override void Unlock()
    {
        btnGo.gameObject.SetActive(false);
        base.Unlock();
    }

    protected override void ClearCaimQuest()
    {
        
    }

    protected override void UnClearCaimQuest()
    {
        
    }
}
