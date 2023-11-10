using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Effect;
using System;

public class EffectVibrate : BaseEffect
{
    public override void Hide()
    {
        
    }

    public override void HideEffect(Action endEffect)
    {
        
    }

    public override void HideEffect()
    {
        
    }

    public override void ShowEffect(Action endEffect)
    {
#if !UNITY_EDITOR
        Handheld.Vibrate();
#endif
        if (endEffect != null)
            endEffect();
    }

    public override void ShowEffect()
    {
        ShowEffect(null);
    }

}
