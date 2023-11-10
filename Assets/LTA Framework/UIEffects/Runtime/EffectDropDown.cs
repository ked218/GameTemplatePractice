using UnityEngine;
using System;
using LTA.Base;
using LTA.Effect;

namespace LTA.UI.Effect
{
    public class EffectDropDown : TweenEffect
    {
        [SerializeField]
        float openSize = 798f,closeSize = 235f;

        RectTransform currentRect;

        private void Awake()
        {
            currentRect = GetComponent<RectTransform>();
        }

        public override void HideEffect(Action endHideEffect)
        {
            Behaviour.UpdateValue(currentRect.rect.height, closeSize, OnUpdate,endHideEffect);
        }

        private void OnUpdate(float value)
        {
            currentRect.sizeDelta = new Vector3(currentRect.rect.width, value);
        }

        public override void ShowEffect(Action endShowEffect)
        {
            Behaviour.UpdateValue(currentRect.rect.height, openSize, OnUpdate,endShowEffect);
        }

        public override void Hide()
        {
            currentRect.sizeDelta = new Vector3(currentRect.rect.width, closeSize);
        }

        public override void ShowEffect()
        {
            Behaviour.UpdateValue(currentRect.rect.height, openSize, OnUpdate);
        }

        public override void HideEffect()
        {
            Behaviour.UpdateValue(currentRect.rect.height, closeSize, OnUpdate);
        }
    }
}
