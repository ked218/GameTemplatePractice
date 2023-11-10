using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using LTA.Base;
using System;
namespace LTA.Effect
{
	public class EffectScale : TweenEffect
    {

        Vector3 originScale;
        [SerializeField]
        Vector3 effectScale;

        private void Awake()
        {
			originScale = transform.localScale;
        }

        public override void ShowEffect(Action endShowEffect)
        {
            Debug.Log("Effect Scale");
            Behaviour.ScaleUpdate(effectScale, endShowEffect);
		}

        public override void HideEffect(Action endHideEffect)
		{
            Behaviour.ScaleUpdate(originScale,endHideEffect);
		}

        public override void Hide()
        {
            transform.localScale = originScale;
        }

        public override void ShowEffect()
        {
            Behaviour.ScaleUpdate(effectScale);
        }

        public override void HideEffect()
        {
            Behaviour.ScaleUpdate(originScale);
        }
    }
}
