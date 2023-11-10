using UnityEngine;
using LTA.Handle;
using System;
using LTA.DesignPattern;

[ComponentType(typeof(DestroyPoolHandle),"DestroyPoolHandle","handles")]
public class DestroyPoolHandle : MonoBehaviour,IHandle,IOwn
{
    Action<IHandle> endHandle;

    public Action<IHandle> EndHandle { 
        set => endHandle = value;
    }

    Type ownType;

    MonoBehaviour own;

    public Type OwnType { set => ownType = value; }
    public MonoBehaviour Own { set => own = value; }

    public void Handle()
    {
        if (own == null)
        {
            Destroy(gameObject);
            OnEndHandle();
            return;
        }
        PoolingObject.DestroyPooling(own, ownType);
        OnEndHandle();
    }

    void OnEndHandle() {
        if (endHandle != null)
        {
            endHandle(this);
        }
    }
}
