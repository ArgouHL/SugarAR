using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ViewObjectCtr : MonoBehaviour
{


    public UnityEvent aniStart;
    public string aniDialog;
    public float aniDuration;
    

    public void PlayAni()
    {
        aniStart?.Invoke();
        Debug.Log("StartAni");
        DialogSystem.instance.StartDialog(aniDialog);
        
    }

    public void EndAni()
    {
        Destroy(gameObject);
    }    


}
