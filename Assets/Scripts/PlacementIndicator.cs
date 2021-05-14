using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    private ARRaycastManager aRRaycastManager;
    private GameObject visual;
   void start(){
       // get the component
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();// will look for every raycastmanager in the scene
        //our placement indicator
        visual = transform.GetChild(0).gameObject;

        // hide the placement visual at the very beginning ,we will see it right after we found a horizontal plan
        visual.SetActive(false);

   }

   void Update (){
       // shoot a raycast from the center of the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes ); 

        // if we  hit an AR plane, update the position and rotation
        if(hits.Count > 0){
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
            //if our visual is inactive
            if(!visual.activeInHierarchy){
                visual.SetActive(true);
            }
        }
   }

}
