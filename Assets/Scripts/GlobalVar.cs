using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.DesignPattern;
using LTA.Handle;
//public class GlobalKey
//{
//    public const string UpLevel = "UpLevel";
//}

public class LevelKey
{
    public const string MainLevel = "MainLevel";
    public const string DailyLevels_Level_Reward = "DailyLevels_Level_Reward";
}

public class ResourceKey
{
    public const string Gold = "Gold";
    public const string Star = "Star";
}

public class GlobalVar
{
    static Dictionary<string,int> dic_Name_Resources = new Dictionary<string,int>();

    static Dictionary<string, int> dic_TypeLevel_CurrentLevel = new Dictionary<string, int>();

    public static ComponentInfo[] winHandles;

    //static int currentLevel = 1;

    public static int GetRescoure(string key)
    {
        if (!dic_Name_Resources.ContainsKey(key))
        {
            dic_Name_Resources.Add(key, 0);
        }
        return dic_Name_Resources[key];
    }

    public static void SetRescoure(string key,int value)
    {
        if (!dic_Name_Resources.ContainsKey(key))
        {
            dic_Name_Resources.Add(key, value);
            Observer.Instance.Notify(key, dic_Name_Resources[key]);
            return;
        }
        dic_Name_Resources[key] = value;
        Observer.Instance.Notify(key, dic_Name_Resources[key]);
    }

    public static void AddRescoure(string key, int value)
    {
        if (!dic_Name_Resources.ContainsKey(key))
        {
            dic_Name_Resources.Add(key, value);
            Observer.Instance.Notify(key, dic_Name_Resources[key]);
            return;
        }
        dic_Name_Resources[key] += value;
        Observer.Instance.Notify(key, dic_Name_Resources[key]);
    }
    public static void MinusRescoure(string key, int value)
    {
        if (!dic_Name_Resources.ContainsKey(key))
        {
            dic_Name_Resources.Add(key, value);
            Observer.Instance.Notify(key, dic_Name_Resources[key]);
            return;
        }
        dic_Name_Resources[key] += value;
        Observer.Instance.Notify(key, dic_Name_Resources[key]);
    }

    public static int GetCurrentLevel(string typeLevel)
    {
        if (!dic_TypeLevel_CurrentLevel.ContainsKey(typeLevel))
        {
            dic_TypeLevel_CurrentLevel.Add(typeLevel, 1);
        }
        return dic_TypeLevel_CurrentLevel[typeLevel];
    }

    public static void UpCurrentLevel(string typeLevel)
    {
        if (!dic_TypeLevel_CurrentLevel.ContainsKey(typeLevel))
        {
            dic_TypeLevel_CurrentLevel.Add(typeLevel, 1);
            Observer.Instance.Notify(typeLevel, dic_TypeLevel_CurrentLevel[typeLevel]);
        }
        dic_TypeLevel_CurrentLevel[typeLevel]++;
        Observer.Instance.Notify(typeLevel, dic_TypeLevel_CurrentLevel[typeLevel]);
    }

    //public static int CurrentLevel
    //{
    //    set
    //    {
    //        currentLevel = value;
    //        Observer.Instance.Notify(GlobalKey.UpLevel, currentLevel);
    //    }
    //    get
    //    {
    //        return currentLevel;
    //    }
    //}
}
