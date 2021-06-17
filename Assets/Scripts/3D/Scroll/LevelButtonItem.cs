using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonItem : MonoBehaviour
{
    [HideInInspector]
    public int levelIndex;
    [HideInInspector]
    public LevelScrollViewControler levelScrollViewControler;


    [SerializeField]
      public Text levelButtonText; // was private b4

    private void Start(){
        levelButtonText.text =  (levelIndex +1).ToString();
    }

    public void OnLevelButtonClick(){
        levelScrollViewControler.OnLevelButtonClick(levelIndex);
    }
}
