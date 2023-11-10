using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Effect;
using System;

public class EffectActive : BaseEffect
{
    [SerializeField]
    bool activeStateShow,aciveStateHide;


    public override void Hide()
    {
        HideEffect(null);
    }

    public override void HideEffect(Action endEffect)
    {
        gameObject.SetActive(aciveStateHide);
        if (endEffect != null)
            endEffect();
    }

    public override void HideEffect()
    {
        HideEffect(null);
    }

    public override void ShowEffect(Action endEffect)
    {
        gameObject.SetActive(activeStateShow);
        if (endEffect != null)
            endEffect();
    }

    public override void ShowEffect()
    {
        ShowEffect(null);
    }

}
