using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LTA.Base;
using System;
using TMPro;
using LTA.Effect;

namespace LTA.UI.Effect
{
    //[RequireComponent(typeof(TextMeshProUGUI))]
    public class EffectChangeText : TweenEffect
    {
        TextMeshProUGUI textMeshPro;

        [SerializeField]
        String effectText;
        String originText;


        private void Awake()
        {
            textMeshPro = GetComponent<TextMeshProUGUI>();
            originText = textMeshPro.text;
        }

        public override void Hide()
        {
            textMeshPro.text = originText;
        }
        
        void UpdateText(float value)
        {
            
        }
        public override void HideEffect(Action endEffect)
        {
            Behaviour.UpdateValue(0, 1, UpdateText, endEffect);
            textMeshPro.text = originText;
        }

        public override void ShowEffect(Action endEffect)
        {
            Behaviour.UpdateValue(0, 1, UpdateText, endEffect);
            textMeshPro.text = effectText;
        }
        

        public override void ShowEffect()
        {
            Behaviour.UpdateValue(0, 1, UpdateText);
            textMeshPro.text = effectText;
        }

        public override void HideEffect()
        {
            Behaviour.UpdateValue(0, 1, UpdateText);
            textMeshPro.text = originText;
        }
    }

}
