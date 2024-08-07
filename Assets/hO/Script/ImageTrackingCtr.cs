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
    private ViewerScriptableObject[] viewerScriptableObjects;
    private Dictionary<string, ViewerObject> viewerObjectDict = new();

    private void Awake()
    {
        instance = this;
        aRTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        aRSession = FindObjectOfType<ARSession>();
        foreach (var so in viewerScriptableObjects)
        {
            var vo = so.viewerObject;
            viewerObjectDict.Add(vo.keyName, vo);
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
        foreach (ARTrackedImage aRTrackedImage in args.updated)
        {
            UpdateImage(aRTrackedImage);
        }
        foreach (ARTrackedImage aRTrackedImage in args.removed)
        {
            UpdateImage(aRTrackedImage);
        }
    }

    private void UpdateImage(ARTrackedImage aRTrackedImage)
    {
        string imageName = aRTrackedImage.referenceImage.name;
        try
        {
            ViewerObject vo = viewerObjectDict[imageName];
        }
        catch(Exception err)
        {
            Debug.LogException(err);
        }
    }
}
