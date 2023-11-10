using LTA.Handle;
using LTA.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MyLeaderBoardElementController : CaimQuestController
{
    [SerializeField]
    TextMeshProUGUI txtRank, txtName, txtScore;
    [SerializeField]
    ButtonController btnCaim;


    public void Init(int rank,RewardsLeaderBoardJSONData rewardsLeaderBoardDatas)
    {
        btnCaim.gameObject.SetActive(rank < rewardsLeaderBoardDatas.Count);
        txtRank.text = (rank + 1).ToString();
        //foreach (IHandle handle in caimHandles)
        //{
        //    Destroy((MonoBehaviour)handle);
        //}
        //caimHandles.Clear();
        if (rank < rewardsLeaderBoardDatas.Count)
        {
            Init(rewardsLeaderBoardDatas[rank - 1]);
            btnCaim.OnClick((btn) =>
            {
                DoCaim();
            });
        }
    }

    protected override void ClearCaimQuest()
    {
        btnCaim.gameObject.SetActive(false);
    }

    protected override void Lock()
    {
        btnCaim.gameObject.SetActive(false);
    }

    protected override void UnClearCaimQuest()
    {
        btnCaim.gameObject.SetActive(true);
    }

    protected override void Unlock()
    {
        btnCaim.gameObject.SetActive(true);
    }
}
