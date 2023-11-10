using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelsController : MonoBehaviour
{
    [SerializeField]
    LevelController prefabLevel;

    [SerializeField]
    Transform content;

    //Transform currentLevel = null;

    // Start is called before the first frame update
    void Start()
    {
        int numLevel = DataController.Instance.levelData.Count;
        for (int level = 1; level <= numLevel; level++)
        {
            LevelController levelController = Instantiate(prefabLevel, content);
            levelController.Init(level);
        }

        content.localPosition = new Vector3(0f,(GlobalVar.GetCurrentLevel(LevelKey.MainLevel) - 1)* prefabLevel.GetComponent<RectTransform>().sizeDelta.y);
    }
}
