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

    //private bool isObjectSpawned = false;
    private GameObject ObjectSpawned;
    

    public GameObject positionIndicator;
    public GameObject[] prefabToPlace; // the prefab passed througth the component

     public GameObject PrefabSelected;
    public Camera ARCamera;

    
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    
    private void Awake(){
        raycastManager = GetComponent<ARRaycastManager>();
        PrefabSelected = prefabToPlace[0];
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
  
    private void placeObject(){

            if (!TryGetTouchPosition(out Vector2 touchPosition))
            return; // si on a pas de toucher tactile on sort de la fonction

        if (raycastManager.Raycast(touchPosition, hits, TrackableType.All)) // hits is a List of light projectio 
        {
            var cameraForward = ARCamera.transform.forward; // position of the device 
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized; // rotation of the device

            // Raycast hits are sorted by distance, so the first one
            // will be the closest hit.
            var hitPose = hits[0].pose;

            if(ObjectSpawned == null){// if our model is not instancied
                    //we instatiate it ,
             ObjectSpawned = Instantiate(PrefabSelected,hitPose.position,Quaternion.LookRotation(cameraBearing));
            }else{ // we move object to another position selecter by user
                //PrefabSelected.transform.position = hitPose.position;
                //PrefabSelected.transform.rotation = Quaternion.LookRotation(cameraBearing);
            }}
    }

    public void LockPosition(){
        if (this.isObjectPlaced == true){
            this.isObjectPlaced = false;
        } else {
            this.isObjectPlaced = true;
        }
    }
    
    private void setPrefab(GameObject prefabChoosed){
        PrefabSelected = prefabChoosed;
    }
        
    public void changeBody(){
        Destroy(ObjectSpawned);
            ObjectSpawned= null;
            if(PrefabSelected == prefabToPlace[1]){ // if the man if selected it change to woman and vice-versa
                setPrefab(prefabToPlace[0]);
            }else{
                setPrefab(prefabToPlace[1]);
            }
            
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
    

}