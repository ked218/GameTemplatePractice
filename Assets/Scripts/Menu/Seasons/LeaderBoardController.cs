using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LeaderBoardController : MonoBehaviour
{
    [SerializeField]
    LeaderBoardElementController prefabLeaderBoardElement;

    [SerializeField]
    Transform content;

    public List<LeaderBoardElementInfo> list;

    public int Init(RewardsLeaderBoardJSONData leaderBoards, int[] fakeRange,int myScore)
    {
        int result = leaderBoards.Count;
        FakeNameJSONData fakeNameDatas = DataController.Instance.fakeNameDatas;
        int count = leaderBoards.Count;
        int countFakeName = fakeNameDatas.Count;
        int randomStep = countFakeName / count;
        int nextStep = Random.Range(0, randomStep);
        list = new List<LeaderBoardElementInfo>(); 
        for(int i = nextStep; i< countFakeName-1; i += nextStep)
        {
            if (list.Count == leaderBoards.Count) break;
            LeaderBoardElementInfo leaderBoardElement = new LeaderBoardElementInfo(fakeNameDatas[i].US_UK, Random.Range(fakeRange[0], fakeRange[1]));
            list.Add(leaderBoardElement);
            nextStep = Random.Range(1, randomStep);
        }
        if (list.Count != leaderBoards.Count)
        {
            Debug.LogError("Season Data is more fakeName!Please Add More FakeName");
        }
        list.Sort((x, y)=>
        {
            return  y.score - x.score;
        });

        for (int i =0;i< list.Count;i++) {
            LeaderBoardElementInfo leaderBoardElement = list[i];
            if (leaderBoardElement.score <= myScore)
            {
                leaderBoardElement.name = "You";
                leaderBoardElement.score = myScore;
                result = i;
                break;
            }
        }

        for (int i = 0; i < list.Count; i++)
        {
            LeaderBoardElementController leaderBoardElementController = Instantiate(prefabLeaderBoardElement, content);
            leaderBoardElementController.Init(i + 1, list[i], leaderBoards[i].rewards);
        }
        return result;
    }
}
