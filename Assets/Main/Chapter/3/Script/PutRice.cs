using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutRice : MonoBehaviour
{
    Animation anim;
    public GameObject barrelRice;
    public GameObject Rice;
    public GameObject barrelMaia;
    public GameObject Maia;
	// Start is called before the first frame update
	public void Putrice()
	{
		anim = barrelRice.GetComponent<Animation>();
		PlayAnim.instance.PlayAnimation(anim, "barrelRiceS5");
		anim = Rice.GetComponent<Animation>();
		PlayAnim.instance.PlayAnimation(anim, "RiceS5");
	}
	public void Putmaia()
	{
		anim = barrelMaia.GetComponent<Animation>();
		PlayAnim.instance.PlayAnimation(anim, "barrelMaiaS5");
		anim = Maia.GetComponent<Animation>();
		PlayAnim.instance.PlayAnimation(anim, "MaiaS5");
	}
}
