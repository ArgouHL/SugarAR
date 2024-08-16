using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeControl : MonoBehaviour
{
    public static FadeControl instance;
    public CanvasGroup fadeCanvasGroup;
    public float fadeTime;
    public LeanTweenType fademode;

    private void Awake()
    {
        instance = this;

    }

    public void FadeIn(float _fadeTime, LeanTweenType _fademode, Action endAction)
    {
        fadeCanvasGroup.blocksRaycasts = true;
        LeanTween.value(1, 0, fadeTime).setEase(fademode).setOnUpdate((float val) => fadeCanvasGroup.alpha = val).setOnComplete(
            () =>
            {
                fadeCanvasGroup.blocksRaycasts = false;
                endAction?.Invoke();
            });

    }
    public void FadeOut(float _fadeTime, LeanTweenType _fademode, Action endAction)
    {
        fadeCanvasGroup.blocksRaycasts = true;
        LeanTween.value(0, 1, fadeTime).setEase(fademode).setOnUpdate((float val) => fadeCanvasGroup.alpha = val).setOnComplete(
            () =>
            {
                endAction?.Invoke();
            }); ;
    }

    #region Polymorphism
    public void FadeIn(Action endAction = null)
    {
        FadeIn(fadeTime, fademode, endAction);
    }

    public void FadeIn(float _fadeTime, Action endAction = null)
    {
        FadeIn(_fadeTime, fademode, endAction);
    }

    public void FadeIn(LeanTweenType _fademode, Action endAction = null)
    {
        FadeIn(fadeTime, _fademode, endAction);
    }



    public void FadeOut(Action endAction = null)
    {
        FadeIn(fadeTime, fademode, endAction);
    }

    public void FadeOut(float _fadeTime, Action endAction = null)
    {
        FadeIn(_fadeTime, fademode, endAction);
    }

    public void FadeOut(LeanTweenType _fademode, Action endAction = null)
    {
        FadeIn(fadeTime, _fademode, endAction);
    }

    #endregion




}
