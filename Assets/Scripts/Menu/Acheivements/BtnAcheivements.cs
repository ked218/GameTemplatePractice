using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnAcheivements : MonoBehaviour,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        PopUp.Instance.ShowLocalPopUp<PopUpAcheivementController>("PopUpAcheivement");
    }

}
