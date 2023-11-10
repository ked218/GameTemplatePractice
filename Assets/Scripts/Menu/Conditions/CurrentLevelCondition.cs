using UnityEngine;
using LTA.Condition;
using System;
using LTA.DesignPattern;
[System.Serializable]
public class CurrentLevelConditionInfo
{
    public string levelKey = LevelKey.MainLevel;
    public int minLevel = 1;
}

[ComponentType(typeof(CurrentLevelCondition),typeof(CurrentLevelConditionInfo),"CurrentLevelCondition","conditions")]
public class CurrentLevelCondition : MonoBehaviour,ICondition,ISetInfo
{
    [SerializeField]
    CurrentLevelConditionInfo info;

    public object Info
    {
        set
        {
            info = (CurrentLevelConditionInfo)value;
            Observer.Instance.AddObserver(info.levelKey, OnUpLevel);
            if (GlobalVar.GetCurrentLevel(info.levelKey)-1 >= info.minLevel)
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

    public Action<ICondition> SuitableCondition { set => suitableCondition = value; }

    void OnUpLevel(object level)
    {
        if ((int)level-1 >= info.minLevel)
        {
            IsSuitable = true;
            return;
        }
        IsSuitable = false;
    }

    private void OnDestroy()
    {
        Observer.Instance.RemoveObserver(info.levelKey, OnUpLevel);
    }
}
