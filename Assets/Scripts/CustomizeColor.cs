using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CustomizeColor : MonoBehaviour
{
    public Color[]  ClothesColors;
    public Material chestMat;
    public Material LegsMat;
    
    public void ChangeChestColor(int colorIndex){
        chestMat.color = ClothesColors[colorIndex];
    }

    public void ChangeLegsColors(int colorIndex){
        LegsMat.color = ClothesColors[colorIndex];
    }

    // Start is called before the first frame update
    
 
    // Update is called once per frame
    
}
