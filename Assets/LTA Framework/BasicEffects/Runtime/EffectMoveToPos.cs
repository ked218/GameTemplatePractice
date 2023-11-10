using LTA.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LTA.Effect
{
    public class EffectMoveToPos : TweenEffect
    {
        Vector3 originPos;
        [SerializeField]
        Vector3 newPos;
        private void Awake()
        {
            originPos = transform.localPosition;
        }

        public override void Hide()
        {
            transform.localPosition = originPos;
        }

        public override void HideEffect(Action endHideEffect)
        {
            Behaviour.MoveUpdateLocal(originPos,endHideEffect);
        }

        public override void HideEffect()
        {
            Behaviour.MoveUpdateLocal(originPos);
        }

        public override void ShowEffect(Action endShowEffect)
        {
            Behaviour.MoveUpdateLocal(newPos, endShowEffect);
        }

        public override void ShowEffect()
        {
            Behaviour.MoveUpdateLocal(newPos);
        }
    }
}
