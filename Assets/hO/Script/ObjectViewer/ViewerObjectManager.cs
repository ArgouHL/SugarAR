using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewerObjectManager : MonoBehaviour
{
    public static ViewerObjectManager instance;
    private GameObject nowViewerObject;
    private Camera_move viewer;
    private void Awake()
    {
        instance = this;
        viewer = Camera_move.instance;
    }


    public void SpawnViewerObject(ViewerObject viewerObject)
    {
        DestroyViewerObject();
        Instantiate(viewerObject.spawnObject, transform);
        viewer.SetLocalRotation(viewerObject.orgRotation.x, viewerObject.orgRotation.y, viewerObject.orgRotation.z);
        viewer.SetEnable(true);
    }

    public void CloseViewer()
    {
        viewer.SetEnable(false);
        DestroyViewerObject();
    }

    public void DestroyViewerObject()
    {
        if(nowViewerObject == null)
        {
            Destroy(nowViewerObject);
            nowViewerObject = null;
        }
    }



}