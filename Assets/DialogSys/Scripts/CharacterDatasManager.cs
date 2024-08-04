using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "DialogSyetem/Create CharacterDatasManager", order = 0)]
public class CharacterDatasManager : ScriptableObject
{
    public NpcSettingObj[] npcSettingObjs;
}
