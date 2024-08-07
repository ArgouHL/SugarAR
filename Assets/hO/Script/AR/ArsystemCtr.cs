using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARFoundation;

public class ArsystemCtr : MonoBehaviour
{

    public static ArsystemCtr instance;
    //public GameObject aRCamera;
    public ARSession arSession;
    private void Awake()
    {
        instance = this;
        arSession = FindObjectOfType<ARSession>();
    }

    public void Test(bool e)
    {
        arSession.enabled = e;
    }
}
