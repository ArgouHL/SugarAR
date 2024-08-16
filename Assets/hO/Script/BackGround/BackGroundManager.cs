using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundManager : MonoBehaviour
{
    public static BackGroundManager instance;
    public Image backGroundImg;
    public GameObject backGround => backGroundImg.gameObject;
    public BackGroundList backGroundList;

    private Dictionary<string, BackGroundItem> backGroundItems = new();
    private void Awake()
    {
        instance = this;
        foreach (var b in backGroundList.BackGroundItems)
        {
            backGroundItems.Add(b.id, b);
        }
    }


    public void ChangeBackGround(string key)
    {
        try
        {
            backGroundImg.sprite = backGroundItems[key].Image;
            backGroundImg.color = Color.white;

            ChangeImageRatio(backGroundImg.sprite);



        }
        catch
        {

        }
    }

    private void ChangeImageRatio(Sprite sprite)
    {
        var v2 = backGroundImg.rectTransform.sizeDelta;
        v2.x=MathfHelper.GetWidth(sprite, v2.y);
        backGroundImg.rectTransform.sizeDelta = v2;

    }

    public void EnableBackGround(bool b)
    {
        backGround.SetActive(b);
    }



}
