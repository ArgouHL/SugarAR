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
        dissolveMaterial.SetFloat("_AlphaClip", 0);
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
            Dissolve(1, 0.5f, () => viewObjectCtr.PlayAni());
            DialogSystem.closeDialogAction_Once += ()=>Dissolve(0, 0.5f,()=> ChapterManager.instance.NextDialog());
            LeanTween.delayedCall(viewObjectCtr.aniDuration, ()=>DialogSystem.instance.EnableClick(true));
        }
           
    }



    public void CloseViewer()
    {
        viewer.SetEnable(false);
        Dissolve(0, 0.5f, () => DestroyViewerObject());
    }

    public void DestroyViewerObject()
    {
        if (nowViewerObject == null)
        {
            Destroy(nowViewerObject);
            nowViewerObject = null;
        }
    }

    public void Test(bool b)
    {
        viewer.SetEnable(b);
        nowViewerObject.SetActive(b);
    }


    private void Dissolve(float target, float duration, Action action = null)
    {
        LeanTween.value(dissolveMaterial.GetFloat("_AlphaClip"), target, duration)
            .setOnUpdate((float val) => dissolveMaterial.SetFloat("_AlphaClip", val)).setOnComplete(() =>
            {
                if (action != null)
                    action.Invoke();
            });
    }

}
