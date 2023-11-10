using UnityEngine;
using LTA.Condition;
using System;
using JetBrains.Annotations;

[System.Serializable]
public class PlayerPrefConditionInfo : PlayerPrefInfo
{
    public CompareValue compareValue;
}

[ComponentType(typeof(PlayerPrefCondition),typeof(PlayerPrefConditionInfo),"PlayerPrefCondition","conditions")]
public class PlayerPrefCondition : MonoBehaviour,ICondition,ISetInfo
{
    PlayerPrefConditionInfo info;

    public object Info
    {
        set
        {
            info = (PlayerPrefConditionInfo)value;
            switch (info.typeValue)
            {
                case TypeValue.Integer:
                    IsSuitable = CompareHelper.Compare(info.compareValue,PlayerPrefs.GetInt(info.key,0));
                    break;
                case TypeValue.String:
                    IsSuitable =  info.stringValue.Equals(PlayerPrefs.GetString(info.key, ""));
                    break;
                case TypeValue.Float:
                    IsSuitable = CompareHelper.Compare(info.compareValue, PlayerPrefs.GetFloat(info.key, 0));
                    break;
            }
        }
    }
    
    Action<ICondition> suitableCondition;

    protected bool isSuitable = false;

    public bool IsSuitable {
        get
        {
            switch (info.typeValue)
            {
                case TypeValue.Integer:
                    IsSuitable = CompareHelper.Compare(info.compareValue, PlayerPrefs.GetInt(info.key, 0));
                    break;
                case TypeValue.String:
                    IsSuitable = info.stringValue.Equals(PlayerPrefs.GetString(info.key, ""));
                    break;
                case TypeValue.Float:
                    IsSuitable = CompareHelper.Compare(info.compareValue, PlayerPrefs.GetFloat(info.key, 0));
                    break;
            }
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
