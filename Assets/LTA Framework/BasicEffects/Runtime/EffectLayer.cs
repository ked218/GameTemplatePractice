using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.Base;
using System;
namespace LTA.Effect
{
    public class EffectLayer : BaseEffect
    {
        int originSiblingIndex = 0;
        private void Start()
        {
            originSiblingIndex = transform.GetSiblingIndex()-1;
        }
        public override void Hide()
        {
            transform.SetSiblingIndex(originSiblingIndex);
        }

        public override void HideEffect(Action endHideEffect)
        {
            HideEffect();
            if (endHideEffect != null)
            {
                endHideEffect();
            }
        }

        public override void ShowEffect(Action endShowEffect)
        {
            ShowEffect();
            if (endShowEffect != null)
            {
                endShowEffect();
            }
        }

        public override void ShowEffect()
        {
            transform.SetAsLastSibling();
        }

        public override void HideEffect()
        {
            transform.SetSiblingIndex(originSiblingIndex);
        }
    }
}
