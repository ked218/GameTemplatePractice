using LTA.Data;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConditionData
{
    public ComponentInfo[] conditions;
    
    public string messageError;
}

[System.Serializable]
public class LevelData : ConditionData
{
    public string pathLevel;
    public string playError;
    public ComponentInfo[] playConditions;
    public ComponentInfo[] playHandles;
    public ComponentInfo[] winHandles;
}

[System.Serializable]
public class SpecialLevelData : LevelData
{
    public RewardData[] rewards;
}

[System.Serializable]
public class SpecialLevelsData : ConditionData
{
    public string levelName;
    public TypeSpecialLevelsData[] typeLevels;
    

}

[System.Serializable]
public class TypeSpecialLevelsData : ConditionData
{
    public string levelName;
    public string DataName;

}

public class LevelJSONData : JSONArrayData<LevelData>
{
    protected override LevelData ConvertArrayData(JSONNode json, int index)
    {
        LevelData levelData = LevelHelper.GetLevelData<LevelData>(json);
        levelData.playHandles = ComponentHelper.ConvertComponentInfos<ComponentInfo>("handles", json["playHandles"]);
        levelData.playConditions = ComponentHelper.ConvertComponentInfos<ComponentInfo>("conditions", json["playConditions"]);
        return levelData;
    }
}

public class SpecialLevelJSONData : JSONArrayData<SpecialLevelData>
{
    protected override SpecialLevelData ConvertArrayData(JSONNode json, int index)
    {
        return LevelHelper.GetLevelData<SpecialLevelData>(json);
    }
}

public class SpecialLevelsJSONData : JSONObjectData<SpecialLevelsData>
{

    protected override SpecialLevelsData ConvertObjectData(JSONNode json)
    {
        SpecialLevelsData specialLevelsData = LevelHelper.GetConditionData<SpecialLevelsData>("conditions",json);
        JSONArray array = json["typeLevels"].AsArray;
        for (int i = 0; i < array.Count; i++)
        {
            specialLevelsData.typeLevels[i].conditions = ComponentHelper.ConvertComponentInfos<ComponentInfo>("conditions", array[i]["conditions"]);
        }
        return specialLevelsData;
    }
} 

//public class MutilSpecialLevelsJSONData : MutilData<SpecialLevelsJSONData>
//{
//    public MutilSpecialLevelsJSONData()
//    {
//        DataInfo[] dataInfos = DataHelper.DataManager["SpecialLevels"];
//        LoadData(dataInfos);
//    }
//}