using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathfHelper
{
    public static float GetWidthRatio(Sprite sp)
    {
        return sp.rect.width / sp.rect.height;
    }


    public static float GetWidth(Sprite sp, float _height)
    {
        return sp.rect.width / sp.rect.height * _height;
    }

    public static float GetHeight(Sprite sp, float _width)
    {
        return sp.rect.height / sp.rect.width * _width;
    }
}
