using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcControl  : MonoBehaviour
{
    public Vector2 orgPos;
    public Image npcImage;
    public CanvasGroup canvasGroup;
    public Color grayColor;
    public int npcImageheight = 800;
    private const int jumpHeight= 200;
    private LTSeq nowMotin;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        orgPos=GetComponent<RectTransform>().anchoredPosition;
       

    }



    public void ShowNpc(Sprite sp, MotionType motionType = 0)
    {
        
        npcImage.sprite = sp;
        canvasGroup.alpha = 1;
        npcImage.color = Color.white;
        Debug.Log(gameObject.name + "white");
        float ratio = MathfHelper.GetWidthRatio(sp);
        ChangeImageRatio(ratio);
        NpcMotion(motionType);
        
    }

    private void NpcMotion(MotionType motionType)
    {
        RectTransform rect = GetComponent<RectTransform>();
        LeanTween.cancel(rect);
        rect.anchoredPosition = orgPos;
        switch (motionType)
        {
            case MotionType.Jump:
                LeanTween.sequence()
                    .append(LeanTween.moveY(rect, orgPos.y+ jumpHeight, 0.05f).setEaseOutQuad())    
                    .append(LeanTween.moveY(rect, orgPos.y,0.05f).setEaseInQuad());
                break;
            default:
                break;
        }
    }

    public void HideNpc()
    {
        canvasGroup.alpha = 0;
    }

    internal void Gray()
    {
        npcImage.color = grayColor;
     //   Debug.Log(gameObject.name + "Gray");

    }

    private void ChangeImageRatio(float ratio)
    {
        //Vector2 v2 = npcImage.rectTransform.sizeDelta;
        //v2.x = v2.y * ratio;
        Vector2 v2 = new Vector2(npcImageheight * ratio, npcImageheight);
        npcImage.rectTransform.sizeDelta = v2;
    }

  

}
