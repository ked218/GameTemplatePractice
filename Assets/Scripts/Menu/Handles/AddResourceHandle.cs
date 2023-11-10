using UnityEngine;
using LTA.Handle;
using System;

[System.Serializable]
public class AddResourceHandleInfo
{
    public string key;
    public int value;
}

[ComponentType(typeof(AddResourceHandle),typeof(AddResourceHandleInfo),"AddResourceHandle","handles")]
public class AddResourceHandle : MonoBehaviour,IHandle,ISetInfo
{
    AddResourceHandleInfo info;

    public object Info
    {
        set
        {
            info = (AddResourceHandleInfo)value;
        }
    }

    Action<IHandle> endHandle;

    public Action<IHandle> EndHandle { 
        set => endHandle = value;
    }

    public void Handle()
    {
        GlobalVar.AddRescoure(info.key, info.value);
        OnEndHandle();   
    }

    void OnEndHandle() {
        if (endHandle != null)
        {
            endHandle(this);
        }
    }
}
