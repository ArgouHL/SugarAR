using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainsys : MonoBehaviour
{
    public static Mainsys instance;

    bool b;
    private void Awake()
    {
        instance = this;
    }

    public void TestAR()
    {

        b = !b;
 
        EnableAR(b);
        EnableObjectView(!b);
    }

    public void EnableAR(bool enable)
    {
        ArsystemCtr.instance.Test(enable);
        BackGroundManager.instance.EnableBackGround(!enable);
    }

    public void EnableObjectView(bool enable)
    {
        ViewerObjectManager.instance.Test(enable);
        
    }




}
