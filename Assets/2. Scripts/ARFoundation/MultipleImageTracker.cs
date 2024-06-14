using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class MultipleImageTracker : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;

    public GameObject[] placeablePrefabs;

    Dictionary<string, GameObject> spawnedObjects;

    //public TMP_Text debugText;

    public GameObject ARObjectHolder;

//    public GameObject SpawnObject, QuizObject;
    void Awake()
    {
        ResetARObjectSpawn();
    }

    void OnTrackedImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach(ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateSpawnObject(trackedImage);
        }
        foreach(ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateSpawnObject(trackedImage);
        }
        foreach(ARTrackedImage trackedImage in eventArgs.removed)
        {
            spawnedObjects[trackedImage.name].SetActive(false);
        }
    }

    void UpdateSpawnObject(ARTrackedImage trackedImage)
    {
        string referenceImageName = trackedImage.referenceImage.name;

        spawnedObjects[referenceImageName].transform.position = new Vector3(trackedImage.transform.position.x -0.25f,trackedImage.transform.position.y + 0.3f,trackedImage.transform.position.z);
        spawnedObjects[referenceImageName].transform.rotation = trackedImage.transform.rotation;

        spawnedObjects[referenceImageName].SetActive(true);
        //if(!(GameManager.isAnswer[int.Parse(referenceImageName[5].ToString())-1])) spawnedObjects[referenceImageName].SetActive(false);
        //else spawnedObjects[referenceImageName].SetActive(false); 

    }

    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImageChanged;
    }

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImageChanged;
    }

    public void ResetARObjectSpawn()
    {
        Debug.Log("ResetARObjectSpawn");

        spawnedObjects = new Dictionary<string, GameObject>();

        foreach(GameObject obj in placeablePrefabs)
        {
            GameObject newObject = Instantiate(obj, ARObjectHolder.transform);
            newObject.name = obj.name;
            newObject.SetActive(false);

            spawnedObjects.Add(newObject.name, newObject);
        }

    }

    public void DestroyARObjects()
    {
        Debug.Log("DestroyARObjects");
    
        foreach(Transform child in ARObjectHolder.transform)
        {
            Destroy(child.gameObject);
        }

        spawnedObjects.Clear();
    }

    void Update()
    {
        //debugText.text = "trackedImageManager.trackables.count: " + trackedImageManager.trackables.count.ToString();
    }
}
