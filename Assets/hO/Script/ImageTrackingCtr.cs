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

    private Dictionary<string, GameObject> spwanedGameObjects = new();
    private string tragetArObjectName;

    public delegate void ScanAction();
    public static ScanAction OnSuccessScan;
    public static ScanAction OnFailScan;

    internal void ResetAR()
    {
        aRSession.Reset();
        spwanedGameObjects = new();
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
        if (!spwanedGameObjects.ContainsKey(aRTrackedImage.referenceImage.name))
        {
            var vo = Instantiate(viewerObjectDict[aRTrackedImage.referenceImage.name].trackObject);
            spwanedGameObjects.Add(aRTrackedImage.referenceImage.name, vo);
        }
        var sgo = spwanedGameObjects[aRTrackedImage.referenceImage.name];
        sgo.SetActive(true);
        sgo.transform.position = aRTrackedImage.transform.position;
        sgo.transform.rotation = aRTrackedImage.transform.rotation;
    }

    private void CheckHit(string hitName)
    {
        var vo = viewerObjectDict[tragetArObjectName];
        if (vo.trackObject.name != hitName)
        {
            DialogSystem.instance.ShowHint(vo.worngHints);
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
