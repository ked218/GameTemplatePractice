using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyRewardsData : CaimQuestData
{
    
     public string title;
     public string description;
     public string icon;
}

public class DailyRewardsJSONData : JSONArrayData<DailyRewardsData>
{
    protected override DailyRewardsData ConvertArrayData(JSONNode json, int index)
    {
        DailyRewardsData result = LevelHelper.GetCaimQuestData<DailyRewardsData>(json);
        
        return result;
    }
}
