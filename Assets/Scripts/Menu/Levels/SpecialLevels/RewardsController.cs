using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class RewardsController : MonoBehaviour
{
    [SerializeField]
    RewardController prefabReward;

    List<RewardController> rewards = new List<RewardController>();

    public void Init(RewardData[] rewardDatas)
    {
        foreach(RewardController rewardController in rewards)
        {
            rewardController.gameObject.SetActive(false);
        }
        int count = 0;
        foreach(RewardData data in rewardDatas)
        {
            RewardController reward;
            if (count < rewards.Count)
            {
                reward = rewards[count];
                reward.gameObject.SetActive(true);
            }
            else
            {
                reward = Instantiate(prefabReward, transform);
                rewards.Add(reward);
            }
            reward.Init(data);
            count++;
        }
    }
}
