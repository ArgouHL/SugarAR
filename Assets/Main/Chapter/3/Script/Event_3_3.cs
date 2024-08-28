using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_3_3 : MonoBehaviour
{
	public static Event_3_3 instance;
	public Animator chapter3_3;
	//private Animation anim;
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}
	public void Event3_3_Run()
	{
		Debug.Log("Setting Go to true");
		chapter3_3.SetBool("Go", true);
	}
	public void Event3_3_loop()
	{
		chapter3_3.SetBool("Loop", true);
	}
	public void Event3_3_Stop()
	{
		chapter3_3.SetBool("Go", false);
	}
	public void Event3_3_Stoploop()
	{
		chapter3_3.SetBool("Loop", false);
	}
}
