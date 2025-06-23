using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class CarPlacement : MonoBehaviour
{
    public GameObject carPrefab;
    public GameObject carPrefab2;

    private GameObject spawnedCar;
    private ARRaycastManager raycastManager;
    private GameObject currentPrefab;

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        currentPrefab = carPrefab;
    }

    void Update()
    {
        if (spawnedCar != null) return;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if (raycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;
                spawnedCar = Instantiate(currentPrefab, hitPose.position, hitPose.rotation);
            }
        }
    }

    public void SwitchToCar1()
    {
        if (spawnedCar != null) Destroy(spawnedCar);
        currentPrefab = carPrefab;
        spawnedCar = null;
    }

    public void SwitchToCar2()
    {
        if (spawnedCar != null) Destroy(spawnedCar);
        currentPrefab = carPrefab2;
        spawnedCar = null;
    }
}
