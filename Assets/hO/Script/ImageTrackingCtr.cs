using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageTrackingCtr : MonoBehaviour
{
    public static ImageTrackingCtr instance;

    private ARTrackedImageManager _aRTrackedImageManager;
    private ARSession aRSession;
    private void Awake()
    {
        instance = this;
        _aRTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        aRSession = FindObjectOfType<ARSession>();


    }
}
