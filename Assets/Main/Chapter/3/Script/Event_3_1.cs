﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_3_1 : MonoBehaviour
{
	public static Event_3_1 instance;
	public Animator chapter3_1;
	//private Animation anim;
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}
	public void Event3_1_Run()
	{
		Debug.Log("Setting Go to true");
		chapter3_1.SetBool("Go", true);
	}
	public void Event3_1_loop()
	{
		chapter3_1.SetBool("Loop", true);
	}
	public void Event3_1_Stop()
	{
		chapter3_1.SetBool("Go", false);
	}
	public void Event3_1_Stoploop()
	{
		chapter3_1.SetBool("Loop", false);
	}
}
