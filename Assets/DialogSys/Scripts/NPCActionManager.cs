using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCActionManager : MonoBehaviour
{

    public NpcControl[] npcControls;
    public Dictionary<int, int> npcPairDict;
    private Dictionary<int, NpcSetting> npcDict => DialogSystem.instance.npcDict;

    private void Awake()
    {
        npcPairDict = new();

    }
    private void Start()
    {
        HideAllNPC();
    }
    public void HideAllNPC()
    {
        foreach (var npc in npcControls)
        {
            npc.HideNpc();
        }

    }

    public void GrayAllNPC()
    {
        foreach (var npc in npcControls)
        {
            npc.Gray();
        }

    }


    public void ShowNPC(int npcId, int alternativeIndex, int motionIndex =-1)
    {
        if (!npcPairDict.ContainsKey(npcId))
        {
            npcPairDict.Add(npcId, npcPairDict.Count);
           // Debug.Log("A1");
        }
      //  Debug.Log("A");
        foreach (var npcPair in npcPairDict)
        {
           // Debug.Log("B");
            if (npcPair.Key == npcId)
            {
                MotionType motion;
                if (alternativeIndex >= npcDict[npcPair.Key].alternates.Count())
                {
                    Debug.LogError("Alternative is not existed. " + alternativeIndex);
                    alternativeIndex = 0;
                  


                }
                if (motionIndex < 0)
                {
                     motion = npcDict[npcPair.Key].alternates[alternativeIndex].defaultMotion;
                }
                else
                {
                     motion = (MotionType)motionIndex;
                }
                    npcControls[npcPair.Value].ShowNpc(npcDict[npcPair.Key].alternates[alternativeIndex].sprite, motion);
                //Debug.Log("C");
            }
            else
            {
                npcControls[npcPair.Value].Gray();
                Debug.Log("D");
            }


        }

    }




    public void ShowNPC(NpcSetting npcSetting, int npcSeat)
    {

    }




}
