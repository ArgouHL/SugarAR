using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageTrackingCtr : MonoBehaviour
{
    public static ImageTrackingCtr instance;

    internal ARTrackedImageManager aRTrackedImageManager;
    private ARSession aRSession;
    public ViewerScriptableObject viewerObjList;
    private Dictionary<string, ViewerObject> viewerObjectDict = new();

    private Dictionary<string, GameObject> spwanedGameObject = new();
    private string tragetArObjectName;

    internal void ResetAR()
    {
        aRSession.Reset();
    }

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

    public void SetTarget(string target)
    {
        tragetArObjectName = target;
    }


    private void OnImageChange(ARTrackedImagesChangedEventArgs args)
    {

        foreach (ARTrackedImage aRTrackedImage in args.added)
        {
            UpdateImage(aRTrackedImage);
            aRTrackedImage.destroyOnRemoval = true;
        }
        foreach (ARTrackedImage aRTrackedImage in args.updated)
        {
            if(aRTrackedImage.trackingState== UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
            UpdateImage(aRTrackedImage);
        }

        foreach (ARTrackedImage aRTrackedImage in args.removed)
        {
            spwanedGameObject[aRTrackedImage.referenceImage.name].SetActive(false);
        }
    }

    private void UpdateImage(ARTrackedImage aRTrackedImage)
    {
        if (tragetArObjectName != aRTrackedImage.referenceImage.name)
            return;
        string imageName = aRTrackedImage.referenceImage.name;

        try
        {
            ViewerObject vo = viewerObjectDict[imageName];
            ViewerObjectManager.instance.SpawnViewerObject(vo);
            Mainsys.instance.EnableAR(false, null);

        }
        catch (Exception err)
        {
            Debug.LogException(err);
        }
    }

    [ContextMenu("TEST")]
    public void Test()
    {
        if (tragetArObjectName == null || tragetArObjectName == "")
            return;
        ViewerObject vo = viewerObjectDict[tragetArObjectName];
        ViewerObjectManager.instance.SpawnViewerObject(vo);
        tragetArObjectName = null;
        Mainsys.instance.EnableAR(false, null);
    }
    
}
