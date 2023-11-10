using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SizeImageProcessController : LoadingProcessController
{
    [SerializeField]
    RectTransform imgLoading;

    [SerializeField]
    TextMeshProUGUI txtProcessing;

    protected override void DisplayLoading(float value)
    {
        if (txtProcessing != null)
            txtProcessing.text = "Loading : " + (int)(((float)value / maxValue) * 100) + "%";
        if (imgLoading != null)
            imgLoading.sizeDelta = new Vector2(value,imgLoading.sizeDelta.y);
    }

    protected override void Awake()
    {
        maxValue = imgLoading.sizeDelta.x;
        minValue = 0;
        base.Awake();
    }
}
