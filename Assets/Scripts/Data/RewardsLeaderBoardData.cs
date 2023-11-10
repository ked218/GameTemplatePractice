using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardsLeaderBoardData : CaimQuestData
{
    public RewardData[] rewards;
}

public class RewardsLeaderBoardJSONData : JSONArrayData<RewardsLeaderBoardData>
{
    protected override RewardsLeaderBoardData ConvertArrayData(JSONNode json, int index)
    {
        return LevelHelper.GetCaimQuestData<RewardsLeaderBoardData>(json);
        //RewardsLeaderBoardData rewardsLeaderBoardData = JsonUtility.FromJson<RewardsLeaderBoardData>(json.ToString());
        //rewardsLeaderBoardData.caimHandles = ComponentHelper.ConvertComponentInfos<ComponentInfo>("handles", json["caimHandles"]);
        //return rewardsLeaderBoardData;
    }
}