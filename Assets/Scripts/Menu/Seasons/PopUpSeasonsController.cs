using LTA.Condition;
using LTA.Handle;
using LTA.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor;
using UnityEngine;

public class PopUpSeasonsController : BasePopUp
{
    [SerializeField]
    LeaderBoardController leaderBoardController;

    [SerializeField]
    TextMeshProUGUI txtTitle,txtRank,txtScore;
    [SerializeField]
    MyLeaderBoardElementController myLeaderBoardElementController;

    public void Init(LeaderBoardData leaderBoardData)
    {
        int myScore = GlobalVar.GetRescoure(leaderBoardData.typeResource);
        txtTitle.text = leaderBoardData.typeName;
        txtScore.text = myScore.ToString();
        RewardsLeaderBoardJSONData rewardsLeaderBoardDatas = DataController.Instance.dic_dataName_RewardsLeaderBoardDatas[leaderBoardData.DataName];
        int rank = leaderBoardController.Init(rewardsLeaderBoardDatas, leaderBoardData.fakeRange,myScore);
        myLeaderBoardElementController.Init(rank, rewardsLeaderBoardDatas);
    }

}
