using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
[RequireComponent(typeof(ARRaycastManager))]
public class TapToPlace : MonoBehaviour
{
    private Pose placementPose;
    




    
    public GameObject gameObjectToInstantiate; // our shoe
    private GameObject spawnedObject;

    private Vector2 touchPosition;
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    ARRaycastManager m_RaycastManager;
    ARAnchorManager m_AnchorManager;
    List<ARAnchor> m_Anchor; 
    ARPlaneManager m_PlaneManager;

    //Remove all reference points created
    /*public void RemoveAllAnchors()
    {
        foreach (var anchor in m_Anchor)
        {
            ARAnchor.Destroy(anchor);
        }
        m_Anchor.Clear();
    }
*/

    void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
        
        m_PlaneManager = GetComponent<ARPlaneManager>();
      /*  m_AnchorManager = GetComponent<ARAnchorManager>();
        m_Anchor = new List<ARAnchor>();
        */
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
    

    // Update is called once per frame
    void Update()
    {        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if (m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
        {
            // Raycast hits are sorted by distance, so the first one
            // will be the closest hit.
            var hitPose = s_Hits[0].pose;

            if(spawnedObject == null){// if our game doest set in AR 
                    //we instatiate it ,
             spawnedObject = Instantiate(gameObjectToInstantiate,hitPose.position,hitPose.rotation);
            }else{ // we move object to another position selecter by user
                spawnedObject.transform.position = hitPose.position;
            }
            
        }
    }

    
}
