using UnityEngine;
using LTA.Handle;
using System;

[ComponentType(typeof(DestroyHandle),"DestroyHandle","handles")]
public class DestroyHandle : MonoBehaviour,IHandle
{
    Action<IHandle> endHandle;

    public Action<IHandle> EndHandle { 
        set => endHandle = value;
    }

    public void Handle()
    {
        Destroy(this.gameObject);
        OnEndHandle();
    }

    void OnEndHandle() {
        if (endHandle != null)
        {
            endHandle(this);
        }
    }
}
