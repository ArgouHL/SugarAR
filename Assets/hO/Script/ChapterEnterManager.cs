using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterEnterManager : MonoBehaviour
{
    public CanvasGroup[] chapterButtons;


    
    private void Start()
    {
        DisableAllChapter();
        EnableChapter(3);
        FadeControl.instance.FadeIn();
    }

    public void EnableChapter(int chapter)
    {
        int index = chapter - 1;
        chapterButtons[index].interactable = true;
        chapterButtons[index].alpha=1;
    }

    public void DisableAllChapter()
    {
        foreach(var c in chapterButtons)
        {
            c.interactable = false;
            c.alpha =0.5f;
        }
    }

    public void EnterChapter(int chapter)
    {
        SfxPlayerControl.instance.PlayClick();
        FadeControl.instance.FadeOut(() => SceneManager.LoadScene("Ch" + chapter));
       
    }

    
}
