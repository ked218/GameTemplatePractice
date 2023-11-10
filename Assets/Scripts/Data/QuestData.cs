using JetBrains.Annotations;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CaimQuestData : ConditionData
{
    public ComponentInfo[] caimHandles;
    public ComponentInfo[] clearConditions;
}


[System.Serializable]
public class QuestData : AcheivementData
{
    public ComponentInfo[] goHandles;

}
public class QuestJSONData : JSONArrayData<QuestData>
{
    protected override QuestData ConvertArrayData(JSONNode json, int index)
    {
        QuestData result = LevelHelper.GetAchievementData<QuestData>(json);
        result.goHandles = ComponentHelper.ConvertComponentInfos<ComponentInfo>("handles", json["goHandles"]);
        
        return result;
    }

}
