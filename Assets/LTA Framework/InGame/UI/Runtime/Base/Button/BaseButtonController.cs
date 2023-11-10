using LTA.Effect;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace LTA.UI
{
	public abstract class BaseButtonController : EffectButtonController, IPointerClickHandler
	{
		public virtual void OnPointerClick(PointerEventData eventData)
		{
			ShowEffect(TypeEffect.Click, () =>
			{
				OnClick();
				HideEffect(TypeEffect.Click);
			});
		}

		protected abstract void OnClick();
	}
}
