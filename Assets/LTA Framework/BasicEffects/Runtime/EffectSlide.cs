
using UnityEngine;
using System;
namespace LTA.Effect
{
    public enum TypeSlideEffect
    {
        FromLeft,
        FromRight,
        FromBottom,
        FromTop
    }

    public class EffectSlide : TweenEffect
    {

        [SerializeField]
        TypeSlideEffect typeslideEffect;
        Vector3 originPos;
        Vector3 hidePos;

        protected virtual void Awake()
        {
            originPos = transform.localPosition;
            switch (typeslideEffect)
            {
                case TypeSlideEffect.FromBottom:
                    hidePos = originPos + Vector3.down  * Screen.height*2;
                    break;
                case TypeSlideEffect.FromLeft:
                    hidePos = originPos + Vector3.left  * Screen.width*2;
                    break;
                case TypeSlideEffect.FromRight:
                    hidePos = originPos + Vector3.right * Screen.width*2;
                    break;
                case TypeSlideEffect.FromTop:
                    hidePos = originPos + Vector3.up    * Screen.height*2;
                    break;
            }
        }

        public override void HideEffect(Action endHideEffect)
        {
            Behaviour.MoveUpdateLocal(hidePos,endHideEffect);
        }

        public override void ShowEffect(Action endShowEffect)
        {
            Behaviour.MoveUpdateLocal(originPos,endShowEffect);
        }

        public override void Hide()
        {
            transform.localPosition = hidePos;
        }

        public override void ShowEffect()
        {
            Behaviour.MoveUpdateLocal(originPos);
        }

        public override void HideEffect()
        {
            Behaviour.MoveUpdateLocal(hidePos);
        }
    }
}

