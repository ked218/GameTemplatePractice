using LTA.Base;
using LTA.DesignPattern;
using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class RewardsResourceProcessing : ProcessController
{
    
    public string ResourceKey;

    [SerializeField]
    ChestController prefabChest;

    [SerializeField]
    RectTransform content;

    [SerializeField]
    RectTransform contentRect;

    float maxX;
    public void Init(ProcessRewardsData processRewardsData)
    {
        maxX = contentRect.sizeDelta.x;
         //= DataController.Instance.starProcessRewardsJSONData[ResourceKey];
        MaxValue = processRewardsData.maxValue;
        MinValue = processRewardsData.minValue;
        CurrentValue = GlobalVar.GetRescoure(ResourceKey);
        contentRect.sizeDelta = new Vector2((float)((currentValue-minValue)/(maxValue-minValue))* maxX, contentRect.sizeDelta.y);
        Observer.Instance.AddObserver(ResourceKey, OnUpdateResource);
        Vector2 sizeContent = content.sizeDelta;
        foreach(ChestData chestData in processRewardsData.chests)
        {
            ChestController chest = Instantiate(prefabChest,content);
            ComponentDataInfo componentDataInfo = ComponentJSONData.GetComponentJSONData("conditions")["ResourceCondition"];
            ResourceConditionInfo conditionInfo = new ResourceConditionInfo();
            conditionInfo.resourceKey = ResourceKey;
            conditionInfo.minValue = chestData.value;
            ComponentInfo componentInfo = new ComponentInfo();
            componentInfo.type = componentDataInfo.type;
            componentInfo.data = conditionInfo;
            chest.Init(chestData);
            chest.AddCondition(componentInfo);
            chest.transform.localPosition = new Vector3((float)(sizeContent.x * (chestData.value - minValue) / (maxValue-minValue)), 0);
        }
    }

    protected override void OnUpdate(float value)
    {
        contentRect.sizeDelta = new Vector2((float)((value-minValue)/(maxValue-minValue))* maxX, contentRect.sizeDelta.y);
    }

    void OnUpdateResource(object data)
    {
        UpdateValue((int)data);    
    }

    private void OnDestroy()
    {
        Observer.Instance.RemoveObserver(ResourceKey, OnUpdateResource);
    }

}
