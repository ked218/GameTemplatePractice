using LTA.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LTA.Effect
{
    public class EffectMoveToTranform : TweenEffect
    {
        Vector3 originPos;
        [SerializeField]
        Transform newTranform;
        private void Awake()
        {
            originPos = transform.position;
        }

        public override void Hide()
        {
            transform.position = originPos;
        }

        public override void HideEffect(Action endHideEffect)
        {
            HideEffect(null);
        }

        public override void HideEffect()
        {
            Behaviour.MoveUpdate(originPos);
        }

        public override void ShowEffect(Action endShowEffect)
        {
            Debug.Log(newTranform.position);
            Behaviour.MoveUpdate(newTranform.position, endShowEffect);
        }

        public override void ShowEffect()
        {
            ShowEffect(null);
        }
    }
}
