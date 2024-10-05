using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[DefaultExecutionOrder(-1)]
public class ImageTrackingCtr : MonoBehaviour
{
    public static ImageTrackingCtr instance;

    internal ARTrackedImageManager aRTrackedImageManager;
    private ARSession aRSession;
    public ViewerScriptableObject viewerObjList;
    private Dictionary<string, ViewerObject> viewerObjectDict = new();

    private GameObject spwanedGameObjects;
    private string tragetArObjectName;

    public GameObject arObject;

    public delegate void ScanAction();
    public static ScanAction OnSuccessScan;
    public static ScanAction OnFailScan;

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
        ArSelect.OnHit += CheckHit;


    }
    private void OnDisable()
    {
        aRTrackedImageManager.trackedImagesChanged -= OnImageChange;
        ArSelect.OnHit -= CheckHit;
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
        }
        foreach (ARTrackedImage aRTrackedImage in args.updated)
        {
            UpdateImage(aRTrackedImage);
        }

        foreach (ARTrackedImage aRTrackedImage in args.removed)
        {
            // spwanedGameObjects[aRTrackedImage.referenceImage.name].SetActive(false);
        }
    }

    private void UpdateImage(ARTrackedImage aRTrackedImage)
    {
        if (aRTrackedImage.referenceImage.name != arObject.name)
            return;
        if (spwanedGameObjects==null)
        {
            spwanedGameObjects = Instantiate(arObject);
          
        }
        spwanedGameObjects.SetActive(true);
        spwanedGameObjects.transform.position = aRTrackedImage.transform.position;
        spwanedGameObjects.transform.rotation = aRTrackedImage.transform.rotation;
    }

    private void CheckHit(string hitName)
    {
        var vo = viewerObjectDict[tragetArObjectName];
        if (vo.keyName != hitName)
        {
            DialogSystem.instance.ShowHint(vo.worngHints+":"+ hitName + ":"+ vo.keyName);
            OnFailScan?.Invoke();
            return;
        }
        DialogSystem.instance.CloseDialog();
        OnSuccessScan?.Invoke();
        tragetArObjectName = null;
        ViewerObjectManager.instance.SpawnViewerObject(vo);
        Mainsys.instance.EnableAR(false, null);


    }

    [ContextMenu("TEST")]
    public void Test()
    {
        var vo = viewerObjectDict[tragetArObjectName];
        DialogSystem.instance.CloseDialog();
        OnSuccessScan?.Invoke();
        tragetArObjectName = null;
        ViewerObjectManager.instance.SpawnViewerObject(vo);
        Mainsys.instance.EnableAR(false, null);

    }

}
