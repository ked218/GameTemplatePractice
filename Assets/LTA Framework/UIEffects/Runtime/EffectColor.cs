using UnityEngine;
using UnityEngine.UI;
using System;
using LTA.Effect;

namespace LTA.UI.Effect
{
    public class EffectColor : TweenEffect
    {
        public TypeEffect typeEffect
        {
            get;
        }

        [SerializeField]
		Color effectColor;
        [SerializeField]
		Color originColor;

		Graphic img;

        void Awake()
        {
			img = GetComponent<Graphic>();
			originColor = img.color;
        }

        void UpdateColorImage(Color color)
        {
			img.color = color;
        }

        public override void ShowEffect(Action endShowEffect)
        {
            if (img == null)
            {
                endShowEffect();
                return;
            }
            Behaviour.UpdateColor(img.color, effectColor,UpdateColorImage,endShowEffect);
        }

        public override void HideEffect(Action endHideEffect)
        {
            if (img == null)
            {
                endHideEffect();
                return;
            }
            Behaviour.UpdateColor(img.color, originColor,UpdateColorImage,endHideEffect);
        }

        public override void Hide()
        {
            if (img == null)
                return;
            img.color = originColor;
        }

        public override void ShowEffect()
        {
            if (img == null)
                return;
            Behaviour.UpdateColor(img.color, effectColor, UpdateColorImage);
        }

        public override void HideEffect()
        {
            if (img == null)
                return;
            Behaviour.UpdateColor(img.color, originColor, UpdateColorImage);
        }
    }
}

