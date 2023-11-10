using UnityEngine;
using LTA.Condition;
using System;
using LTA.DesignPattern;

[System.Serializable]
public class ResourceConditionInfo
{
    public string resourceKey;
    public int minValue;
}

[ComponentType(typeof(ResourceCondition),typeof(ResourceConditionInfo),"ResourceCondition","conditions")]
public class ResourceCondition : MonoBehaviour,ICondition,ISetInfo
{
    ResourceConditionInfo info;

    public object Info
    {
        set
        {
            info = (ResourceConditionInfo)value;
            Observer.Instance.AddObserver(info.resourceKey, OnUpdateResource);
            if (GlobalVar.GetRescoure(info.resourceKey)>= info.minValue)
            {
                IsSuitable = true;
                return;
            }
            IsSuitable = false;
            
        }
    }
    
    Action<ICondition> suitableCondition;

    protected bool isSuitable = false;

    public bool IsSuitable {
        get
        {
            return isSuitable;
        }
        private set
        {
            if (isSuitable == value) return;
            isSuitable = value;
            if (suitableCondition != null)
            {
                suitableCondition(this);
            }
        }
    }

    void OnUpdateResource(object data)
    {
        if ((int)data >= info.minValue)
        {
            IsSuitable = true;
            return;
        }
        IsSuitable = false;
    }

    public Action<ICondition> SuitableCondition { set => suitableCondition = value; }

    private void OnDestroy()
    {
        Observer.Instance.RemoveObserver(info.resourceKey, OnUpdateResource);
    }
}
