using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Character", menuName = "DialogSyetem/Create Character Data", order = 1)]
public class NpcSettingObj : ScriptableObject
{
    public NpcSetting npcSetting;

}


[Serializable]
public struct NpcSetting
{
    public int index;
    public string ShowName;
    public Alternate[] alternates;
}

[Serializable]
public struct Alternate
{
    public AlternateType type;
    public Sprite sprite;
    public MotionType defaultMotion;
}

public enum AlternateType
{
    Normal,
    Happy,
    Confuse    
}

public enum MotionType
{
    None,
    Jump
}
