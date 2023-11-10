using UnityEngine;
using LTA.Condition;
using System;
using UnbiasedTimeManager;

[System.Serializable]
public class CurrentDayPlayGameCondtitionInfo
{
    public int minDay;
}

[ComponentType(typeof(CurrentDayPlayGameCondtition),typeof(CurrentDayPlayGameCondtitionInfo),"CurrentDayPlayGameCondtition","conditions")]
public class CurrentDayPlayGameCondtition : MonoBehaviour,ICondition,ISetInfo
{
    CurrentDayPlayGameCondtitionInfo info;

    public object Info
    {
        set
        {
            info = (CurrentDayPlayGameCondtitionInfo)value;
            DateTime firstTime = DateTime.Parse(PlayerPrefs.GetString("firstTime", UnbiasedTime.Instance.dateTime.ToString()));
            if ((UnbiasedTime.Instance.dateTime - firstTime).Days >= info.minDay)
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
}
