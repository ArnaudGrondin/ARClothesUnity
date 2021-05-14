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
    public GameObject prefabToPlace;
    public Camera ARCamera;
    
    private void Awake(){
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update(){
        if(!isObjectPlaced){
            UpdatePlacementPose(); //for position indicator
            if(placemenPoseIsValid && Input.touchCount> 0){
                placeObject();
            }
        }
        
    }
    private void UpdatePlacementPose(){
        var screenCenter = ARCamera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f) ); // the ARCamera give the center of the screen
        var hits = new List<ARRaycastHit>();

        raycastManager.Raycast(screenCenter, hits, TrackableType.All);

        placemenPoseIsValid = hits.Count >0;

        if (placemenPoseIsValid ){
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

    private void placeObject(){
        if( !isObjectSpawned){
           ObjectSpawned = Instantiate(prefabToPlace, placemenPose.position, placemenPose.rotation);
        isObjectPlaced = true;
        positionIndicator.SetActive(false);
        isObjectSpawned = true;
        }else{
            // TODO
            ObjectSpawned.transform.position = placemenPose.position;
            ObjectSpawned.transform.rotation = placemenPose.rotation;

            
        }
        

    }

    public void LockPosition(){
        if (this.isObjectPlaced == true){
            this.isObjectPlaced = false;
        } else {
            this.isObjectPlaced = true;
        }
    }
    
        
    
    

}