using SimpleJSON;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[System.Serializable]
public class ChestData : CaimQuestData
{
    public int value;
    public string iconChest;
    public string unLockChest;
    public string iconResource;
}

[System.Serializable]
public class ProcessRewardsData
{
    public string resourceKey;
    public int minValue = 0;
    public int maxValue;
    public ChestData[] chests;
    public ProcessRewardsData(string resourceKey, int maxValue)
    {
        this.resourceKey = resourceKey;
        this.maxValue = maxValue;
    }
}

public class ProcessRewardsJSONData : JSONObjectData<ProcessRewardsData>
{
    protected override ProcessRewardsData ConvertObjectData(JSONNode json)
    {
        
        ProcessRewardsData processRewardsData = new ProcessRewardsData(json["resourceKey"], json["maxValue"].AsInt);
        if (json["minValue"] != null)
        {
            processRewardsData.minValue = json["minValue"].AsInt;
        }
        JSONArray array = json["chests"].AsArray;
        List<ChestData> chests = new List<ChestData>();
        foreach (JSONNode json1 in array)
        {
            ChestData data = LevelHelper.GetCaimQuestData<ChestData>(json1);
            chests.Add(data);
        }
        processRewardsData.chests = chests.ToArray();
        Debug.Log(processRewardsData.chests.Length);
        return processRewardsData; 
    }
}
public class ProcessRewardsJSONArrayData : JSONArrayData<ProcessRewardsData>
{
    protected override ProcessRewardsData ConvertArrayData(JSONNode json, int index)
    {
        ProcessRewardsData processRewardsData = new ProcessRewardsData(json["resourceKey"], json["maxValue"].AsInt);
        if (json["minValue"] != null)
        {
            processRewardsData.minValue = json["minValue"].AsInt;
        }
        JSONArray array = json["chests"].AsArray;
        List<ChestData> chests = new List<ChestData>();
        foreach (JSONNode json1 in array)
        {
            ChestData data = LevelHelper.GetCaimQuestData<ChestData>(json1);
            chests.Add(data);
        }
        processRewardsData.chests = chests.ToArray();
        return processRewardsData;
    }
}