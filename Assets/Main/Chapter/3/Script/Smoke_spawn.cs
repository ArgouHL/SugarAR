using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke_spawn : MonoBehaviour
{


	public ParticleSystem Smoke;
	public void SpawnSmoke()
	{
		Smoke.Play();
	}
	public void ClearSmokeObjects()
	{
		Smoke.Stop();
	}
}
