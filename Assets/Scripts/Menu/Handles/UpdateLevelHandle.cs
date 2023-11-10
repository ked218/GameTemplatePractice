using UnityEngine;
using LTA.Handle;
using System;

[System.Serializable]
public class UpdateLevelHandleInfo
{
    public string levelKey = LevelKey.MainLevel;
}

[ComponentType(typeof(UpdateLevelHandle),typeof(UpdateLevelHandleInfo),"UpdateLevelHandle","handles")]
public class UpdateLevelHandle : MonoBehaviour,IHandle,ISetInfo
{
    UpdateLevelHandleInfo info;

    public object Info
    {
        set
        {
            info = (UpdateLevelHandleInfo)value;
        }
    }

    Action<IHandle> endHandle;

    public Action<IHandle> EndHandle { 
        set => endHandle = value;
    }

    public void Handle()
    {
        GlobalVar.UpCurrentLevel(info.levelKey);
        OnEndHandle();
    }

    void OnEndHandle() {
        if (endHandle != null)
        {
            endHandle(this);
        }
    }
}
