using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClothesListControl : MonoBehaviour
{
  [SerializeField]

  private GameObject ButtonTemplate;
  
  //private  List<int> intList;

  void start(){
    Debug.Log("start");
      for(int i = 1 ; i<= 20 ; i++){
        Debug.Log("1");
        GameObject button = Instantiate(ButtonTemplate) ;
        Debug.Log("2");

        button.SetActive(true);
        Debug.Log("3");

        button.GetComponent<ClothesListButton>().SetText("Button #"+i);
Debug.Log("4");
        button.transform.SetParent(ButtonTemplate.transform.parent,false);
        Debug.Log("5");

      }
  } 
   
}