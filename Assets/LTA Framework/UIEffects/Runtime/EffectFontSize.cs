using LTA.Effect;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace LTA.UI.Effect
{
    public class EffectFontSize : TweenEffect
    {
        [SerializeField]
        TMP_Text text;

        [SerializeField]
        float originFontSize,effectFontSize;

        private void Awake()
        {
            text = GetComponent<TMP_Text>();
        }

        public override void Hide()
        {
            text.fontSize = originFontSize;
        }

        public override void HideEffect(Action endEffect)
        {
            Behaviour.UpdateValue(text.fontSize, originFontSize,UpdateValue,endEffect);
        }

        public override void HideEffect()
        {
            Behaviour.UpdateValue(text.fontSize, originFontSize, UpdateValue);
        }

        public override void ShowEffect(Action endEffect)
        {
            Behaviour.UpdateValue(text.fontSize, effectFontSize, UpdateValue, endEffect);
        }

        public override void ShowEffect()
        {
            Behaviour.UpdateValue(text.fontSize, effectFontSize, UpdateValue);
        }

        void UpdateValue(float value)
        {
            text.fontSize = value;
        }
    }
}
