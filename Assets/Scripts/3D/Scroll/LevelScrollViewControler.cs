using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScrollViewControler : MonoBehaviour
{
     [SerializeField] Text levelNumberText;
     [SerializeField] int numberOfLevels;
    [SerializeField] GameObject levelBtnPref;
    [SerializeField] Transform levelBtnParent;
    // Start is called before the first frame update

    LoadClothes LoadClothes;
    
    void Start()
    {   
        
        
        for(int i = 0 ; i< numberOfLevels ; i++){
            GameObject levelBtnObj = Instantiate(levelBtnPref,levelBtnParent) as GameObject;
            levelBtnObj.GetComponent<LevelButtonItem>().levelIndex = i;
            levelBtnObj.GetComponent<LevelButtonItem>().levelScrollViewControler = this;
        }


       /* for(int i = 0 ; i< LoadClothes.ManChests.Count ; i++ ){
            GameObject levelBtnObj = Instantiate(levelBtnPref,levelBtnParent) as GameObject;
            levelBtnObj.GetComponent<LevelButtonItem>().levelButtonText.text = LoadClothes.ManChests[i].name;
            levelBtnObj.GetComponent<LevelButtonItem>().levelScrollViewControler = this;
            levelBtnObj.GetComponent<Image>().color = Color.blue;
        }
        for(int i = 0 ; i< LoadClothes.ManLegs.Count ; i++ ){
            GameObject levelBtnObj = Instantiate(levelBtnPref,levelBtnParent) as GameObject;
            levelBtnObj.GetComponent<LevelButtonItem>().levelButtonText.text = LoadClothes.ManChests[i].name;
            levelBtnObj.GetComponent<LevelButtonItem>().levelScrollViewControler = this;
            levelBtnObj.GetComponent<Image>().color = Color.blue;
        }

        for(int i = 0 ; i< LoadClothes.WomanChests.Count ; i++ ){
            GameObject levelBtnObj = Instantiate(levelBtnPref,levelBtnParent) as GameObject;
            levelBtnObj.GetComponent<LevelButtonItem>().levelButtonText.text = LoadClothes.ManChests[i].name;
            levelBtnObj.GetComponent<LevelButtonItem>().levelScrollViewControler = this;
            levelBtnObj.GetComponent<Image>().color = Color.magenta;
        }

        for(int i = 0 ; i< LoadClothes.WomanLegs.Count ; i++ ){
            GameObject levelBtnObj = Instantiate(levelBtnPref,levelBtnParent) as GameObject;
            levelBtnObj.GetComponent<LevelButtonItem>().levelButtonText.text = LoadClothes.ManChests[i].name;
            levelBtnObj.GetComponent<LevelButtonItem>().levelScrollViewControler = this;
            levelBtnObj.GetComponent<Image>().color = Color.magenta;
        }
        
        */
    }
// triggered when we click on a button , gonna use it for select the good shirt.
    public void OnLevelButtonClick(int levelIndex){
        levelNumberText.text = "Clothes-" + (levelIndex + 1);
        
    }

   
}
