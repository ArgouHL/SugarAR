using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_3_2 : MonoBehaviour
{
	public static Event_3_2 instance;
	public Animator chapter3_2;
	//private Animation anim;
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}
	public void Event3_2_Run()
	{
		Debug.Log("Setting Go to true");
		chapter3_2.SetBool("Go", true);
	}
	public void Event3_2_loop()
	{
		chapter3_2.SetBool("Loop", true);
	}
	public void Event3_2_Stop()
	{
		chapter3_2.SetBool("Go", false);
	}
	public void Event3_2_Stoploop()
	{
		chapter3_2.SetBool("Loop", false);
	}
}
