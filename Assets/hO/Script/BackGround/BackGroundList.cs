using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "BackGroundList", menuName = "BackGroundList", order = 1)]
public class BackGroundList : ScriptableObject
{
    public BackGroundItem[] BackGroundItems;
}

[Serializable]
public class BackGroundItem 
{
    public string id;
    public Sprite Image; 


}


