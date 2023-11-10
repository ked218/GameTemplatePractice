using LTA.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LTA.Condition;

public class TabsSpecialLevelController : TabBarController
{
    [SerializeField]
    TabController prefabTab;

    [SerializeField]
    SpecialLevelsController specialLevelsController;

    [SerializeField]
    GameObject iconLock;
    [SerializeField]
    TextMeshProUGUI txtMessage;

    TypeSpecialLevelsData[] typeSpecialLevelsDatas;
    List<List<ICondition>> listConditions = new List<List<ICondition>>();
    protected override void Start()
    {
        
    }

    public void Init(TypeSpecialLevelsData[] typeSpecialLevelsDatas)
    {
        this.typeSpecialLevelsDatas = typeSpecialLevelsDatas;
        List<TabController> tabs = new List<TabController>();
        foreach(TypeSpecialLevelsData typeSpecialLevelsData in typeSpecialLevelsDatas)
        {
            List<ICondition> conditions = new List<ICondition>();
            foreach (ComponentInfo componentInfo in typeSpecialLevelsData.conditions)
            {
                ComponentHelper.AddComponent(gameObject, componentInfo, (component) =>
                {
                    ICondition condition = (ICondition)component;
                    conditions.Add(condition);
                });
            }
            TabController tab = Instantiate(prefabTab,transform);
            tab.GetComponentInChildren<TextMeshProUGUI>().text = typeSpecialLevelsData.levelName;
            tabs.Add(tab);
            listConditions.Add(conditions);
        }
        arrTabs = tabs.ToArray();
        Init();
        OnClickTab(0);
    }

    public override void OnClickTab(int index)
    {
        base.OnClickTab(index);
        List<ICondition> conditions = listConditions[index];
        TypeSpecialLevelsData typeSpecialLevelsData = typeSpecialLevelsDatas[index];
        foreach (ICondition condition in conditions)
        {
            if (!condition.IsSuitable)
            {
                specialLevelsController.gameObject.SetActive(false);
                iconLock.gameObject.SetActive(true);
                txtMessage.text = typeSpecialLevelsData.messageError;
                txtMessage.gameObject.SetActive(true);
                return;
            }
        }
        specialLevelsController.gameObject.SetActive(true);
        iconLock.gameObject.SetActive(false);
        txtMessage.gameObject.SetActive(false);
        specialLevelsController.Init(typeSpecialLevelsDatas[index].DataName);

    }
}
