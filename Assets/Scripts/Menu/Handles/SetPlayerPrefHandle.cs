using UnityEngine;
using LTA.Handle;
using System;

public class TypeValue
{
    public const string Integer = "integer";
    public const string Float = "float";
    public const string String = "string";
}
[System.Serializable]
public class PlayerPrefInfo 
{
    public string key;
    public string typeValue;
    public string stringValue;
}

[System.Serializable]
public class SetPlayerPrefHandleInfo : PlayerPrefInfo
{
    public int intValue;
    public float floatValue;
}

[ComponentType(typeof(SetPlayerPrefHandle),typeof(SetPlayerPrefHandleInfo),"SetPlayerPrefHandle","handles")]
public class SetPlayerPrefHandle : MonoBehaviour,IHandle,ISetInfo
{
    SetPlayerPrefHandleInfo info;

    public object Info
    {
        set
        {
            info = (SetPlayerPrefHandleInfo)value;
        }
    }

    Action<IHandle> endHandle;

    public Action<IHandle> EndHandle { 
        set => endHandle = value;
    }

    public void Handle()
    {
        switch (info.typeValue)
        {
            case TypeValue.Integer:
                PlayerPrefs.SetInt(info.key,info.intValue);
                break;
            case TypeValue.String:
                PlayerPrefs.SetString(info.key,info.stringValue);
                break;
            case TypeValue.Float:
                PlayerPrefs.SetFloat(info.key,info.floatValue);
                break;

        }
        OnEndHandle();
    }

    void OnEndHandle() {
        if (endHandle != null)
        {
            endHandle(this);
        }
    }
}
