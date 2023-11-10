using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[System.Serializable]
public class RewardData
{
    public string iconPath;
    public int quantity;
}


public class RewardController : MonoBehaviour
{
    [SerializeField]
    Image imgIcon;

    [SerializeField]
    TextMeshProUGUI txtQuantity;


    public void Init(RewardData rewardData)
    {
        imgIcon.sprite = Resources.Load<Sprite>("Icons/"+ rewardData.iconPath);
        txtQuantity.text = rewardData.quantity.ToString();
    }
}
