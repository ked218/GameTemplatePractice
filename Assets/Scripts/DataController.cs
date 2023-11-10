
using LTA.Data;
using LTA.DesignPattern;
using SimpleJSON;
using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class DataController : Singleton<DataController>
{
    public LevelJSONData levelData;

    public Dictionary<string,SpecialLevelJSONData> dic_dataName_Data = new Dictionary<string,SpecialLevelJSONData>();

    public Dictionary<string, RewardsLeaderBoardJSONData> dic_dataName_RewardsLeaderBoardDatas = new Dictionary<string,RewardsLeaderBoardJSONData>();

    public SpecialLevelsJSONData specialLevelsJSONData;

    public QuestJSONData questDatas;

    public ProcessRewardsJSONData starProcessRewardsJSONData;

    public DailyRewardsJSONData dailyRewardsDatas;

    public ProcessRewardsJSONArrayData eventProcessRewardsJSONArrayData;

    public AcheivementJSONData acheivementDatas;

    public FakeNameJSONData fakeNameDatas;

    public LeadBoardJSONData seaSonDatas;

    public void LoadData()
    {
        //try
        //{
            TextAsset textAsset = Resources.Load<TextAsset>("Data/Levels");
            levelData = new LevelJSONData();
            levelData.LoadData(new DataInfo(textAsset.name, textAsset.text));

            textAsset = Resources.Load<TextAsset>("Data/SpecialLevels");
            specialLevelsJSONData = new SpecialLevelsJSONData();
            specialLevelsJSONData.LoadData(new DataInfo(textAsset.name,textAsset.text));

            foreach(string key in specialLevelsJSONData.m_Data.Keys)
            {
                foreach (TypeSpecialLevelsData typeSpecialLevelsData in specialLevelsJSONData[key].typeLevels)
                {
                    textAsset = Resources.Load<TextAsset>("Data/" + typeSpecialLevelsData.DataName);
                    SpecialLevelJSONData specialLevelDatas = new SpecialLevelJSONData();
                    specialLevelDatas.LoadData(new DataInfo(textAsset.name, textAsset.text));
                    dic_dataName_Data.Add(typeSpecialLevelsData.DataName, specialLevelDatas);
                }
            }

            textAsset = Resources.Load<TextAsset>("Data/Quests");
            questDatas = new QuestJSONData();
            questDatas.LoadData(new DataInfo(textAsset.name, textAsset.text));

            textAsset = Resources.Load<TextAsset>("Data/StarsProcessRewards");
            starProcessRewardsJSONData = new ProcessRewardsJSONData();
            starProcessRewardsJSONData.LoadData(new DataInfo(textAsset.name,textAsset.text));

            textAsset = Resources.Load<TextAsset>("Data/DailyRewards");
            dailyRewardsDatas = new DailyRewardsJSONData();
            dailyRewardsDatas.LoadData(new DataInfo(textAsset.name,textAsset.text));

            textAsset = Resources.Load<TextAsset>("Data/EventsProcessRewards");
            eventProcessRewardsJSONArrayData = new ProcessRewardsJSONArrayData();
            eventProcessRewardsJSONArrayData.LoadData(new DataInfo(textAsset.name,textAsset.text));

            textAsset = Resources.Load<TextAsset>("Data/Acheivements");
            acheivementDatas = new AcheivementJSONData();
            acheivementDatas.LoadData(new DataInfo(textAsset.name, textAsset.text));

            textAsset = Resources.Load<TextAsset>("Data/FakeName");
            fakeNameDatas = new FakeNameJSONData();
            fakeNameDatas.LoadData(new DataInfo(textAsset.name,textAsset.text));

            textAsset = Resources.Load<TextAsset>("Data/Seasons");
            seaSonDatas = new LeadBoardJSONData();
            seaSonDatas.LoadData(new DataInfo(textAsset.name, textAsset.text));
            foreach (LeaderBoardData leaderBoardData in seaSonDatas)
            {
                textAsset = Resources.Load<TextAsset>("Data/" + leaderBoardData.DataName);
                RewardsLeaderBoardJSONData rewardsLeaderBoardJSONData = new RewardsLeaderBoardJSONData();
                rewardsLeaderBoardJSONData.LoadData(new DataInfo(textAsset.name, textAsset.text));
                dic_dataName_RewardsLeaderBoardDatas.Add(leaderBoardData.DataName, rewardsLeaderBoardJSONData);
            }
        //}
        //catch (Exception ex)
        //{
        //    Debug.LogError(ex.Message);
        //}


    }
}