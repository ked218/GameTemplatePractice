using LTA.DesignPattern;
using LTA.GameFollow;
using LTA.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnObseverKey : BaseButtonController
{
    [SerializeField]
    string key;

    protected override void OnClick()
    {
        Observer.Instance.Notify(key);
    }
}
