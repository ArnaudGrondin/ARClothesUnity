using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame updat
    public void StartAR(){
        SceneManager.LoadScene("ARclothes");
        
    }
    
    public void QuitApp(){ 
        
        Application.Quit();
    }
}
