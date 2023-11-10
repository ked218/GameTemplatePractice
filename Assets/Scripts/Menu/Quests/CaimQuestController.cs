using LTA.Condition;
using LTA.Handle;
using LTA.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class CaimQuestController : ConditionController
{

    protected List<IHandle> caimHandles = new List<IHandle>();

    protected List<ICondition> clearConditions = new List<ICondition>();

    public void Init(CaimQuestData questData)
    {
        base.Init(questData);
        foreach (ComponentInfo componentInfo in questData.clearConditions)
        {
            ComponentHelper.AddComponent(gameObject, componentInfo, (component) =>
            {
                ICondition condition = (ICondition)component;
                condition.SuitableCondition = OnClearSuitableCondition;
                clearConditions.Add(condition);
            });
        }
        CheckClearCaimQuest();
        foreach (ComponentInfo componentInfo in questData.caimHandles)
        {
            ComponentHelper.AddComponent(gameObject, componentInfo, (component) =>
            {
                IHandle handle = (IHandle)component;
                caimHandles.Add(handle);
            });
        }
    }

    void OnClearSuitableCondition(ICondition condition)
    {
        CheckClearCaimQuest();
    }

    void CheckClearCaimQuest()
    {
        if (!IsClear)
        {
            UnClearCaimQuest();
            return;
        }
        ClearCaimQuest();
    }

    public bool IsClear
    {
        get
        {
            foreach (ICondition condition1 in clearConditions)
            {
                if (!condition1.IsSuitable)
                {
                    return false;
                }
            }
            return true;
        }
    }

    protected abstract void ClearCaimQuest();

    protected override void Clear()
    {
        base.Clear();
        if (clearConditions.Count > 0)
        {
            foreach (ICondition condition in clearConditions)
            {
                Destroy((MonoBehaviour)condition);
            }
            clearConditions.Clear();
        }
        if (clearConditions.Count > 0)
        {
            foreach (IHandle condition in clearConditions)
            {
                Destroy((MonoBehaviour)condition);
            }
            clearConditions.Clear();
        }
    }

    protected abstract void UnClearCaimQuest();

    protected void DoCaim()
    {
        foreach (IHandle handle in caimHandles)
        {
            handle.Handle();
        }
        CheckUnlock();
        CheckClearCaimQuest();
    }
}
