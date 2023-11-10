using LTA.Condition;
using LTA.DesignPattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePopUpAcheivementController<T,Data,JSONData> : BasePopUp where T : AcheivementController where Data : AcheivementData where JSONData : JSONArrayData<Data>
{
    [SerializeField]
    T prefabAcheivement;

    [SerializeField]
    Transform content;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Init();
    }

    protected abstract JSONData JSONArrayData{get;}

    private void Init()
    {
        List<Data> list = new List<Data>();
        JSONData acheivementDatas = JSONArrayData;
        foreach (Data acheivementData in acheivementDatas)
        {
            List<ICondition> conditions = new List<ICondition>();
            foreach (ComponentInfo componentInfo in acheivementData.openConditions)
            {
                ComponentHelper.AddComponent(gameObject, componentInfo, (component) =>
                {
                    ICondition condition = (ICondition)component;
                    conditions.Add(condition);
                });
            }
            if (!LevelHelper.CheckCondition(conditions)) continue;
            list.Add(acheivementData);
        }
        foreach (Data acheivementData in list)
        {
            T acheivement = PoolingObject.CreatePooling<T>(prefabAcheivement);
            if (acheivement == null)
                acheivement = Instantiate(prefabAcheivement, content);
            acheivement.onClear = Init;
            acheivement.Init(acheivementData);
        }
    }
}

public class PopUpAcheivementController : BasePopUpAcheivementController<AcheivementController,AcheivementData,AcheivementJSONData>
{
    protected override AcheivementJSONData JSONArrayData => DataController.Instance.acheivementDatas;
}
