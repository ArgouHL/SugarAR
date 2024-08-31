using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainsys : MonoBehaviour
{
    public static Mainsys instance;

    bool b;
    private void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        EnableAR(false, null);
    }

    public void EnableAR(bool enable, string targetName)
    {
        Debug.Log("EnableAR " + enable);
        if (!enable)
            LeanTween.delayedCall(1.2f, () => ArsystemCtr.instance.SetEnable(enable));
        else
            ArsystemCtr.instance.SetEnable(enable);
        BackGroundManager.instance.EnableBackGround(!enable, 1);
        ImageTrackingCtr.instance.SetTarget(targetName);
    }

    public void EnableObjectView(bool enable)
    {
        ViewerObjectManager.instance.Test(enable);

    }




}
