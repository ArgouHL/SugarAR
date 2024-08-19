using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    public static PlayAnim instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
    }
    public void PlayAnimation(Animation anim,string animationName)
    {
        if (anim != null)
        {
            anim.Play(animationName);
        }
    }
}
