using LTA.Condition;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHelper 
{
    public static bool CheckCondition(List<ICondition> conditions)
    {
        foreach (ICondition condition1 in conditions)
        {
            if (!condition1.IsSuitable) return false;
        }
        return true;
    }

    public static bool CheckCondition(ICondition[] conditions)
    {
        foreach (ICondition condition1 in conditions)
        {
            if (!condition1.IsSuitable) return false;
        }
        return true;
    }

    public static bool CheckLevel(GameObject gameObject,int level)
    {
        LevelData levelData = DataController.Instance.levelData[level - 1];
        if (levelData.conditions == null || levelData.conditions.Length == 0)
        {
            return true;
        }
        List<ICondition> conditions = new List<ICondition>();
        foreach (ComponentInfo componentInfo in levelData.conditions)
        {
            ComponentHelper.AddComponent(gameObject, componentInfo, (component) =>
            {
                ICondition condition = (ICondition)component;
                conditions.Add(condition);
            });
        }
        return CheckCondition(conditions);
    }

    public static T GetConditionData<T>(string key,JSONNode json) where T : ConditionData
    {
        T levelData = JsonUtility.FromJson<T>(json.ToString());
        levelData.conditions = ComponentHelper.ConvertComponentInfos<ComponentInfo>("conditions", json[key]);
        return levelData;
    }

    public static T GetAchievementData<T>(JSONNode json) where T : AcheivementData
    {
        T result = GetCaimQuestData<T>(json);
        result.openConditions = ComponentHelper.ConvertComponentInfos<ComponentInfo>("conditions", json["openConditions"]);
        return result;
    }

    public static T GetCaimQuestData<T>(JSONNode json) where T : CaimQuestData
    {
        T levelData = GetConditionData<T>("conditions",json);
        levelData.caimHandles = ComponentHelper.ConvertComponentInfos<ComponentInfo>("handles", json["caimHandles"]);
        levelData.clearConditions = ComponentHelper.ConvertComponentInfos<ComponentInfo>("conditions", json["clearConditions"]);
        return levelData;
    }

    public static T GetLevelData<T>(JSONNode json) where T : LevelData
    {
        T levelData = GetConditionData<T>("conditions", json);
        levelData.winHandles = ComponentHelper.ConvertComponentInfos<ComponentInfo>("handles", json["winHandles"]);
        return levelData;
    }
}
