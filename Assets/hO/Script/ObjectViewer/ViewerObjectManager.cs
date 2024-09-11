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
    public CanvasGroup rotatui;
    private void Awake()
    {
        instance = this;

    }

    private void Start()
    {
        dissolveMaterial.SetFloat("_DissolveAmount", 1);
        ShowRotatUI(false);
    }

    public void SpawnViewerObject(ViewerObject viewerObject)
    {
        
        DestroyViewerObject();
        nowViewerObject = Instantiate(viewerObject.viewerObject, transform);
        viewer.SetLocalRotation(viewerObject.orgRotation.x, viewerObject.orgRotation.y, viewerObject.orgRotation.z);
        viewer.SetEnable(true);
        if(nowViewerObject.TryGetComponent<ViewObjectCtr>(out ViewObjectCtr viewObjectCtr))
        {
            ShowRotatUI(true, 1);
            Dissolve(0, 2f, () => viewObjectCtr.PlayAni());
            DialogSystem.closeDialogAction_Once += () => CloseViewer(() => ChapterManager.instance.NextDialog());

            LeanTween.delayedCall(viewObjectCtr.aniDuration, () => DialogSystem.instance.EnableClick(true));
        }


    }



    public void CloseViewer(Action action = null)
    {
        action+= DestroyViewerObject;
        ShowRotatUI(false, 1);
        viewer.SetEnable(false);
        Dissolve(1, 2, action);

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
                //  Debug.Log(val);
            }).setOnComplete(() =>

         {
             if (action != null)
                 action.Invoke();
         });


    }

    private void ShowRotatUI(bool enable, float duration=0.01f)
    {
        float targetVal = enable ? 1 : 0;
        Debug.Log("ShowRotatUI" + targetVal);

        LeanTween.value(rotatui.alpha, targetVal, duration).setOnUpdate((float val) => rotatui.alpha = val);
    }

}
