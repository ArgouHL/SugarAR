using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Manager : MonoBehaviour
{
	public GameObject barrel;
	public GameObject lid;
	public GameObject fire_wood;
	public GameObject burnt;

	

	private Animation anim;


	
	public void EventB1()
	{
		Fire_spawn.instance.ClearFireObjects();
		Smoke_spawn.instance.ClearSmokeObjects();
		barrel.SetActive(false);
		lid.SetActive(false);
		burnt.SetActive(false);
		fire_wood.SetActive(false);
		
	}
	public void EventB2()
	{
		Fire_spawn.instance.ClearFireObjects();
		Smoke_spawn.instance.ClearSmokeObjects();
		anim = null;
		barrel.SetActive(true);
		lid.SetActive(false);
		burnt.SetActive(false);
		fire_wood.SetActive(false);
		barrel.transform.position = new Vector3(0.2613f, 8.25f, 0.2215f);
		anim = barrel.GetComponent<Animation>();
		PlayAnimation("barrelS2");
		
	}
	public void EventB3()
	{
		Smoke_spawn.instance.ClearSmokeObjects();
		Fire_spawn.instance.ClearFireObjects();
		anim = null;
		barrel.SetActive(true);
		lid.SetActive(true);
		burnt.SetActive(false);
		fire_wood.SetActive(true);
		anim = lid.GetComponent<Animation>();
		PlayAnimation("lidS3");
		anim = fire_wood.GetComponent<Animation>();
		PlayAnimation("fire_woodS3");

	}
	public void EventB4()
	{
		Smoke_spawn.instance.ClearSmokeObjects();
		Fire_spawn.instance.ClearFireObjects();
		barrel.SetActive(true);
		lid.SetActive(true);
		burnt.SetActive(true);
		fire_wood.SetActive(false);
		anim = lid.GetComponent<Animation>();
		PlayAnimation("lidS4");
	}



	public void PlayAnimation(string animationName)
	{
		if (anim != null)
		{
			anim.Play(animationName);
		}
	}
}
