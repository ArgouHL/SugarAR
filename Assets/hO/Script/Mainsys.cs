using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainsys : MonoBehaviour
{
    public static Mainsys instance;


    public CanvasGroup arUI;
    private void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        EnableAR(false, null);
        DialogSystem.onClickActions += SfxPlayerControl.instance.PlayClick;
        ImageTrackingCtr.OnSuccessScan += SfxPlayerControl.instance.PlayCorrect;
        Mainsys.instance.EnableObjectView(false);
    }

    



    public void EnableAR(bool enable, string targetName)
    {
        Debug.Log("EnableAR " + enable);
        ShowARUI(enable,1);
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
