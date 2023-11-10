using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelGroupController : MonoBehaviour
{
    [SerializeField]
    LevelController[] levels;

    public int Count
    {
        get
        {
            if (levels == null) return 0;
            return levels.Length;
        }
    }

    public bool Init(int levelMin,int levelMax)
    {
        levels = GetComponentsInChildren<LevelController>();
        foreach(LevelController level1 in levels)
        {
            level1.gameObject.SetActive(false);
        }
        int count = 0;

        for (int level = levelMin;level <= levelMax;level++)
        {
            if (count >= levels.Length) return true;
            if (count >= levelMax) return false;
            levels[count].gameObject.SetActive(true);
            levels[count].Init(level);
            count++;
        }
        return false;
    }

}
