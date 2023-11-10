using System.Collections;
using System.Collections.Generic;
using LTA.Base;
using UnityEngine;
using System;
namespace LTA.Effect
{
    [DisallowMultipleComponent]
    public class EffectSound : BaseEffect
    {
        [SerializeField]
        public TypeEffect typeEffect
        {
            get;
        }

        [SerializeField] private string soundName;
        private void Awake()
        {
            
        }
        public override void ShowEffect(Action endShowEffect)
        {
            ShowEffect();
            endShowEffect();
        }

        public override void HideEffect(Action endHideEffect)
        {
            endHideEffect();
        }

        public override void Hide()
        {
            
        }

        public override void ShowEffect()
        {
            MySound.Instance.PlaySound(soundName);
        }

        public override void HideEffect()
        {
            
        }
    }
}
