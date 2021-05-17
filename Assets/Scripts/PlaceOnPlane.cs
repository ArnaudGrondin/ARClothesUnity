using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceOnPlane : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private Pose placemenPose;
    private bool placemenPoseIsValid;
    private bool isObjectPlaced ; // if the object is placed we cant move it

    private bool isObjectSpawned = false;
    private GameObject ObjectSpawned;

    public GameObject positionIndicator;
    public GameObject[] prefabToPlace; // the prefab passed througth the component
    public Camera ARCamera;

    
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    
    private void Awake(){
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update(){
      
        placeObject();
            
      
        
    }
    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }
    /*
    private void UpdatePlacementPose(){
        //var screenCenter = ARCamera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f)); // the ARCamera give the center of the screen
       

        raycastManager.Raycast(touchPosition, hits, TrackableType.All);

        placemenPoseIsValid = hits.Count >0;

        if (placemenPoseIsValid){
            placemenPose = hits[0].pose;// for some reason prevent the indicator to appear and spawn the body through the plane
            var cameraForward = ARCamera.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;

            placemenPose.rotation = Quaternion.LookRotation(cameraBearing);
            // a Quaternion is an object that contain data about rotation
            positionIndicator.SetActive(true);
            positionIndicator.transform.SetPositionAndRotation(placemenPose.position,placemenPose.rotation);
        }else{// if there is no plane
            positionIndicator.SetActive(false);
        }
    
    }
*/
    private void placeObject(){

                if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if (raycastManager.Raycast(touchPosition, hits, TrackableType.All))
        {
            var cameraForward = ARCamera.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;

            
            // Raycast hits are sorted by distance, so the first one
            // will be the closest hit.
            var hitPose = hits[0].pose;

            if(ObjectSpawned == null){// if our game doest set in AR 
                    //we instatiate it ,
             ObjectSpawned = Instantiate(prefabToPlace[0],hitPose.position,Quaternion.LookRotation(cameraBearing));
            }else{ // we move object to another position selecter by user
                //ObjectSpawned.transform.position = hitPose.position;
                //ObjectSpawned.transform.rotation = Quaternion.LookRotation(cameraBearing);
            }}



      
        

    }

    public void LockPosition(){
        if (this.isObjectPlaced == true){
            this.isObjectPlaced = false;
        } else {
            this.isObjectPlaced = true;
        }
    }
    
        
    public void changeBody(){
            ObjectSpawned= null;
    }
    

}