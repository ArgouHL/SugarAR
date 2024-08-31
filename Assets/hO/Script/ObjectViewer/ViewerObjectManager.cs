using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewerObjectManager : MonoBehaviour
{
    public static ViewerObjectManager instance;
    public GameObject nowViewerObject;
    private Camera_move viewer => Camera_move.instance;
    public Material dissolveMaterial;

    private void Awake()
    {
        instance = this;

    }

    private void Start()
    {
        dissolveMaterial.SetFloat("_DissolveAmount", 1);
    }

    public void SpawnViewerObject(ViewerObject viewerObject)
    {
        DestroyViewerObject();
        nowViewerObject = Instantiate(viewerObject.spawnObject, transform);
        viewer.SetLocalRotation(viewerObject.orgRotation.x, viewerObject.orgRotation.y, viewerObject.orgRotation.z);
        viewer.SetEnable(true);
        nowViewerObject.TryGetComponent<ViewObjectCtr>(out ViewObjectCtr viewObjectCtr);
        if (viewObjectCtr != null)
        {
            Dissolve(0, 2f, () => viewObjectCtr.PlayAni());
            DialogSystem.closeDialogAction_Once += () => Dissolve(1, 2f, () => ChapterManager.instance.NextDialog());
            LeanTween.delayedCall(viewObjectCtr.aniDuration, () => DialogSystem.instance.EnableClick(true));
        }

    }



    public void CloseViewer()
    {
        viewer.SetEnable(false);
        Dissolve(1, 2, () => DestroyViewerObject());
    }

    public void DestroyViewerObject()
    {
        if (nowViewerObject == null)
            return;
            Destroy(nowViewerObject);
            nowViewerObject = null;
        
    }

    public void Test(bool b)
    {
        viewer.SetEnable(b);
        if (nowViewerObject != null)
            nowViewerObject.SetActive(b);
    }


    private void Dissolve(float target, float duration, Action action = null)
    {
        LeanTween.value(dissolveMaterial.GetFloat("_DissolveAmount"), target, duration)
            .setOnUpdate((float val) =>
            {
                dissolveMaterial.SetFloat("_DissolveAmount", val);
                Debug.Log(val);
            }).setOnComplete(() =>

         {
             if (action != null)
                 action.Invoke();
         });


    }

}
