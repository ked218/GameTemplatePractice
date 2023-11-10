using LTA.Condition;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class BaseLevelController : ConditionController
{
    [SerializeField]
    TextMeshProUGUI txtLevel;

    int level;
    protected LevelData levelData;

    protected abstract LevelData GetLevelData(int level);
    public virtual void Init(int level)
    {
        this.level = level;
        txtLevel.text = level.ToString();
        try
        {
            levelData = GetLevelData(level);
            Init(levelData);
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
        
    }
}
