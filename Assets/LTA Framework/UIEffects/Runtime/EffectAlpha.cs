using UnityEngine;
using UnityEngine.UI;
using System;
using LTA.Effect;

namespace LTA.UI.Effect
{
    public class EffectAlpha : TweenEffect
    {
        Graphic graphic;

        [SerializeField]
        float originAlpha,effectAlpha;

        Color originColor;

        private void Awake()
        {
            graphic = GetComponent<Graphic>();
            originColor = graphic.color;
        }

        public override void HideEffect(Action endEffect)
        {
            Behaviour.UpdateValue(graphic.color.a, originAlpha, UpdateAlpha,endEffect);
        }

        public override void ShowEffect(Action endEffect)
        {
            Behaviour.UpdateValue(graphic.color.a, effectAlpha, UpdateAlpha,endEffect);
        }

        void UpdateAlpha(float value)
        {
            graphic.color = new Color(originColor.r, originColor.g, originColor.b, value);
        }

        public override void Hide()
        {
            graphic.color = new Color(originColor.r, originColor.g, originColor.b,originAlpha);
        }

        public override void ShowEffect()
        {
            Behaviour.UpdateValue(graphic.color.a, effectAlpha,UpdateAlpha);
        }

        public override void HideEffect()
        {
            Behaviour.UpdateValue(graphic.color.a, originAlpha,UpdateAlpha);
        }
    }

}
