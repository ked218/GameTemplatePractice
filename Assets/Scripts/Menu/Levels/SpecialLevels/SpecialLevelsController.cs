using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpecialLevelsController : MonoBehaviour
{
    [SerializeField]
    SpecialLevelController prefabLevel;

    [SerializeField]
    Transform content;

    List<SpecialLevelController> specialLevels = new List<SpecialLevelController>();

    //Transform currentLevel = null;

    // Start is called before the first frame update
    //void Start()
    //{
        

    //    content.localPosition = new Vector3(0f,(GlobalVar.CurrentLevel - 1)* prefabLevel.GetComponent<RectTransform>().sizeDelta.y);
    //}

    public void Init(string dataName)
    {
        Debug.Log(dataName);

        foreach (SpecialLevelController controller in specialLevels)
        {
            controller.gameObject.SetActive(false);
        }

        int numLevel = DataController.Instance.dic_dataName_Data[dataName].Count;
        for (int level = 1; level <= numLevel; level++)
        {
            SpecialLevelController levelController;
            if (specialLevels.Count >= level)
            {
                levelController = specialLevels[level - 1];
                levelController.gameObject.SetActive(true);
            }
            else
            {
                levelController = Instantiate(prefabLevel, content);
                specialLevels.Add(levelController);
            }
            levelController.Init(dataName,level);
        }
    }
}
