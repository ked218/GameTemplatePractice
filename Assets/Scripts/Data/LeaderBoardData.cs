using LTA.Data;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardData : ConditionData
{
    public string typeName;
    public string typeResource;
    public int[] fakeRange;
    public string DataName;
}

public class LeadBoardJSONData : JSONArrayData<LeaderBoardData>
{
    protected override LeaderBoardData ConvertArrayData(JSONNode json, int index)
    {
        return LevelHelper.GetConditionData<LeaderBoardData>("conditions", json);
    }
}
