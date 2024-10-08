using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterManager : MonoBehaviour
{
    public string startBackGround;
    public string startDialog;

    public string[] dialogs;


    public static ChapterManager instance;

    private int dialogIndex = 0;
    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        BackGroundManager.instance.ChangeBackGround(startBackGround);
        LeanTween.delayedCall(2,()=> FadeControl.instance.FadeIn(()=>DialogSystem.instance.StartDialog(startDialog)));
        Mainsys.instance.EnableObjectView(false);
    }

    internal void NextDialog()
    {
        DialogSystem.instance.StartDialog(dialogs[dialogIndex]);
        dialogIndex++;
    }


    internal static void LoadScene(string v)
    {

        FadeControl.instance.FadeOut(() =>SceneManager.LoadScene(v));
    }
}
