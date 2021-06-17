using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



public class LoadClothes : MonoBehaviour
{
    private GameObject SelectedChest;
    private bool ForMan;

    public List<GameObject> ManChests ;
    public List<GameObject>  WomanChests  ;
    public List<GameObject>  ManLegs;

    public List<GameObject>  WomanLegs;

    public List<GameObject>  ManShoes;

    public List<GameObject>  WomanShoes;
    public List<GameObject>  ManHairs;

    public List<GameObject>  WomanHairs;
    // Start is called before the first frame update
    
    
    private GameObject MaleBody;
    private GameObject FemaleBody;
    
    void Start()
    {
        MaleBody = Resources.Load<GameObject>("3DPrefab/Genesis3Male") as GameObject;
        FemaleBody = Resources.Load<GameObject>("3DPrefab/Genesis3Female") as GameObject;
        loadFromAsset();

       // Chests = Resources.LoadAll<GameObject>("3DPrefab/")

        //TODO fill 4 lists hair chest legs and shoes
    }

    // Update is called once per frame

    void Awake(){
        loadFromAsset();
    }
    void Update()
    {
        
    }

    void SelectChest(int index){

    }

    public void ChangeBody(bool ManActiveBody){
        if(ManActiveBody){
            MaleBody.SetActive(false);
            FemaleBody.SetActive(true);
            ManActiveBody= false;
        }
    }

    public void loadFromAsset(){
        ManChests.AddRange(Resources.LoadAll<GameObject>("3DPrefab/ManClothes/Chest")) ;
        
        ManLegs.AddRange(Resources.LoadAll<GameObject>("3DPrefab/ManClothes/Legs"));
        WomanChests.AddRange(Resources.LoadAll<GameObject>("3DPrefab/WomanClothes/Chests"));
        WomanLegs.AddRange(Resources.LoadAll<GameObject>("3DPrefab/WomanClothes/Legs"));
    }

    
}
