using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.DesignPattern;
public class FocusController : MonoBehaviour
{
    public void SetPos(Transform level)
    {
        transform.SetParent(level);
        transform.localPosition = Vector3.zero;
    }
}

public class Focus : SingletonMonoBehaviour<FocusController>
{

}
