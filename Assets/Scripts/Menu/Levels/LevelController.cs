using System.Collections.Generic;
using UnityEngine;
using LTA.Condition;
using UnityEngine.UI;

public class LevelController : BaseLevelController
{
    [SerializeField]
    Image imgIcon; 

    [SerializeField]
    Sprite spriteLock, spriteUnlock;

    protected override LevelData GetLevelData(int level)
    {
        return DataController.Instance.levelData[level-1];
    }

    public override void Init(int level)
    {
        base.Init(level);
        if (GlobalVar.GetCurrentLevel(LevelKey.MainLevel) == level)
        {
            Focus.Instance.SetPos(transform.Find("Stage"));
        }
    }

    protected override void Lock()
    {
        imgIcon.sprite = spriteLock;
    }

    protected override void Unlock()
    {
        imgIcon.sprite = spriteUnlock;
    }
}
