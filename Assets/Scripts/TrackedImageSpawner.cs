using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TrackedImageSpawner : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public GameObject carPrefab;

    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();

    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            SpawnOrUpdate(trackedImage);
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            SpawnOrUpdate(trackedImage);
        }
    }

    void SpawnOrUpdate(ARTrackedImage trackedImage)
    {
        if (!spawnedPrefabs.ContainsKey(trackedImage.referenceImage.name))
        {
            GameObject prefab = Instantiate(carPrefab, trackedImage.transform.position, trackedImage.transform.rotation);
            spawnedPrefabs[trackedImage.referenceImage.name] = prefab;
        }
        else
        {
            GameObject prefab = spawnedPrefabs[trackedImage.referenceImage.name];
            prefab.transform.position = trackedImage.transform.position;
            prefab.transform.rotation = trackedImage.transform.rotation;
            prefab.SetActive(true);
        }
    }
}
