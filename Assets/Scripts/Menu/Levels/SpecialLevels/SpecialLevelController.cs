using System.Collections.Generic;
using UnityEngine;
using LTA.Condition;
using UnityEngine.UI;
using LTA.UI;
using TMPro;

public class SpecialLevelController : BaseLevelController
{

    [SerializeField]
    RewardsController rewards;

    string dataName = "";

    [SerializeField]
    GameObject iconLock;

    [SerializeField]
    TextMeshProUGUI txtMessage;

    [SerializeField]
    ButtonController btnPlay;

    public void Init(string dataName,int level)
    {
        this.dataName = dataName;
        Init(level);
        btnPlay.OnClick((btn) =>
        {
            GlobalVar.winHandles = specialLevelData.winHandles;
            SceneController.OpenScene("GamePlay");
        });
    }
    SpecialLevelData specialLevelData;

    protected override LevelData GetLevelData(int level)
    {
        specialLevelData = DataController.Instance.dic_dataName_Data[dataName][level-1];
        rewards.Init(specialLevelData.rewards);
        return specialLevelData;
    }

        

    protected override void Lock()
    {
        iconLock.SetActive(true);
        txtMessage.text = specialLevelData.messageError;
        rewards.gameObject.SetActive(false);
        txtMessage.gameObject.SetActive(true);
        btnPlay.gameObject.SetActive(false);
    }

    protected override void Unlock()
    {
        iconLock.SetActive(false);
        txtMessage.text = specialLevelData.messageError;
        txtMessage.gameObject.SetActive(false);
        rewards.gameObject.SetActive(true);
        btnPlay.gameObject.SetActive(true);
    }
}
