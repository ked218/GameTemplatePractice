using LTA.Condition;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConditionController : MonoBehaviour
{
    [SerializeField]
    protected List<ICondition> conditions = new List<ICondition>();

    protected ConditionData conditionData;

    public void AddCondition(ComponentInfo componentInfo)
    {
        ComponentHelper.AddComponent(gameObject, componentInfo, (component) =>
        {
            ICondition condition = (ICondition)component;
            if (condition == null)
            {
                Destroy(component);
                return;
            }
            condition.SuitableCondition = OnSuitableCondition;
            conditions.Add(condition);
        });
        CheckUnlock();
    }

    protected void Init(ConditionData conditionData)
    {
        try
        {
            if (conditionData.conditions == null || conditionData.conditions.Length == 0)
            {
                Unlock();
                return;
            }
            Lock();
            foreach (ComponentInfo componentInfo in conditionData.conditions)
            {
                ComponentHelper.AddComponent(gameObject, componentInfo, (component) =>
                {
                    ICondition condition = (ICondition)component;
                    condition.SuitableCondition = OnSuitableCondition;
                    conditions.Add(condition);
                });
            }
            CheckUnlock();
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }

    void OnSuitableCondition(ICondition condition)
    {
        CheckUnlock();
    }

    protected void CheckUnlock()
    {
        if (!IsUnLocked)
        {
            Lock();
            return;
        }
        Unlock();
    }

    public bool IsUnLocked
    {
        get
        {
            foreach (ICondition condition1 in conditions)
            {
                if (!condition1.IsSuitable)
                {
                    return false;
                }
            }
            return true;
        }
    }

    protected virtual void Clear()
    {
        if (conditions.Count > 0)
        {
            foreach (ICondition condition in conditions)
            {
                Destroy((MonoBehaviour)condition);
            }
            conditions.Clear();
        }
    }
    protected abstract void Lock();

    protected abstract void Unlock();
}
