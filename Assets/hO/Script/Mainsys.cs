using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainsys : MonoBehaviour
{
    public static Mainsys instance;


    public CanvasGroup arUI;
    public delegate void ActiveAction(bool b);
    public static ActiveAction OnArEnable;

    private void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        EnableAR(false, null);
       
        Mainsys.instance.EnableObjectView(false);
    }

    private void OnEnable()
    {
        DialogSystem.onClickActions += SfxPlayerControl.instance.PlayClick;
        ImageTrackingCtr.OnSuccessScan += SfxPlayerControl.instance.PlayCorrect;
        ImageTrackingCtr.OnFailScan += SfxPlayerControl.instance.PlayWorng;
    }
    private void OnDisable()
    {
        DialogSystem.onClickActions -= SfxPlayerControl.instance.PlayClick;
        ImageTrackingCtr.OnSuccessScan -= SfxPlayerControl.instance.PlayCorrect;
        ImageTrackingCtr.OnFailScan -= SfxPlayerControl.instance.PlayWorng;
    }


    public void EnableAR(bool enable, string targetName)
    {
        Debug.Log("EnableAR " + enable);
        ShowARUI(enable,1);
        OnArEnable.Invoke(enable);
        if (!enable)
            LeanTween.delayedCall(1.2f, () => ArsystemCtr.instance.SetEnable(enable));
        else
            ArsystemCtr.instance.SetEnable(enable);
        BackGroundManager.instance.EnableBackGround(!enable, 1);
        ImageTrackingCtr.instance.SetTarget(targetName);
    }



    private void ShowARUI(bool enable,float duration)
    {

        float targetVal = enable ? 1 : 0;
        LeanTween.value(arUI.alpha, targetVal, duration).setOnUpdate((float val) => arUI.alpha = val);
    }

    public void EnableObjectView(bool enable)
    {
        ViewerObjectManager.instance.Test(enable);

    }

}
