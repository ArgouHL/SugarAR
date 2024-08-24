using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageTrackingCtr : MonoBehaviour
{
    public static ImageTrackingCtr instance;

    private ARTrackedImageManager aRTrackedImageManager;
    private ARSession aRSession;
    public ViewerScriptableObject viewerObjList;
    private Dictionary<string, ViewerObject> viewerObjectDict = new();

    private Dictionary<string, GameObject> spwanedGameObject = new();


    private void Awake()
    {
        instance = this;
        aRTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        aRSession = FindObjectOfType<ARSession>();
        foreach (var so in viewerObjList.viewerObjects)
        {            
            viewerObjectDict.Add(so.keyName, so);
        }
        
    }

    private void OnEnable()
    {
        aRTrackedImageManager.trackedImagesChanged += OnImageChange;
    }
    private void OnDisable()
    {
        aRTrackedImageManager.trackedImagesChanged -= OnImageChange;
    }

    private void OnImageChange(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage aRTrackedImage in args.added)
        {
            UpdateImage(aRTrackedImage);
        }
      
        foreach (ARTrackedImage aRTrackedImage in args.removed)
        {
            spwanedGameObject[aRTrackedImage.referenceImage.name].SetActive(false);
        }
    }

    private void UpdateImage(ARTrackedImage aRTrackedImage)
    {
        string imageName = aRTrackedImage.referenceImage.name;
        try
        {
            ViewerObject vo = viewerObjectDict[imageName];
            if(!spwanedGameObject.ContainsKey(imageName))
            {
                ViewerObjectManager.instance.SpawnViewerObject(vo);
                Mainsys.instance.EnableAR(false);
            }
            else
            {
                spwanedGameObject[imageName].SetActive(true);
            }
            //spwanedGameObject[imageName].transform.position= aRTrackedImage.transform.position;
            //spwanedGameObject[imageName].transform.rotation = aRTrackedImage.transform.rotation;
        }
        catch(Exception err)
        {
            Debug.LogException(err);
        }
    }

    [ContextMenu("TEST1")]
    public void Test()
    {
        ViewerObject vo = viewerObjectDict["Ch3_AR_1"];
        ViewerObjectManager.instance.SpawnViewerObject(vo);
        Mainsys.instance.EnableAR(false);
    }
    [ContextMenu("TEST2")]
    public void Test2()
    {
        ViewerObject vo = viewerObjectDict["Ch3_AR_2"];
        ViewerObjectManager.instance.SpawnViewerObject(vo);
        Mainsys.instance.EnableAR(false);
    }
    [ContextMenu("TEST3")]
    public void Test3()
    {
        ViewerObject vo = viewerObjectDict["Ch3_AR_3"];
        ViewerObjectManager.instance.SpawnViewerObject(vo);
        Mainsys.instance.EnableAR(false);
    }
}
