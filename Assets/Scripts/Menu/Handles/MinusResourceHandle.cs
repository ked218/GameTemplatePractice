using UnityEngine;
using LTA.Handle;
using System;

[System.Serializable]
public class MinusResourceHandleInfo
{
    public string key;
    public int value;
}

[ComponentType(typeof(MinusResourceHandle),typeof(MinusResourceHandleInfo),"MinusResourceHandle","handles")]
public class MinusResourceHandle : MonoBehaviour,IHandle,ISetInfo
{
    MinusResourceHandleInfo info;

    public object Info
    {
        set
        {
            info = (MinusResourceHandleInfo)value;
        }
    }

    Action<IHandle> endHandle;

    public Action<IHandle> EndHandle {
        set => endHandle = value;
    }

    public void Handle()
    {
        GlobalVar.MinusRescoure(info.key, info.value);
        OnEndHandle();
    }

    void OnEndHandle() {
        if (endHandle != null)
        {
            endHandle(this);
        }
    }
}
