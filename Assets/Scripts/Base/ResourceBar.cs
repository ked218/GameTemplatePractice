using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTA.DesignPattern;
using TMPro;
public class ResourceBar : MonoBehaviour
{
    [SerializeField]
    string resourceKey;

    [SerializeField]
    TextMeshProUGUI txtResource;
    // Start is called before the first frame update
    void Start()
    {
        Observer.Instance.AddObserver(resourceKey, OnUpdate);
        txtResource.text = GlobalVar.GetRescoure(resourceKey).ToString();
    }

    private void OnUpdate(object data)
    {
        txtResource.text = ((int)data).ToString();
    }

    private void OnDestroy()
    {
        Observer.Instance.RemoveObserver(resourceKey, OnUpdate);
    }
}
