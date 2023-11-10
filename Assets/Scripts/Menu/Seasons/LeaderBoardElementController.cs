using LTA.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderBoardElementInfo
{
    public string name;
    public int score;
    public LeaderBoardElementInfo(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}

public class LeaderBoardElementController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI txtRank, txtName, txtScore;

    [SerializeField]
    RewardsController rewards;

    public void Init(int rank,LeaderBoardElementInfo info,RewardData[] rewardDatas)
    {
        txtRank.text = rank.ToString();
        txtName.text = info.name;
        txtScore.text = info.score.ToString();
        rewards.Init(rewardDatas);
    }
}
