using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class TapToPlace : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private GameObject spawnObject;
    [SerializeField]
    private GameObject objectToPlace;
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }
    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount>0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }
    private void Update()
    {
        if(!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }
        if(raycastManager.Raycast(touchPosition,s_Hits,TrackableType.PlaneWithinPolygon))
        {
            var hitPose = s_Hits[0].pose;
            if(spawnObject == null)
            {
                spawnObject = Instantiate(objectToPlace, hitPose.position, hitPose.rotation);

            }
            else
            {
                spawnObject.transform.position = hitPose.position;
                spawnObject.transform.rotation = hitPose.rotation;
            }
        }
    }
}
