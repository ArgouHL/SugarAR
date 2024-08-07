using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewerScriptableObject : ScriptableObject
{
    public ViewerObject viewerObject;
}

[System.Serializable]
public class ViewerObject
{
    public string keyName;
    public GameObject spawnObject;
    public Vector3 orgRotation;
}
