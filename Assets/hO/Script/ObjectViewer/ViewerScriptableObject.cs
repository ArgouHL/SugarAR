using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ViewerObject", menuName = "ObjectViewer/Create ViewerObject Data", order = 1)]
public class ViewerScriptableObject : ScriptableObject
{
    public ViewerObject[] viewerObjects;
}

[System.Serializable]
public class ViewerObject
{
    public string keyName;
    public GameObject trackObject;
    public GameObject viewerObject;
    public Vector3 orgRotation;
    public string worngHints;

}
