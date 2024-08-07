using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundManager : MonoBehaviour
{
    public static BackGroundManager instance;
    public GameObject backGround;
    public Image backGroundImg;
    private void Awake()
    {
        instance = this;
    }

    public void EnableBackGround(bool b)
    {
        backGround.SetActive(b);
    }


}
