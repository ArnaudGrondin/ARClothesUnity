using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartAR(){
        SceneManager.LoadScene("ARclothes");
        
    }

    public void Start3D(){
        SceneManager.LoadScene("3DClothes");
    }
    
    public void QuitApp(){ 
        
        Application.Quit();
    }
}
