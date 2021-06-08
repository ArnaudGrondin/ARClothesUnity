using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothes : MonoBehaviour 
{
    public GameObject[] womanChest;
    public GameObject[] manChest;
    public GameObject[] womanLegs;
    public GameObject[] manLegs;

    public GameObject[] body;

    private int currentChest;
    private int currentLegs;
    private bool isMan;

    public void nextChest(){

        if(isMan){ // if the selected body is the man body
            nextElement(manChest,currentChest);
        }else{
           nextElement(womanChest,currentChest);
        }
        

        }

        public void previousChest(){

            if(isMan){
                previousElement(manChest,currentChest);
            }else{
                previousElement(womanChest,currentChest);
            }
        }
      

    public void nextLegs(){

        if(isMan){
            nextElement(manLegs,currentLegs);
        }else{
            nextElement(womanLegs,currentLegs);
        }

    }

    public void previousLegs(){

        if(isMan){
            previousElement(manLegs,currentLegs);
        }else{
            previousElement(womanLegs,currentLegs);
        }

    }

    public void switchBody(){
        if(isMan){ // if the man body is active we change to the woman body
            currentChest= 0;
            currentLegs = 0;
            body[1].SetActive(false);
            body[0].SetActive(true);
            isMan= false;
        }else{
            currentChest = 0;
            currentLegs = 0;
            body[1].SetActive(true);
            body[0].SetActive(false);
            isMan= true;
        }
    } 


    // Start is called before the first frame update
    void Start()
    {   
        
        /*
        for (int i = 0; i < manChest.Length; i++){
            Instantiate(manChest[i]).SetActive(false);
            
        }
        for (int i = 0; i < manLegs.Length; i++){
            Instantiate(manLegs[i]).SetActive(false);
        }
        for (int i = 0; i < womanChest.Length; i++){
            Instantiate(womanChest[i]).SetActive(false);
        }
        for (int i = 0; i < womanLegs.Length; i++){
            Instantiate(womanLegs[i]).SetActive(false);
        }
        */
        currentChest = 0;
        currentLegs = 0; 
        nextLegs();
        nextChest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void previousElement( GameObject[] tabClothes, int currentElement){

        if(currentElement == 0 ){
            currentElement = tabClothes.Length - 1;
        }else{
            currentElement--;
        }

        for (int i = 0; i < manLegs.Length; i++){

            if(i == currentElement){
                Instantiate(tabClothes[i]);
            }else{
                Destroy(tabClothes[i]);

            }
        }
    }

    public void nextElement(GameObject[] tabClothes, int currentElement){
         if(currentElement == tabClothes.Length - 1){
            currentElement = 0;
        }else{
            currentElement++;
        }

        for (int i = 0; i < tabClothes.Length; i++){

            if(i == currentElement){
                Instantiate(tabClothes[i]);
            }else{
                
                Destroy(tabClothes[i]);

            }
            }
    }

    public void clothesInit(){ // this function initialise one body and one suit
        body[1].SetActive(false);
        body[0].SetActive(true); // at the beginning of the scenes we put the man body
        isMan = true;

        for(int i = 0; i < manChest.Length; i++)
        {
            manChest[i].SetActive(false);
        }

        for(int i = 0; i < manLegs.Length; i++)
        {
            manLegs[i].SetActive(false);
        }

        for(int i = 0; i < womanChest.Length; i++)
        {
            womanChest[i].SetActive(false);
        }

        for(int i = 0; i < womanLegs.Length; i++)
        {
            womanLegs[i].SetActive(false);
        }
    }
}

