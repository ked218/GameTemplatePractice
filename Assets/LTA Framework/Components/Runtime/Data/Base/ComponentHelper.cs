using SimpleJSON;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using LTA.Error;
using LTA.Data;

public interface ISetInfo
{
    object Info
    {
        set;
    }
}

public interface ISetInfo<T> : ISetInfo
{
    T OwnInfo
    {
        get;
    }
}

public class ComponentType
{
    public const string Components = "Components";
    public const string NonEntities = "NonEntities";
    public const string Entities = "Entities";
}

public class ComponentHelper
{
    static Dictionary<string, MutilComponentData> dic_TypeData_ComponentData = new Dictionary<string, MutilComponentData>();
    public static MutilComponentData GetComponentData(string typeNonEntity)
    {
        try
        {
            if (!dic_TypeData_ComponentData.ContainsKey(typeNonEntity))
            {
                dic_TypeData_ComponentData.Add(typeNonEntity, new MutilComponentData(typeNonEntity));
            }
            return dic_TypeData_ComponentData[typeNonEntity];
        }
        catch (Exception ex)
        {
            throw new ErrorException("Error with TypeNonEntity : " + typeNonEntity + " : " + ex.Message);
        }
    }
    static Dictionary<string, MutilComponentsData> dic_TypeData_ComponentsData = new Dictionary<string, MutilComponentsData>();
    public static MutilComponentsData GetComponentsData(string typeNonEntity)
    {
        try
        {
            if (!dic_TypeData_ComponentsData.ContainsKey(typeNonEntity))
            {
                dic_TypeData_ComponentsData.Add(typeNonEntity, new MutilComponentsData(typeNonEntity));
            }
            return dic_TypeData_ComponentsData[typeNonEntity];
        }
        catch (Exception ex)
        {
            throw new ErrorException("Error with TypeNonEntity : " + typeNonEntity + " : " + ex.Message);
        }
    }
    public static Component AddComponent(GameObject gameObject, ComponentInfo componentInfo, Action<Component> editComponent = null)
    {
        
        Component component = gameObject.AddComponent(componentInfo.type);
        if (componentInfo.data == null)
        {
            if (editComponent != null)
                editComponent(component);
            return component;
        }
        ISetInfo setInfo = (ISetInfo)component;
        setInfo.Info = componentInfo.data;
        if (editComponent != null)
            editComponent(component);
        return component;
    }

    public const string ERROR_COMPONENT_TYPE_MESSAGE = "Assembly {0} can not load Type is {1} \n data is {2}";
    public static ComponentDataInfo GetComponentDataInfo(JSONNode json)
    {
        Assembly assembly = Assembly.Load("Assembly-CSharp");
        if (json["assemblyName"] != null)
        {
            assembly = Assembly.Load(json["assemblyName"]);
        }
        if (json["type"] == null) throw new JSONObjectMissingKeyException<ComponentInfo>("type", json);
        Type type = assembly.GetType(json["type"]);
        if (type == null) throw new Exception(String.Format(ERROR_COMPONENT_TYPE_MESSAGE, assembly.GetName().Name, json["type"], json.ToString()));
        if (json["typeInfo"] == null) return new ComponentDataInfo(type);
        if (json["assemblyNameInfo"] != null)
        {
            assembly = Assembly.Load(json["assemblyNameInfo"]);
        }
        Type typeInfo = assembly.GetType(json["typeInfo"]);
        if (typeInfo == null) throw new Exception(String.Format(ERROR_COMPONENT_TYPE_MESSAGE, assembly.GetName().Name, json["typeInfo"], json.ToString()));
        return new ComponentDataInfo(type, typeInfo);
    }

    const string WARRNING_COMPONENT_MISSING_KEY_DATA = "Component Type is {0} with TypeInfo is {1} is missing data \n data is {2}";


    public static T ConvertComponentInfo<T>(ComponentDataInfo componentDataInfo,JSONNode json) where T : ComponentInfo,new()
    {
        T componentInfo = new T();
        componentInfo.type = componentDataInfo.type;
        if (componentDataInfo.typeInfo == null) return componentInfo;
        if (json["data"] == null)
        {
            throw new Exception(String.Format(WARRNING_COMPONENT_MISSING_KEY_DATA, componentInfo.type.Name, componentDataInfo.typeInfo.Name, json.ToString()));
        }
        componentInfo.data = JsonUtility.FromJson(json["data"].ToString(), componentDataInfo.typeInfo);
        return componentInfo;
    }
    public static T[] ConvertComponentInfos<T>(string key,JSONNode json) where T : ComponentInfo, new()
    {
        JSONArray array = json.AsArray;
        List<T> componentInfos = new List<T>();
        foreach (JSONNode json1 in array)
        {
            ComponentDataInfo componentDataInfo = ComponentJSONData.GetComponentJSONData(key)[json1["ComponentName"]];
            T componentInfo = ConvertComponentInfo<T>(componentDataInfo, json1);
            componentInfos.Add(componentInfo);
        }
        return componentInfos.ToArray();
    }
}
