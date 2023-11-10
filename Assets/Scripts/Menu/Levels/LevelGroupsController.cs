using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGroupsController : MonoBehaviour
{
    [SerializeField]
    LevelGroupController prefabLevelGroup;

    [SerializeField]
    Transform content;
    // Start is called before the first frame update
    void Start()
    {
        int numLevel = DataController.Instance.levelData.Count;
        int nextLevel = 1;
        bool isNext = true;
        while (isNext)
        {
            LevelGroupController levelGroupController = Instantiate(prefabLevelGroup, content);
            isNext = levelGroupController.Init(nextLevel, numLevel);
            nextLevel += levelGroupController.Count;
        }
    }
}
