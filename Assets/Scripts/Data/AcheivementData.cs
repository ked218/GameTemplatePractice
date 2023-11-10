using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcheivementData : CaimQuestData
{
    public ComponentInfo[] openConditions;
    public string title;
    public string icon;
    public RewardData[] rewards;
}

public class AcheivementJSONData : JSONArrayData<AcheivementData>
{
    protected override AcheivementData ConvertArrayData(JSONNode json, int index)
    {
        return LevelHelper.GetAchievementData<AcheivementData>(json);
    }
}