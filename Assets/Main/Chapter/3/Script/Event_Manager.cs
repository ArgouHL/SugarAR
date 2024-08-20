using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Manager : MonoBehaviour
{
	public GameObject barrel;
	public GameObject lid;
	public GameObject fire_wood;
	public GameObject burnt;
	public GameObject barrelWater;
	public GameObject waterfall;
	public GameObject WaterPlane;
	public GameObject Rice;
	public GameObject Maia;



	private Animation anim;



	public void EventB1()
	{
		Fire_spawn.instance.ClearFireObjects();
		
	}
	//public void EventB1()
	//{
	//	Fire_spawn.instance.ClearFireObjects();
	//	Smoke_spawn.instance.ClearSmokeObjects();
	//	barrel.SetActive(false);
	//	lid.SetActive(false);
	//	burnt.SetActive(false);
	//	fire_wood.SetActive(false);

	//}

	//private IEnumerator EventB1Coroutine()
	//{
	//	Fire_spawn.instance.ClearFireObjects();
	//	Smoke_spawn.instance.ClearSmokeObjects();
	//	barrel.SetActive(true);


	//}

	public void EventB2()
	{
		Fire_spawn.instance.ClearFireObjects();
		
		anim = null;
		barrel.SetActive(true);
		lid.SetActive(false);
		burnt.SetActive(false);
		fire_wood.SetActive(false);
		barrel.transform.position = new Vector3(0.2613f, 8.25f, 0.2215f);
		anim = barrel.GetComponent<Animation>();
		PlayAnim.instance.PlayAnimation(anim,"barrelS2");

	}
	public void EventB3()
	{
		
		Fire_spawn.instance.ClearFireObjects();
		anim = null;
		barrel.SetActive(true);
		lid.SetActive(true);
		burnt.SetActive(false);
		fire_wood.SetActive(true);
		anim = lid.GetComponent<Animation>();
		PlayAnim.instance.PlayAnimation(anim, "lidS3");
		anim = fire_wood.GetComponent<Animation>();
		PlayAnim.instance.PlayAnimation(anim, "fire_woodS3");

	}
	public void EventB4()
	{
		
		Fire_spawn.instance.ClearFireObjects();
		barrel.SetActive(true);
		lid.SetActive(true);
		burnt.SetActive(true);
		fire_wood.SetActive(false);
		anim = lid.GetComponent<Animation>();
		PlayAnim.instance.PlayAnimation(anim, "lidS4");
	}

	public void EventB5()
	{
		Rice.transform.position = new Vector3(3, 17f, -0.22f);
		Maia.transform.position = new Vector3(-1.9f, 17f, -0.22f);
		anim = barrelWater.GetComponent<Animation>();
		PlayAnim.instance.PlayAnimation(anim, "barrelWaterS5");
		WaterPlane.transform.position = new Vector3(-0.221f, 3, -0.221f);
	}

	


}
