using System;
using UnityEngine;
using UnityEngine.UI;
namespace LTA.Effect
{
    [RequireComponent(typeof(Image))]
    public class EffectSprite : BaseEffect
    {
        Image imgEffect;
        Sprite ImgEffect
        {
            set
            {
                
                if (imgEffect == null)
                {
                    imgEffect = GetComponent<Image>();
                }
                if (imgEffect != null)
                {
                    imgEffect.sprite = value;
                    imgEffect.SetNativeSize();
                }
            }
        }

        [SerializeField]
        Sprite ShowSprite,HideSprite;

        public override void Hide()
        {
            if (HideSprite != null)
                ImgEffect = HideSprite;
        }

        public override void HideEffect(Action endEffect)
        {
            HideEffect();
            endEffect();
        }

        public override void ShowEffect(Action endEffect)
        {
            ShowEffect();
            endEffect();
        }

        public override void ShowEffect()
        {
            if (ShowSprite != null)
            {
                ImgEffect= ShowSprite;
            }
        }

        public override void HideEffect()
        {
            if (HideSprite != null)
                ImgEffect = HideSprite;
        }
    }
}
