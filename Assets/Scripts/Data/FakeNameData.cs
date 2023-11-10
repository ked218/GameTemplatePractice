using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class FakeNameData
{
    public string US_UK;
    public string Brazil;
    public string Indonesia;
    public string Japan;
    public string India;
    public string China_Taiwan_HK;
    public string Korea;
    public string France;
    public string Arab;
    public string Russia;
    public string Spain;
}

public class FakeNameJSONData : JSONArrayData<FakeNameData>
{
    protected override FakeNameData ConvertArrayData(JSONNode json, int index)
    {
        return JsonUtility.FromJson<FakeNameData>(json.ToString());
    }
}